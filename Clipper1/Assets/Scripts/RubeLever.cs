using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubeLever : MonoBehaviour
{
    public GameObject ramp1;
    public GameObject ramp2;
    public GameObject ramp3;
    private float startingPosition;
    private Quaternion rampRotation;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = gameObject.transform.rotation.x;
        rampRotation = ramp1.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rampRotation.x + " " + rampRotation.y + " " + rampRotation.z);
        ramp1.transform.rotation = new Quaternion(rampRotation.x, rampRotation.y, gameObject.transform.rotation.x - startingPosition, 1);
        ramp2.transform.rotation = new Quaternion(rampRotation.x, rampRotation.y, gameObject.transform.rotation.x - startingPosition, 1);
        ramp3.transform.rotation = new Quaternion(rampRotation.x, rampRotation.y, gameObject.transform.rotation.x - startingPosition, 1);
    }
}
