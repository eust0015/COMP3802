using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.1f;
    [SerializeField] private float frequency = 0.5f;
    [SerializeField] private float initialX;
    [SerializeField] private float initialY;
    [SerializeField] private float initialZ;
    
    // Start is called before the first frame update
    void Start()
    {
        var position = transform.position;
        initialX = position.x;
        initialY = position.y;
        initialZ = position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            initialX,
            initialY + amplitude * Mathf.Sin(frequency * Time.time),
            initialZ
        );
    }
}
