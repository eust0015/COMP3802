using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FruitType {
    Apple,
    Banana,
    Orange
}

public class Fruit : MonoBehaviour {

    // Holds the type of the fruit
    public FruitType type;

    // Holds if the fruit is in the bowl or not
    private bool inBowl = false;

    public void OnTriggerEnter(Collider other) {

        // Check if the collider is from the fruit bowl
        FruitBowlController fbc = other.gameObject.GetComponent<FruitBowlController>();
        if(fbc != null && !inBowl) {

            inBowl = !inBowl;
            fbc.AddFruit(this);
        }
    }

    public void OnTriggerExit(Collider other) {
        
        // Check if the collider is from the fruit bowl
        FruitBowlController fbc = other.gameObject.GetComponent<FruitBowlController>();
        if(fbc != null && inBowl) {
            
            inBowl = !inBowl;
            fbc.RemoveFruit(this);
        }
    }
}
