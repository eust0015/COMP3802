using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// TODO: Add the ability to move the object away using the joystick

public class FiniteMovementController : XRSimpleInteractable {

    // Material to switch to that has 
    public Material outlinedMaterial;
    private Material originalMaterial;
    
    // The coroutine that makes the object translate respective to the players controller position (finite movement)
    private IEnumerator finiteMovementCoroutine;
    
    // Players controller/interactor object reference
    private XRBaseInteractor interactorRef;
    private Vector3 interactorLastPosition;

    // Called by XRSimpleInteractable when object is selected
    public void ObjectSelected() {

        // Starts the FiniteTranslation coroutine that is responsible for object translation
        finiteMovementCoroutine = FiniteTranslation();
        StartCoroutine(finiteMovementCoroutine);
    }

    // Called by XRSimpleInteractable when object is de-selected
    public void ObjectDeselected() {
        
        // Stops the FiniteTranslation coroutine that is responsible for object translation
        StopCoroutine(finiteMovementCoroutine);
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
    
    private IEnumerator FiniteTranslation() {

        // Just so that this object is not translated on first itteration (until lastPositionIsSet)
        bool lastPosSet = false;
        
        while (true) {

            // --- Start by getting a reference/starting position of the players controller

            // Check if this object is currently selected
            if (isSelected) {

                // Get reference to the interacting controller
                interactorRef = firstInteractorSelecting as XRBaseInteractor;

                // Check that the controller referenced exists
                if (interactorRef != null) {

                    // Make sure the last position has been set before translating
                    if (lastPosSet) {
                        
                        // Update the position such that it is adjusted 1:1 with the interacting controller
                        Vector3 thisCurrentPosition = this.transform.position;
                        Vector3 interactorPositionDelta =
                            interactorRef.gameObject.transform.position - interactorLastPosition;
                        Vector3 thisNewPosition = thisCurrentPosition + interactorPositionDelta;
                        this.transform.gameObject.transform.position = thisNewPosition;
                    }

                    // Set the interatorStartPosition variable
                    interactorLastPosition = interactorRef.gameObject.transform.position;
                    lastPosSet = true;
                    //Debug.Log("Interactor Start Position: " + interactorLastPosition.x + ", " + interactorLastPosition.y + ", " + interactorLastPosition.z);
                }
            }
            
            yield return null;
        }
    }
}
