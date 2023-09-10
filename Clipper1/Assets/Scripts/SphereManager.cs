using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
public GameObject[] spheres;
private Vector3 spherePosition;
public GameObject currentSphere;
private Quaternion sphereRotation;

    void Start()
    {
        currentSphere = GameObject.FindWithTag("Sphere");
        spherePosition = currentSphere.transform.position;
        sphereRotation = currentSphere.transform.rotation;
        StartCoroutine("switchTest");
    }

    public void switchSphere(int newSphereIndex)
    {
        Destroy(currentSphere);
        currentSphere = Instantiate(spheres[newSphereIndex], spherePosition, sphereRotation);
    }

    public IEnumerator switchTest()
    {
        yield return new WaitForSeconds(3);
        switchSphere(0);
    }
}
