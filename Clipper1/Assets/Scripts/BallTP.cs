using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTP : MonoBehaviour
{
    public GameObject ball;
    private Vector3 ballSpawn;

    private void Start()
    {
        ballSpawn = ball.transform.position;
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other + " " + ball);
        if (other == ball.gameObject.GetComponent<SphereCollider>())
        {
            Debug.Log(other + " " + ball.gameObject.GetComponent<SphereCollider>() + ball);
            ball.transform.position = new Vector3(ballSpawn.x, ballSpawn.y, ballSpawn.z);
        }
    }
}
