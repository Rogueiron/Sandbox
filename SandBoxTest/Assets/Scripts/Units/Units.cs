using UnityEngine;

public class Units : MonoBehaviour
{
    private void Start()
    {
        UnitSelect.instance.unitList.Add(this.gameObject);
    }
    private void OnDestroy()
    {
        UnitSelect.instance.unitList.Remove(this.gameObject);
    }
}
