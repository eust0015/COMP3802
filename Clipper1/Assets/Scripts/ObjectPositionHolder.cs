using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionHolder : MonoBehaviour {
    
    // The starting position and rotation of the object
    public Vector3 initPosition = Vector3.zero;
    private Quaternion initRotation = Quaternion.identity;
    
    // Start is called before the first frame update
    void Start() {

        initPosition = this.transform.position;
        initRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update() {
     
        
        // If the object falls too far reset it back to its original position
        if (transform.position.y <= -1000) {
            
            Reset();
        }
    }

    public void Reset() {
        
        // Reset back to initial pos and rot
        transform.position = initPosition;
        transform.rotation = initRotation;
            
        // If the object has a rigid body reset its velocity to 0
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) {
                
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
