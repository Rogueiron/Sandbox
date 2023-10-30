using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    Camera myCam;

    [SerializeField]private RectTransform boxVisual;

    Rect selectionBox;

    Vector2 startPos;
    Vector2 endPos;
    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        startPos = Vector2.zero;
        endPos = Vector2.zero;
        DrawVisual();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        { 
            startPos = Input.mousePosition;
            selectionBox = new Rect();
        }
        if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            DrawVisual();
            Drawselection();
        }
        if (Input.GetMouseButtonUp(0))
        {
            selectUnits();
            startPos = Vector2.zero;
            endPos = Vector3.zero;
            DrawVisual();
        }
    }

    void DrawVisual()
    {
        Vector2 boxstart = startPos;
        Vector2 boxend = endPos;

        Vector2 boxcenter = (boxstart + boxend) / 2;
        boxVisual.position = boxcenter;

        Vector2 boxsize = new Vector2(Mathf.Abs(boxstart.x - boxend.x),boxstart.y - boxend.y);


        boxVisual.sizeDelta = boxsize;
    }
    void Drawselection()
    {
        if(Input.mousePosition.x < startPos.x) 
        {
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPos.x;
        }
        else
        {
            selectionBox.xMin = startPos.x;
            selectionBox.xMax = Input.mousePosition.x;

        }
        if (Input.mousePosition.y < startPos.y)
        {
            selectionBox.xMin = Input.mousePosition.y;
            selectionBox.xMax = startPos.y;
        }
        else
        {
            selectionBox.xMin = startPos.y;
            selectionBox.xMax = Input.mousePosition.y;
        }
    }
    void selectUnits()
    {
        foreach(var unit in UnitSelect.instance.unitList)
        {
            if(selectionBox.Contains(myCam.WorldToScreenPoint(unit.transform.position)))
            {
                UnitSelect.instance.DragSelect(unit);
            }
        }
    }
}
