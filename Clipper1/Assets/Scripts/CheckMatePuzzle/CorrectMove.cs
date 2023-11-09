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
            PuzzleManager.SetPuzzleSolved(transform.root);
            other.GetComponent<SnapBack>().enabled = false;
        }
    }
}
