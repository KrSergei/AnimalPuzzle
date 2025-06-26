using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    public LayerMask mask;
    public float rayDistance = 10f;
    public UIManager uiMng;

    private Camera cam;


    private void Start()
    {
        cam = Camera.main;
        uiMng = GetComponent<UIManager>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;            
            mousePos = cam.ScreenToWorldPoint(mousePos);
            Ray2D ray = new Ray2D(mousePos, Vector3.forward);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward, rayDistance, mask);
            if(hit.collider != null)
            { 
               Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
