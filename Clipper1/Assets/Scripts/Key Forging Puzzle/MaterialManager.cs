using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;
    public int count = 1;

    public void ChangeMaterial(int modifier)
    {
        count += modifier;
        if (modifier == 0)
        {
            modifier = 4;
        }
        if (modifier == 5)
        {
            modifier = 1;
        }

        switch(modifier)
        {
            case 1:
                gameObject.GetComponent<MeshRenderer>().material = material1;
                break;

            case 2:
                gameObject.GetComponent<MeshRenderer>().material = material2;
                break;

            case 3:
                gameObject.GetComponent<MeshRenderer>().material = material3;
                break;

            case 4:
                gameObject.GetComponent<MeshRenderer>().material = material4;
                break;

        }
    }
}
