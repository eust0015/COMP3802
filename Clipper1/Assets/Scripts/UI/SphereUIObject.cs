using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SphereUIObject : MonoBehaviour {
    
    [Header("SphereUIObject: The index at which this spheres position is within the SphereManagers Sphere list/array. \n" +
            "SphereUIObjectLevelTransition: The index at which this spheres next level is within the LevelManagers LevelClass list/array.")]
    public int index = -1;
    protected GameObject sphereManagerObject;
    protected SphereManager sphereManager;

    protected virtual void Start()
    {
        sphereManagerObject = GameObject.FindWithTag("SphereManager");
        sphereManager = sphereManagerObject.GetComponent<SphereManager>();
    }

    // Believe this is deprecated (Orson)
    public virtual void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("switching to sphere " + index);
        sphereManager.switchSphere(index);
        
    }
    
    public virtual void move()
    {
        Debug.Log("switching to sphere " + index);
        sphereManager.switchSphere(index);
        
    }
    
    public void hello() {
        Debug.Log("Hello");
    }
}
