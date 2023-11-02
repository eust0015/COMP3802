using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzleTransitionPreventer : MonoBehaviour {

    // Hold a reference to the SphereUIObject
    private SphereUIObject sphereUIObject;
    
    // Holds reference to the XRSimpleInteractable
    private XRSimpleInteractable xrSimpleInteractable;

    // Holds if the puzzle has been completed or not
    private bool puzzleComplete = false;

    public void Start() {

        sphereUIObject = this.GetComponent<SphereUIObject>();
        xrSimpleInteractable = this.GetComponent<XRSimpleInteractable>();
        
        // Set the simple interactable's on select to be this scripts Transition function
        xrSimpleInteractable.selectEntered.RemoveAllListeners();
        xrSimpleInteractable.selectEntered.AddListener(Transition);
    }

    public void Transition(SelectEnterEventArgs args) {

        if (sphereUIObject != null && puzzleComplete) {

            sphereUIObject.move();
        }
    }

    public void SetPuzzleComplete(bool status) {

        puzzleComplete = status;
    }
}
