using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour {
    
    public bool locked = true;

    protected void Lock() {
        
        // Lock the door
        locked = true;
    }

    protected void Unlock() {
        
        // Unlock the door
        locked = false;
        Debug.Log("Successfully Entered Code");
    }

    protected virtual void UpdateLockStatus(bool shouldLock) {

        if (shouldLock) {
            Lock();
        } else {
            Unlock();
        }
    }
}
