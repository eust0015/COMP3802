using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    private bool locked = true;
    public GameObject lockBottom;
    public GameObject key;
    public int keyHandle = 2;
    public int keyShaft = 2;
    public int keyTeeth = 2;

    private void OnTriggerEnter(Collider other)
    {
        if(other == key.GetComponent<SphereCollider>())
        {
            if(key.GetComponent<KeyForging>().handle == keyHandle && key.GetComponent<KeyForging>().shaft == keyShaft && key.GetComponent<KeyForging>().teeth == keyTeeth)
            {
                locked = false;
                lockBottom.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }


}
