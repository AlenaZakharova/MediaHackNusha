using UnityEngine;

namespace DefaultNamespace
{
    public class DragAndDrop : MonoBehaviour
    {
        private Camera mainCamera;
        private bool draggingMode = false;
        
        private GameObject gameObjectToDrag;
        Collider2D thisCol;
        private void Start()
        {
            thisCol = GetComponent<Collider2D>();
            mainCamera = Camera.main;
        }
 
 
        void Update()
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D col = Physics2D.OverlapPoint(mousePos);
                if (col != null && !draggingMode && col.gameObject.layer == LayerMask.NameToLayer("Thing"))
                {
                    draggingMode = true;
                    gameObjectToDrag = col.gameObject;
                }
            }
            
            if(Input.GetMouseButton(0) && draggingMode)
                gameObjectToDrag.transform.position = mousePos;

            if (Input.GetMouseButtonUp(0))
            {
                draggingMode = false;
                gameObjectToDrag = null;
            }

        }

    }
}