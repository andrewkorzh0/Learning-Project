using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_SetupTent : Action
{
    [SerializeField] GameObject tentObject;

    public override void action()
    {
        if(!tentObject.activeInHierarchy)
        {
            bool tentAvailable = false;
            int tentInInventory = 0;
            foreach(int i in GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().sessionSave.inventory)
            {

                if(i == 5)
                {
                    tentAvailable = true;
                    break;
                }
                tentInInventory++;
            }
            if(tentAvailable)
            {
                //1.8, 3.5
                tentObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-1f, 2.5f, 0f);
                GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().sessionSave.inventory[tentInInventory] = 0;
            }
        }
        else if (!GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().isInventoryFull())
        {
            tentObject.SetActive(false);
            GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().addItemToInventory(5);
        }
    }
}
