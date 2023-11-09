using System.Collections;
using UnityEngine;

public class BottlePuzzleController : MonoBehaviour
{

    // Enumerator to run every 2 seconds to check where all bottles are
    private IEnumerator posCheckCoroutine;

    // The tooltip to display when the player is holding the bottle
    public Transform tooltip;

    // Holds the reset buttons transform
    public Transform resetButton;

    // Holds the gameobject that holds the rest of the bottles
    public GameObject bottlesParent;

    private bool solved = false;
    
    // The lock Controller
    public LockController lockController;
    
    // The sphereUI prefab of this room position
    public Transform roomPositionSphere;
    
    public void Start()
    {

        posCheckCoroutine = CheckBottlePositions();
        StartCoroutine(posCheckCoroutine);
    }

    public void Update() {

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

    // Called when the player selects the bottle
    public void ActivateTooltip()
    {

        tooltip.gameObject.SetActive(true);
    }

    // Called when the player puts the bottle down
    public void DeActivateTooltip()
    {

        tooltip.gameObject.SetActive(false);
    }

    // Enumerator to check bottle positions
    private IEnumerator CheckBottlePositions()
    {

        while (true)
        {

            int bottlesBelow = 0;

            ObjectPositionHolder[] bottles = bottlesParent.GetComponentsInChildren<ObjectPositionHolder>();
            foreach (ObjectPositionHolder objH in bottles)
            {

                if (objH.gameObject.transform.position.y <= objH.initPosition.y - 0.2f)
                {
                    bottlesBelow++;
                }
            }

            // Check if there are more than 75% of bottles below their init position
            float perc = (bottles.Length > 0) ? (float)bottlesBelow / (float)bottles.Length : 0;
            //Debug.Log(perc);
            if (perc >= 0.75f)
            {

                // Activate the reset button
                resetButton.gameObject.SetActive(true);
                resetButton.GetComponent<BottlePuzzleResetButton>().SetPuzzleBottle(this.GetComponent<ObjectPositionHolder>());
                resetButton.GetComponent<BottlePuzzleResetButton>().SetBottles(bottles);
            }

            // Wait for 2 to seconds pass before trying to run this code again
            yield return new WaitForSeconds(2);
        }
    }
}
