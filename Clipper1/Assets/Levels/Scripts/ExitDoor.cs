using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

    private float timeToSwitch = 15.0f;
    private float delta = 0.0f;
    
    // Update is called once per frame
    void Update() {

        // Just a simple countdown timer to switch the room over (will be upgraded such that when door is interacted with the room is changed)
        if (delta <= timeToSwitch) {
            delta += Time.deltaTime;
        } else {
            GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().NextLevel();
        }
    }
}
