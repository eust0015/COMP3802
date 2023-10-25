using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSelector : MonoBehaviour
{
    public GameObject selector1;
    public GameObject selector2;
    public GameObject selector3;

    private void Start()
    {
        changeMaterial(1, 1);
        changeMaterial(2, 1);
        changeMaterial(3, 1);
    }

    public void changeMaterial(int panelNo, int direction)
    {
        Debug.Log("Working");
        if (panelNo == 1)
        {
            selector1.GetComponent<MaterialManager>().ChangeMaterial(direction);
        }
        else if (panelNo == 2)
        {
            selector2.GetComponent<MaterialManager>().ChangeMaterial(direction);
        }
        else if (panelNo == 3)
        {
            selector3.GetComponent<MaterialManager>().ChangeMaterial(direction);
        }
        else
        {
            Debug.LogError("Selector Number Mismatch");
        }
    }
}
