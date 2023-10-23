using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSphereToolTipScaler : MonoBehaviour {

    // The scale factor
    public float scaleFactor = 0.1f;

    // The y offset of the tooltip in relation to the sphereUI
    public float tooltipYOffset = 1.0f;
    
    // The players VR object
    private GameObject xrOrigin;
    
    // The tooltip object
    private GameObject tooltip;

    // Start is called before the first frame update
    void Start() {
        
        // Set the xrOrigin gameobject
        xrOrigin = GameObject.FindWithTag("XROrigin");
        
        // Set the tooltip game obect
        foreach (Transform trans in this.transform) {
            if (trans.CompareTag("SphereTooltip")) {
                tooltip = trans.gameObject;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
        // Scale the tooltip based on the distance to the player
        float distToPlayer = Vector3.Distance(tooltip.transform.position, xrOrigin.transform.position);
        float scale = Mathf.Max(1.0f, distToPlayer * scaleFactor);
        tooltip.transform.localScale = new Vector3(scale, scale, scale);

        Vector3 tooltipPos = new Vector3(transform.position.x, transform.position.y + tooltipYOffset, transform.position.z);
        tooltip.transform.position = tooltipPos;
    }
}
