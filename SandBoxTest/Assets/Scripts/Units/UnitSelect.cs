using System.Collections.Generic;
using UnityEngine;

public class UnitSelect : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();

    private static UnitSelect _instance;

    public static UnitSelect instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        if(unitToAdd.tag != "Uint")
        {
            return;
        }
        DeSelectAll();
        unitSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.GetComponent<AiMovementPlayer>().enabled = true;
    }
    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if(!unitSelected.Contains(unitToAdd)) 
        { 
            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<AiMovementPlayer>().enabled = true;
        }
        else
        {
            unitToAdd.GetComponent<AiMovementPlayer>().enabled = false;
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitSelected.Remove(unitToAdd);
        }
    }
    public void DragSelect(GameObject unitToAdd)
    {
        if(!unitSelected.Contains(unitToAdd)) 
        {
            unitSelected.Add(unitToAdd); 
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<AiMovementPlayer>().enabled = true;
            unitToAdd.GetComponent<AiMovementPlayer>().listnumber = unitSelected.IndexOf(unitToAdd);
        }
    }
    public void DeSelectAll()
    {   foreach(var unit in unitSelected) 
        {
            if (unit.GetComponent<AiMovementPlayer>() != null)
            {
                unit.GetComponent<AiMovementPlayer>().enabled = false;
                unit.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        unitSelected.Clear();
    }
    public void DeSelect(GameObject unitToDeselect)
    {

    }
}
