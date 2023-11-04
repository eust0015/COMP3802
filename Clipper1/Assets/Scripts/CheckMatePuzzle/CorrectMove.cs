using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectMove : MonoBehaviour
{
    public GameObject correctPiece;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == correctPiece)
        {
            other.GetComponent<SnapBack>().enabled = false;
        }
    }
}
