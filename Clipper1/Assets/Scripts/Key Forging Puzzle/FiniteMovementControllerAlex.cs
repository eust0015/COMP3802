using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// TODO: Add the ability to move the object away using the joystick


public class FiniteMovementControllerAlex : XRSimpleInteractable {

    // The type of translation that will occur
    public TranslationType transType = TranslationType.Calculated;
    
    // Whether the voodoo should be made or not (only works with transType = Calculated)
    public bool makeVoodoo = true;
    
    // The maximum distance this can be reached in
    public float selectDistance = 50f;
    
    // If the object is selected or hovered
    private bool selected = false;
    private bool hovered = false;
    
    // The original parent of this object
    private Transform initParent;
    
    // Material to switch to that has 
    public Material outlinedMaterial;
    private Material originalMaterial;
    
    // The coroutine that makes the object translate respective to the players controller position (finite movement)
    private IEnumerator finiteMovementCoroutine;

    // Coroutine that Lerps the duplicated object towards the players controller
    public float voodooLerpTime = 0.5f;
    public float voodooDistanceFromController = 0.1f;
    private float voodooLerpedTime = 0.0f;
    private bool voodooLerped = false;
    private Vector3 voodooStartPos = Vector3.zero;
    private IEnumerator voodooCoroutine;
    private GameObject voodooObject;
    
    // Players controller/interactor object reference
    private XRBaseInteractor interactorRef;
    private Vector3 interactorLastPosition;

    private bool ControllerCloseEnough() {

        bool closeEnough = false;

        // Find the controller
        XRBaseControllerInteractor controllerInteractor = firstInteractorSelecting as XRBaseControllerInteractor;
        
        // Check that the controller referenced exists
        if (controllerInteractor != null) {

            // Check the distance to the object
            float distance = Vector3.Distance(controllerInteractor.transform.position, transform.position);
            if (distance <= selectDistance) {

                return true;
            }
        }
        
        return closeEnough;
    }    
    
    // Called by XRSimpleInteractable when object is selected
    public void ObjectSelected() {

        // Before continuing ensure the controller is close enough
        if (!ControllerCloseEnough()) {
            
            return;
        }

        selected = true;

        //--Insert code below here--



        //-----------------------------

        // Turn off any rigidbody so it doesnt take gravity
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) {

            rb.isKinematic = true;
        }

        if (transType == TranslationType.Calculated) {
            
            // Start the voodoo coroutine
            if (makeVoodoo) {
                voodooCoroutine = VoodooTranslation();
                StartCoroutine(voodooCoroutine);
            }
            
            // Starts the FiniteTranslation coroutine that is responsible for object translation
            finiteMovementCoroutine = FiniteTranslation();
            StartCoroutine(finiteMovementCoroutine);
        }else if (transType == TranslationType.ParentBased) {

            // Set the initial parent
            if (initParent == null) {

                initParent = transform.parent;
            }
            
            // Parent the object to the xr controller
            // Find the controller
            XRBaseControllerInteractor controllerInteractor = firstInteractorSelecting as XRBaseControllerInteractor;
        
            // Check that the controller referenced exists
            if (controllerInteractor != null) {

                this.transform.parent = controllerInteractor.transform;
            }
        }

        
    }

    // Called by XRSimpleInteractable when object is de-selected
    public void ObjectDeselected() {

        // Make sure that the object has already been selected else return
        if (!selected) {

            return;
        }
        
        selected = false;
        //--Insert code here--






        //--------------------

        if (transType == TranslationType.Calculated) {
            
            // Stops the FiniteTranslation coroutine that is responsible for object translation
            StopCoroutine(finiteMovementCoroutine);
            
            // Reset voodoo variables
            voodooLerpedTime = 0.0f;
            voodooLerped = false;
            voodooStartPos = Vector3.zero;
            
            // Delete the voodoo Object
            Destroy(voodooObject);
        
            // Cancel the voodoo coroutine
            StopCoroutine(voodooCoroutine);
        }else if (transType == TranslationType.ParentBased) {
            
            // Set the parent back to the initial parent
            transform.parent = initParent;
        }

        // Turn on any rigidbody so it does take gravity
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) {

            rb.isKinematic = false;
        }

    }
    
    // Called by XRSimpleInteractable when object is Hovered


    private IEnumerator VoodooTranslation() {

        // Create the voodoo object if it doesnt already exist
        if (voodooObject == null) {


            Debug.Log("Instantiated Voodoo");
            voodooObject = Instantiate(this.GetComponentInChildren<MeshRenderer>().gameObject, this.transform.position, Quaternion.identity);
            voodooObject.transform.localScale = voodooObject.transform.localScale * 0.1f;

            voodooStartPos = voodooObject.transform.position;
        }
        
        // Positions to lerp between
        Vector3 endPos = Vector3.zero;
        
        // Lerp the voodoo object to the players controller position
        while (voodooLerpedTime <= voodooLerpTime) {

            // Calculate the current position of the lerp
            float lerpPos = voodooLerpedTime / voodooLerpTime;

            // Get reference to the interacting controller
            interactorRef = firstInteractorSelecting as XRBaseInteractor;

            // Check that the controller referenced exists
            if (interactorRef != null) {

                endPos = interactorRef.transform.position + (interactorRef.transform.forward * voodooDistanceFromController);
            }

            // Update the position of the voodoo object based on the lerp value
            Vector3 newPos = Vector3.Slerp(voodooStartPos, endPos, lerpPos);
            voodooObject.transform.position = newPos;

            voodooLerpedTime += Time.deltaTime;
            yield return null;
        }

        voodooObject.transform.position = endPos;
        voodooLerped = true;
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
                        
                        // Positional change of the interacting controller
                        Vector3 interactorPositionDelta =
                            interactorRef.gameObject.transform.position - interactorLastPosition;
                        
                        // Update the position such that it is adjusted 1:1 with the interacting controller
                        Vector3 thisCurrentPosition = this.transform.position;
                        Vector3 thisNewPosition = thisCurrentPosition + interactorPositionDelta;
                        this.transform.gameObject.transform.position = thisNewPosition;

                        // Update the voodoos position such that it is adjusted 1:1 with the interacting controller
                        if (voodooLerped) {
                            
                            Vector3 voodooCurrentPosition = voodooObject.transform.position;
                            Vector3 voodooNewPosition = voodooCurrentPosition + interactorPositionDelta;
                            voodooObject.transform.position = voodooNewPosition;
                        }
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
