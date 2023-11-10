using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyForging : MonoBehaviour
{
    public GameObject selector1;
    public GameObject selector2;
    public GameObject selector3;
    public GameObject hammer;
    public GameObject blankKey;
    public GameObject bronzeKey;
    public GameObject goldKey;
    public GameObject silverKey;
    public GameObject ironKey;
    public AudioClip anvilSound;
    public AudioSource audioSource;

    private int cycle = 1;
    public int handle = 0;
    public int shaft = 0;
    public int teeth = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other == hammer.GetComponent<BoxCollider>())
        {
            audioSource.PlayOneShot(anvilSound);

            switch(cycle)
            {
                case 2://shaft
                    switch(selector1.GetComponent<MaterialManager>().count)
                    {
                        case 1://silver
                            blankKey.transform.GetChild(0).gameObject.SetActive(false);
                            bronzeKey.transform.GetChild(0).gameObject.SetActive(false);
                            goldKey.transform.GetChild(0).gameObject.SetActive(false);
                            silverKey.transform.GetChild(0).gameObject.SetActive(true);
                            ironKey.transform.GetChild(0).gameObject.SetActive(false);
                            handle = 1;
                            break;
                        case 3://iron
                            blankKey.transform.GetChild(0).gameObject.SetActive(false);
                            bronzeKey.transform.GetChild(0).gameObject.SetActive(false);
                            goldKey.transform.GetChild(0).gameObject.SetActive(false);
                            silverKey.transform.GetChild(0).gameObject.SetActive(false);
                            ironKey.transform.GetChild(0).gameObject.SetActive(true);
                            handle = 2;
                            break;
                        case 2://gold
                            blankKey.transform.GetChild(0).gameObject.SetActive(false);
                            bronzeKey.transform.GetChild(0).gameObject.SetActive(false);
                            goldKey.transform.GetChild(0).gameObject.SetActive(true);
                            silverKey.transform.GetChild(0).gameObject.SetActive(false);
                            ironKey.transform.GetChild(0).gameObject.SetActive(false);
                            handle = 3;
                            break;
                        case 4://bronze
                            blankKey.transform.GetChild(0).gameObject.SetActive(false);
                            bronzeKey.transform.GetChild(0).gameObject.SetActive(true);
                            goldKey.transform.GetChild(0).gameObject.SetActive(false);
                            silverKey.transform.GetChild(0).gameObject.SetActive(false);
                            ironKey.transform.GetChild(0).gameObject.SetActive(false);
                            handle = 4;
                            break;
                    }
                    cycle++;
                    break;
                case 1://handle
                    switch (selector2.GetComponent<MaterialManager>().count)
                    {
                        case 1://silver
                            blankKey.transform.GetChild(1).gameObject.SetActive(false);
                            bronzeKey.transform.GetChild(1).gameObject.SetActive(false);
                            goldKey.transform.GetChild(1).gameObject.SetActive(false);
                            silverKey.transform.GetChild(1).gameObject.SetActive(true);
                            ironKey.transform.GetChild(1).gameObject.SetActive(false);
                            shaft = 1;
                            break;
                        case 3://iron
                            blankKey.transform.GetChild(1).gameObject.SetActive(false);
                            bronzeKey.transform.GetChild(1).gameObject.SetActive(false);
                            goldKey.transform.GetChild(1).gameObject.SetActive(false);
                            silverKey.transform.GetChild(1).gameObject.SetActive(false);
                            ironKey.transform.GetChild(1).gameObject.SetActive(true);
                            shaft = 2;
                            break;
                        case 2://gold
                            blankKey.transform.GetChild(1).gameObject.SetActive(false);
                            bronzeKey.transform.GetChild(1).gameObject.SetActive(false);
                            goldKey.transform.GetChild(1).gameObject.SetActive(true);
                            silverKey.transform.GetChild(1).gameObject.SetActive(false);
                            ironKey.transform.GetChild(1).gameObject.SetActive(false);
                            shaft = 3;
                            break;
                        case 4://bronze
                            blankKey.transform.GetChild(1).gameObject.SetActive(false);
                            bronzeKey.transform.GetChild(1).gameObject.SetActive(true);
                            goldKey.transform.GetChild(1).gameObject.SetActive(false);
                            silverKey.transform.GetChild(1).gameObject.SetActive(false);
                            ironKey.transform.GetChild(1).gameObject.SetActive(false);
                            shaft = 4;
                            break;
                    }
                    cycle++;
                    break;
                case 3://teeth
                    switch (selector3.GetComponent<MaterialManager>().count)
                    {
                        case 1://silver
                            blankKey.transform.GetChild(2).gameObject.SetActive(false);
                            bronzeKey.transform.GetChild(2).gameObject.SetActive(false);
                            goldKey.transform.GetChild(2).gameObject.SetActive(false);
                            silverKey.transform.GetChild(2).gameObject.SetActive(true);
                            ironKey.transform.GetChild(2).gameObject.SetActive(false);
                            teeth = 1;
                            break;
                        case 3://iron
                            blankKey.transform.GetChild(2).gameObject.SetActive(false);
                            bronzeKey.transform.GetChild(2).gameObject.SetActive(false);
                            goldKey.transform.GetChild(2).gameObject.SetActive(false);
                            silverKey.transform.GetChild(2).gameObject.SetActive(false);
                            ironKey.transform.GetChild(2).gameObject.SetActive(true);
                            teeth = 2;
                            break;
                        case 2://gold
                            blankKey.transform.GetChild(2).gameObject.SetActive(false);
                            bronzeKey.transform.GetChild(2).gameObject.SetActive(false);
                            goldKey.transform.GetChild(2).gameObject.SetActive(true);
                            silverKey.transform.GetChild(2).gameObject.SetActive(false);
                            ironKey.transform.GetChild(2).gameObject.SetActive(false);
                            teeth = 3;
                            break;
                        case 4://bronze
                            blankKey.transform.GetChild(2).gameObject.SetActive(false);
                            bronzeKey.transform.GetChild(2).gameObject.SetActive(true);
                            goldKey.transform.GetChild(2).gameObject.SetActive(false);
                            silverKey.transform.GetChild(2).gameObject.SetActive(false);
                            ironKey.transform.GetChild(2).gameObject.SetActive(false);
                            teeth = 4;
                            break;
                    }
                    cycle = 1;
                    break;
            }
        }
    }
}
