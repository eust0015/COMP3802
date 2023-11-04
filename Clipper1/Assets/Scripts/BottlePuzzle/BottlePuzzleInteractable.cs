using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BottlePuzzleInteractable : XRSimpleInteractable
{

    // The maximum distance this can be reached in
    public float selectDistance = 0.5f;

    // If the object is selected or hovered
    private bool selected = false;
    private bool hovered = false;

    // Material to switch to that has 
    public Material outlinedMaterial;
    private Material originalMaterial;

    // The original parent of this object
    private Transform initParent;

    private bool ControllerCloseEnough()
    {

        bool closeEnough = false;

        // Find the controller
        XRBaseControllerInteractor controllerInteractor = firstInteractorSelecting as XRBaseControllerInteractor;

        // Check that the controller referenced exists
        if (controllerInteractor != null)
        {

            // Check the distance to the object
            float distance = Vector3.Distance(controllerInteractor.transform.position, transform.position);
            if (distance <= selectDistance)
            {

                return true;
            }
        }

        return closeEnough;
    }

    // Called by XRSimpleInteractable when object is selected
    public void ObjectSelected()
    {

        // Before continuing ensure the controller is close enough
        if (!ControllerCloseEnough())
        {

            return;
        }

        selected = true;

        // Enable the tooltip
        this.GetComponent<BottlePuzzleController>().ActivateTooltip();

        // Set the initial parent
        if (initParent == null)
        {

            initParent = transform.parent;
        }

        // Turn off any rigidbody so it doesnt take gravity
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {

            rb.isKinematic = true;
        }

        // Parent the object to the xr controller
        // Find the controller
        XRBaseControllerInteractor controllerInteractor = firstInteractorSelecting as XRBaseControllerInteractor;

        // Check that the controller referenced exists
        if (controllerInteractor != null)
        {

            this.transform.parent = controllerInteractor.transform;
        }
    }

    // Called by XRSimpleInteractable when object is de-selected
    public void ObjectDeselected()
    {

        // Make sure that the object has already been selected else return
        if (!selected)
        {

            return;
        }

        // Disable the tooltip
        this.GetComponent<BottlePuzzleController>().DeActivateTooltip();

        // Set the parent back to the initial parent
        transform.parent = initParent;

        // Turn on any rigidbody so it does take gravity
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {

            rb.isKinematic = false;
        }
    }

    // Called by XRSimpleInteractable when object is Hovered
    public void ObjectHover()
    {

        // Before continuing ensure the controller is close enough
        if (!ControllerCloseEnough())
        {

            return;
        }

        hovered = true;

        originalMaterial = this.GetComponentInChildren<MeshRenderer>().material;
        this.GetComponentInChildren<MeshRenderer>().material = outlinedMaterial;

        // --- Send haptic feedback to the controller
        // Get reference to the interacting controller
        XRBaseControllerInteractor controllerInteractor = firstInteractorSelecting as XRBaseControllerInteractor;

        // Check that the controller referenced exists
        if (controllerInteractor != null)
        {

            controllerInteractor.SendHapticImpulse(0.7f, 0.25f);
        }

    }

    // Called by XRSimpleInteractable when object is Un-Hovered
    public void ObjectUnhover()
    {

        // Make sure that the object has already been hovered else return
        if (!hovered)
        {

            return;
        }

        this.GetComponentInChildren<MeshRenderer>().material = originalMaterial;
    }
}

