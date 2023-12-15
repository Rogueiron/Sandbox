using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        if (!unitSelected.Contains(unitToAdd))
        {
            if (unitToAdd.tag == "Unit")
            {
                unitSelected.Add(unitToAdd);
                if (unitToAdd.GetComponentInParent<EnemyAiMK2>() != null)
                {
                    unitToAdd.GetComponentInParent<EnemyAiMK2>().walkPointRange = 0f;
                }
                unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
                unitToAdd.GetComponent<AiMovementPlayer>().enabled = true;
            }
            DeSelectAll();
        }
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
            if(unitToAdd.tag == "Unit")
            {
                if (unitToAdd.GetComponentInParent<EnemyAiMK2>() != null)
                {
                    unitToAdd.GetComponentInParent<EnemyAiMK2>().walkPointRange = 0f;
                }
                unitSelected.Add(unitToAdd);
                unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
                unitToAdd.GetComponent<AiMovementPlayer>().enabled = true;
                unitToAdd.GetComponent<AiMovementPlayer>().listnumber = unitSelected.IndexOf(unitToAdd);
            }
        }
    }
    public void DeSelectAll()
    {   
        foreach(GameObject unit in unitSelected) 
        {
            if (unit.GetComponent<AiMovementPlayer>() != null)
            {
                if(unit.GetComponentInParent<EnemyAiMK2>() != null)
                {
                    unit.GetComponentInParent<EnemyAiMK2>().walkPointRange = 10f;
                }
                unit.GetComponent<AiMovementPlayer>().enabled = false;
                unit.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        unitSelected.Clear();

    }
}
