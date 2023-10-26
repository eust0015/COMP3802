using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLockController : LockController {
    
    public string targetCombination;
    protected int[] rotatorValues = new int[4];

    protected virtual void UpdateLockStatus(bool newStatus) {

        if (newStatus) {

            if (locked) {
                
                Unlock();
            }
        } else {

            if (!locked) {
                
                Lock();
            }
        }
    }

    public virtual void SetRotatorValue(int rotatorID, int value) {

        Debug.Log("Updated Rotator: " + rotatorID + " to " + value);
        Debug.Log("New Lock Combination: " + GetCombination());
        rotatorValues[rotatorID] = value;

        UpdateLockStatus(targetCombination == GetCombination());
    }

    protected string GetCombination() {
        
        return rotatorValues[0].ToString() + rotatorValues[1].ToString() + rotatorValues[2].ToString() + rotatorValues[3].ToString();
    }
}
