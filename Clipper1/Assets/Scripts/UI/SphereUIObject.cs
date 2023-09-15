using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SphereUIObject : MonoBehaviour
{
    public int index;
    private GameObject sphereManagerObject;
    private SphereManager sphereManager;

    private void Start()
    {
        sphereManagerObject = GameObject.FindWithTag("SphereManager");
        sphereManager = sphereManagerObject.GetComponent<SphereManager>();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("switching to sphere " + index);
        sphereManager.switchSphere(index);
        
    }
    
    public void move()
    {
        Debug.Log("switching to sphere " + index);
        sphereManager.switchSphere(index);
        
    }
    
    public void hello() {
        Debug.Log("Hello");
    }
}
