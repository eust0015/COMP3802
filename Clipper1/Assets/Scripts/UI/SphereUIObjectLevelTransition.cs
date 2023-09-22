using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SphereUIObjectLevelTransition : SphereUIObject {
    
    private LevelManager levelManager;

    protected override void Start() {

        // Finds and sets the level manager in scene
        if (GameObject.FindWithTag("LevelManager")) {
            
            levelManager = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
        }else {
         
            Debug.LogError("Unable to locate LevelManager object in scene!");
        }
    }
    
    // Believe this is deprecated (Orson)
    public override void OnPointerClick(PointerEventData pointerEventData) {
        
        Debug.Log("switching to level " + index);
        levelManager.SwitchLevel(index);
    }
    
    public override void move() {
        
        Debug.Log("switching to level " + index);
        levelManager.SwitchLevel(index);
    }
}
