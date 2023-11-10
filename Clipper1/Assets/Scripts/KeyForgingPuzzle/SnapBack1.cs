using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBack1 : MonoBehaviour
{
    private Vector3 snapBackPosition;
    private Quaternion snapBackRotation;
    private double timer;
    private double timer2;
    public double snapBackTimer = 0.1;
    private bool isHeld = false;
    public int snapBackSpeed = 5;
    void Start()
    {
        snapBackPosition = gameObject.transform.position;
        snapBackRotation = gameObject.transform.rotation;
        timer = snapBackTimer;
        timer2 = snapBackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position != snapBackPosition && isHeld == false)
        {
            if (timer < 0)
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, snapBackPosition, snapBackSpeed * Time.deltaTime);
                if (gameObject.transform.position == snapBackPosition)
                {
                    timer = snapBackTimer;
                    gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        if (gameObject.transform.rotation != snapBackRotation && isHeld == false)
        {
            //Debug.Log("AH");
            timer2 -= Time.deltaTime;
            if(timer2 < 0)
            {
                //Debug.Log("AH2");
                gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, snapBackRotation, snapBackSpeed*90*Time.deltaTime);
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                if (gameObject.transform.rotation == snapBackRotation)
                {
                    timer2 = snapBackTimer;
                }
            }
        }
    }

    public void startHolding()
    {
        isHeld = true;
    }

    public void endHolding()
    {
        isHeld = false;
    }
}
