using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    /*
        not done sctructure yet, just for design sketch
    */

    public bool in_dialogue = false;
    [SerializeField] GameObject text_box;
    [SerializeField] public bool makeAnimation = false;
    PlayerManager pm;
    Text text;
    internal TMPro.TMP_Text tmpComponent;
    int state = 0;
    internal string[] scenario;
    bool shake = true;
    internal int index;
    public Coroutine _myCoroutine;
    public float speed;

    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>(); 
        //text_box.SetActive(true);
        //text = text_box.GetComponentInChildren<Text>();
        tmpComponent = text_box.GetComponentInChildren<TMPro.TMP_Text>();
        StopAllCoroutines();
    }
    
    public void appereance(string[] scenario)//scenario?! that's awful gosh, are u really screenwriter?
    {
        if(in_dialogue == false)
        {
            pm.couldMove = false;
            in_dialogue = true;
            text_box.SetActive(true);
            this.scenario = scenario;
            load();
            if(makeAnimation) 
            {   
                _myCoroutine = StartCoroutine(TypeSentence(scenario));
            }          
        }
        else load();
    }
    IEnumerator TypeSentence(string[] scenario)
    {
        tmpComponent.text = "";
        foreach(char letter in scenario[index].ToCharArray())
        {
            tmpComponent.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }
    public void NextSentence()
    {   
        if(index < scenario.Length - 1)
        {
            index++;
            tmpComponent.text = "";
            _myCoroutine = StartCoroutine(TypeSentence(scenario));
        }else{
            tmpComponent.text = "";
            index = 0;
        }
    }
    void load()
    {
        if(shake)
        {
            //StopAllCoroutines();
            shake = false;
        }
        if(state >= scenario.Length)
        {
            text_box.SetActive(false);
            in_dialogue = false;
            state = 0;
            scenario = null;
            pm.couldMove = true;
           // StopAllCoroutines();
            return;
        }
        string line = scenario[state];
        tmpComponent.text = line;
        state++;
        
        /*string[] specials = scenario[state+1].Split(' ');
        
        if(specials[0] != "none")
        {
            int first;
            int last;
            int force;
            int.TryParse(specials[1], out first);
            int.TryParse(specials[2], out last);
            int.TryParse(specials[3], out force);
            StartCoroutine(AnimateVertexColors(first, last, force));
            shake = true;
        }
        */
    }

    struct SymProps
    {
        public float range;
        //public int speed;
        //Color color;
    }

    void shakingEffect(int fSym, int lSym)
    {
        TMPro.TMP_TextInfo textInfo = tmpComponent.textInfo;

        SymProps[] symProps = new SymProps[lSym - fSym + 1];
        for(int i = 0; i < symProps.Length; i++)
        {
            symProps[i].range = Random.Range(-10f,10f);          
        }

        TMPro.TMP_MeshInfo[] originMeshInfo = textInfo.CopyMeshInfoVertexData();

    }
    
    private struct VertexAnim
    {
        public float angleRange;
        public float angle;
        public float speed;
    }

    private IEnumerator AnimateVertexColors(int fSym, int lastSym, float CurveScale)
    {

        // We force an update of the text object since it would only be updated at the end of the frame. Ie. before this code is executed on the first frame.
        // Alternatively, we could yield and wait until the end of the frame when the text object will be generated.
        tmpComponent.ForceMeshUpdate();

        TMPro.TMP_TextInfo textInfo = tmpComponent.textInfo;

        Matrix4x4 matrix;

        int loopCount = 0;
        bool hasTextChanged = true;

        // Create an Array which contains pre-computed Angle Ranges and Speeds for a bunch of characters.
        VertexAnim[] vertexAnim = new VertexAnim[1024];
        for (int i = 0; i < 1024; i++)
        {
            vertexAnim[i].angleRange = Random.Range(10f, 25f);
            vertexAnim[i].speed = Random.Range(1f, 3f);
        }

        // Cache the vertex data of the text object as the Jitter FX is applied to the original position of the characters.
        TMPro.TMP_MeshInfo[] cachedMeshInfo = textInfo.CopyMeshInfoVertexData();

        while (true)
        {
            // Get new copy of vertex data if the text has changed.
            if (hasTextChanged)
            {
                // Update the copy of the vertex data for the text object.
                cachedMeshInfo = textInfo.CopyMeshInfoVertexData();

                hasTextChanged = false;
            }

            int characterCount = textInfo.characterCount;
            characterCount = lastSym;
            // If No Characters then just yield and wait for some text to be added
            if (characterCount == 0)
            {
                yield return new WaitForSeconds(0.25f);
                continue;
            }


            for (int i = fSym; i < characterCount; i++) // i = 0
            {
                TMPro.TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

                // Skip characters that are not visible and thus have no geometry to manipulate.
                if (!charInfo.isVisible)
                    continue;

                    // Retrieve the pre-computed animation data for the given character.
                VertexAnim vertAnim = vertexAnim[i];

                    // Get the index of the material used by the current character.
                int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

                    // Get the index of the first vertex used by this text element.
                int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                    // Get the cached vertices of the mesh used by this text element (character or sprite).
                Vector3[] sourceVertices = cachedMeshInfo[materialIndex].vertices;

                    // Determine the center point of each character at the baseline.
                    //Vector2 charMidBasline = new Vector2((sourceVertices[vertexIndex + 0].x + sourceVertices[vertexIndex + 2].x) / 2, charInfo.baseLine);
                    // Determine the center point of each character.
                Vector2 charMidBasline = (sourceVertices[vertexIndex + 0] + sourceVertices[vertexIndex + 2]) / 2;

                    // Need to translate all 4 vertices of each quad to aligned with middle of character / baseline.
                    // This is needed so the matrix TRS is applied at the origin for each character.
                Vector3 offset = charMidBasline;

                Vector3[] destinationVertices = textInfo.meshInfo[materialIndex].vertices;

                destinationVertices[vertexIndex + 0] = sourceVertices[vertexIndex + 0] - offset;
                destinationVertices[vertexIndex + 1] = sourceVertices[vertexIndex + 1] - offset;
                destinationVertices[vertexIndex + 2] = sourceVertices[vertexIndex + 2] - offset;
                destinationVertices[vertexIndex + 3] = sourceVertices[vertexIndex + 3] - offset;

                vertAnim.angle = Mathf.SmoothStep(-vertAnim.angleRange, vertAnim.angleRange, Mathf.PingPong(loopCount / 25f * vertAnim.speed, 1f));
                Vector3 jitterOffset = new Vector3(Random.Range(-.25f, .25f), Random.Range(-.25f, .25f), 0);

                matrix = Matrix4x4.TRS(jitterOffset * CurveScale, Quaternion.Euler(0, 0, 0), Vector3.one);

                destinationVertices[vertexIndex + 0] = matrix.MultiplyPoint3x4(destinationVertices[vertexIndex + 0]);
                destinationVertices[vertexIndex + 1] = matrix.MultiplyPoint3x4(destinationVertices[vertexIndex + 1]);
                destinationVertices[vertexIndex + 2] = matrix.MultiplyPoint3x4(destinationVertices[vertexIndex + 2]);
                destinationVertices[vertexIndex + 3] = matrix.MultiplyPoint3x4(destinationVertices[vertexIndex + 3]);

                destinationVertices[vertexIndex + 0] += offset;
                destinationVertices[vertexIndex + 1] += offset;
                destinationVertices[vertexIndex + 2] += offset;
                destinationVertices[vertexIndex + 3] += offset;

                vertexAnim[i] = vertAnim;
            }

            for (int i = 0; i < textInfo.meshInfo.Length ; i++)
            {
                textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
                tmpComponent.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
            }
            loopCount += 1;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
