using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPuzzleController : MonoBehaviour {
    
    // Whether the puzzle has been solved or not
    private bool solved = false;
    
    // The lock Controller
    public LockController lockController;
    
    // The sphereUI prefab of this room position
    public Transform roomPositionSphere;

    // Update is called once per frame
    void Update() {
        
        // Check if the puzzle has been solved for purposes of tracking solved puzzles
        if (!solved) {
            if (!lockController.locked) {

                // Set solved to true
                solved = true;
                
                // Update the puzzle manager
                PuzzleManager.SetPuzzleSolved(roomPositionSphere);
            }
        }
    }
}
