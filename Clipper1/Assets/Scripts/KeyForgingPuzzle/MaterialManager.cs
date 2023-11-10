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

    public void ChangeMaterial(int modifier) {
        
        // Update the count (+-1)
        count += modifier;

        if(count <= 0) {
            count = 4;
        }

        if (count >= 5) {
            count = 1;
        }

        switch(count)
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
