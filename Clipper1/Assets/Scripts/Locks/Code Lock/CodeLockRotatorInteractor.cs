using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class CodeLockRotatorInteractor : XRSimpleInteractable {

    // Material to switch to that has 
    public Material outlinedMaterial;
    private Material originalMaterial;
    
    public int rotatorID;
    public CodeLockController lockController;
    
    private IEnumerator rotationCoroutine;
    private int rotationSpeed = 2; // Number of faces to rotate per second
    private float degreesPerFace = 360.0f * (1.0f / 10.0f); // Number of degrees for each face of the rotator

    // Called by XRSimpleInteractable when object is selected
    public void ObjectSelected() {
        
        // Start rotating the rotator
        rotationCoroutine = RotatorRotation();
        StartCoroutine(rotationCoroutine);
    }

    // Called by XRSimpleInteractable when object is de-selected
    public void ObjectDeselected() {
        
        // Stop the rotator coroutine
        StopCoroutine(rotationCoroutine);
        
        // Snap the rotator to the closest face
        Vector3 euler = transform.eulerAngles;
        transform.eulerAngles = new Vector3(euler.x, euler.y, (Mathf.Round(euler.z / degreesPerFace) * degreesPerFace));

        // Update the value of this rotator in the CodeLockController
        int value = Mathf.RoundToInt(euler.z / degreesPerFace);
        lockController.SetRotatorValue(rotatorID, value);
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

    private IEnumerator RotatorRotation() {

        // SHOULD PLAY A LOOPABLE SOUND HERE
        
        while (true) {

            // Calculate how many degrees the rotator should rotate
            float rotationAmountZ = (rotationSpeed * degreesPerFace) * Time.deltaTime;
            
            // Rotate this object around the z axis
            transform.Rotate(0, 0, -rotationAmountZ);
            
            yield return null;
        }
    }
}