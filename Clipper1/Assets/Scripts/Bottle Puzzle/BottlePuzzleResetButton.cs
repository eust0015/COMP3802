using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class BottlePuzzleResetButton : XRSimpleInteractable {

    // Material to switch to that has 
    public Material outlinedMaterial;
    private Material originalMaterial;

    private ObjectPositionHolder puzzleBottle;
    private ObjectPositionHolder[] bottles;

    // Called by XRSimpleInteractable when object is selected
    public void ObjectSelected() {
        
        // reset puzzle bottle
        puzzleBottle.Reset();
        
        // Reset all the bottles to their starting position
        foreach (ObjectPositionHolder bottle in bottles) {
            
            bottle.Reset();
        }
        
        // Set this object to inActive
        this.gameObject.SetActive(false);
    }

    // Called by XRSimpleInteractable when object is de-selected
    public void ObjectDeselected() {
        
    }
    
    // Called by XRSimpleInteractable when object is Hovered
    public void ObjectHover() {

        originalMaterial = this.GetComponentInChildren<MeshRenderer>().material;
        this.GetComponentInChildren<MeshRenderer>().material = outlinedMaterial;
        
        // --- Send haptic feedback to the controller
        // Get reference to the interacting controller
        XRBaseControllerInteractor controllerInteractor = firstInteractorSelecting as XRBaseControllerInteractor;
        
        // Check that the controller referenced exists
        if (controllerInteractor != null) {

            controllerInteractor.SendHapticImpulse(0.7f, 0.25f);
        }
        
    }
    
    // Called by XRSimpleInteractable when object is Un-Hovered
    public void ObjectUnhover() {
        
        this.GetComponentInChildren<MeshRenderer>().material = originalMaterial;
    }

    public void SetBottles(ObjectPositionHolder[] bottles_) {

        bottles = bottles_;
    }

    public void SetPuzzleBottle(ObjectPositionHolder puzzleBottle_) {

        puzzleBottle = puzzleBottle_;
    }
}
