using UnityEngine;
using UnityEngine.Serialization;

public class Bulge : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.05f;
    [SerializeField] private float frequency = 0.5f;
    [SerializeField] private float midScale;
    
    // Start is called before the first frame update
    void Start()
    {
        midScale = transform.localScale.x + amplitude;
    }

    // Update is called once per frame
    void Update()
    {
        float newScale = midScale + amplitude * Mathf.Sin(frequency * Time.time);
        transform.localScale = new Vector3(
            newScale,
            newScale,
            newScale
        );
    }
}