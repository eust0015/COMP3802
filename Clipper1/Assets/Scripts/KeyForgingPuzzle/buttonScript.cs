using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public int location;
    public int direction;
    public GameObject parent;
    public void GetButtonPress()
    {
        parent.GetComponent<ColourSelector>().changeMaterial(location,direction);
    }
}
