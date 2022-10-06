using UnityEngine;

namespace UI
{
    public class RoomStaticCamera : MonoBehaviour
    {
        public Transform Enemy;
        [SerializeField] private float _approachRate;
        [SerializeField] private UnityEngine.Camera _camera;
        public RectTransform BoundsRect;
        private Vector2 _lastMinOffset, _lastMaxOffset;

        public void SetBoundsRect(RectTransform boundsRect)
        {
            BoundsRect = boundsRect;
        }

        void Start()
        {
            BoundsRect = GameObject.FindGameObjectWithTag("roomData").GetComponent<RectTransform>();
        }
        
        private void Update()
        {
            if (Enemy == null)
                return;

            var camVertExtent = _camera.orthographicSize;
            var camHorzExtent = _camera.aspect * camVertExtent;

            if (!(_camera.transform.position.x - camHorzExtent >= BoundsRect.offsetMin.x) &&
                !(_camera.transform.position.x + camHorzExtent <= BoundsRect.offsetMax.x) &&
                !(_camera.transform.position.y - camVertExtent >= BoundsRect.offsetMin.y) &&
                !(_camera.transform.position.y + camVertExtent <= BoundsRect.offsetMax.y))
                return;

            var leftBound   = BoundsRect.offsetMin.x + camHorzExtent;
            var rightBound  = BoundsRect.offsetMax.x - camHorzExtent;
            var bottomBound = BoundsRect.offsetMin.y + camVertExtent;
            var topBound    = BoundsRect.offsetMax.y - camVertExtent;

            var position1 = Enemy.transform.position;
            var position = position1;
            var camX = Mathf.Clamp(position.x, leftBound, rightBound);
            var camY = Mathf.Clamp(position.y, bottomBound, topBound);

            var transform1 = _camera.transform;
            transform1.position = new Vector3(Mathf.Lerp(_camera.transform.position.x, camX, _approachRate*Time.deltaTime),
                Mathf.Lerp(_camera.transform.position.y, camY, _approachRate*Time.deltaTime), -1);
        }
    }
}