using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour {

    [SerializeField]
    private float rotationTime = 10;
    
    public GameObject[] spheres;
    private Vector3 spherePosition;
    public GameObject currentSphere;
    private Quaternion sphereRotation;

    private int currentIndex = 0;

    void Start()
    {
        currentSphere = GameObject.FindWithTag("Sphere");
        spherePosition = currentSphere.transform.position;
        sphereRotation = currentSphere.transform.rotation;
        //StartCoroutine("switchTest");
    }

    public void switchSphere(int newSphereIndex)
    {
        Destroy(currentSphere);
        currentSphere = Instantiate(spheres[newSphereIndex], spherePosition, sphereRotation);
    }

    public IEnumerator switchTest() {

        while (true) {
            yield return new WaitForSeconds(3);
            
            currentIndex++;
            if (currentIndex >= spheres.Length) {

                currentIndex = 0;
            }
            
            switchSphere(currentIndex);
        }
    }
}
