using UnityEditor;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera mycam;

    public LayerMask Clickable;
    public LayerMask Ground;
    void Start()
    {
        mycam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0)) 
        { 
            RaycastHit hit;
            Ray ray = mycam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Clickable)) 
            { 
                if(Input.GetKey(KeyCode.LeftShift)) 
                {
                    UnitSelect.instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                    UnitSelect.instance.ClickSelect(hit.collider.gameObject);
                }
                
            }
            else
            {
                if(!Input.GetKey(KeyCode.LeftShift)) 
                {
                    UnitSelect.instance.DeSelectAll(); 
                }
            }
        }
    }
}
