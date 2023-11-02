using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorCodeLockController : CodeLockController {

    public GameObject door;
    public GameObject transitionSphere;
    public AudioClip lockNoise;
    public AudioClip openCloseNoise;
    private float openAmount = 60.0f; // Amount of degrees to open the door
    private float timeToOpen = 2f;
    private bool rotatingDoor = false;
    
    private IEnumerator doorRotationCoroutine;

    private void OpenDoor() {

        // Check if there is a puzzleTransitionPreventer
        PuzzleTransitionPreventer puzzleTransitionPreventer = transitionSphere.GetComponent<PuzzleTransitionPreventer>();
        if (puzzleTransitionPreventer != null) {
            
            // Since there is we should update it so it doesnt prevent
            puzzleTransitionPreventer.SetPuzzleComplete(true);
        }
        
        doorRotationCoroutine = DoorRotation(-openAmount);
        StartCoroutine(doorRotationCoroutine);
        Unlock();   
    }

    private void CloseDoor() {

        // Check if there is a puzzleTransitionPreventer
        PuzzleTransitionPreventer puzzleTransitionPreventer = transitionSphere.GetComponent<PuzzleTransitionPreventer>();
        if (puzzleTransitionPreventer != null) {
            
            // Since there is we should update it so it prevents
            puzzleTransitionPreventer.SetPuzzleComplete(false);
        }
        
        doorRotationCoroutine = DoorRotation(openAmount);
        StartCoroutine(doorRotationCoroutine);
        Lock();
    }

    protected virtual void UpdateLockStatus(bool shouldLock) {

        if (!rotatingDoor) {
            if (shouldLock) {
                if (locked) {

                    OpenDoor();
                }
            } else {
                if (!locked) {

                    CloseDoor();
                }
            }
        }
    }
    
    public override void SetRotatorValue(int rotatorID, int value) {

        Debug.Log("Updated Rotator: " + rotatorID + " to " + value);
        Debug.Log("New Lock Combination: " + GetCombination());
        rotatorValues[rotatorID] = value;

        UpdateLockStatus(targetCombination == GetCombination());
    }

    public IEnumerator DoorRotation(float amountToRotate) {

        float rotated = 0;
        rotatingDoor = true;
        
        // Play open close noise
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = lockNoise;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = openCloseNoise;
        audioSource.Play();

        // If the door needs to rotate more continue rotating
        while (rotated <= Mathf.Sqrt(amountToRotate*amountToRotate)) {

            // Calculate how much to rotate this frame
            float amountToRotateFrame = (amountToRotate/timeToOpen) * Time.deltaTime;
            door.transform.Rotate(0, amountToRotateFrame, 0);

            // Update the rotated amount
            rotated += Mathf.Sqrt(amountToRotateFrame * amountToRotateFrame);
            
            yield return null;
        }

        rotatingDoor = false;
    }
}
