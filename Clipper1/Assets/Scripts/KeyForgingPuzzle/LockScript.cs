using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    private bool locked = true;
    public GameObject lockBottom;
    public GameObject lockTop;
    public GameObject key;
    public int keyHandle = 2;
    public int keyShaft = 2;
    public int keyTeeth = 2;
    public float fadeTime = 10.0f;
    public AudioClip lockSound;
    public AudioClip solveSound;
    public AudioSource audioSource;
    private float soundDelay;

    private void Start()
    {
        soundDelay = lockSound.length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == key.GetComponent<SphereCollider>())
        {
            if(key.GetComponent<KeyForging>().handle == keyHandle && key.GetComponent<KeyForging>().shaft == keyShaft && key.GetComponent<KeyForging>().teeth == keyTeeth)
            {
                PuzzleManager.SetPuzzleSolved(transform.root);
                audioSource.PlayOneShot(lockSound);
                locked = false;
                lockBottom.GetComponent<Rigidbody>().useGravity = true;
                lockBottom.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                while(soundDelay > 0)
                {
                    soundDelay -= Time.deltaTime;
                }
                audioSource.PlayOneShot(solveSound);
                PuzzleManager.SetPuzzleSolved(transform.root);
                //lockBottom.GetComponent<MeshRenderer>().material.color = Color.Lerp(lockBottom.GetComponent<MeshRenderer>().material.color, lockBottom.GetComponent<MeshRenderer>().material.color, fadeTime * Time.deltaTime);
                //lockTop.GetComponent<MeshRenderer>().material.color = Color.Lerp(lockTop.GetComponent<MeshRenderer>().material.color, lockTop.GetComponent<MeshRenderer>().material.color, fadeTime * Time.deltaTime);
            }
        }
    }


}
