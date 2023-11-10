using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectMove : MonoBehaviour
{
    public GameObject correctPiece;
    public AudioClip solveSound;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == correctPiece)
        {
            PuzzleManager.SetPuzzleSolved(transform.root);
            other.GetComponent<SnapBack>().enabled = false;
            audioSource.PlayOneShot(solveSound);
        }
    }
}
