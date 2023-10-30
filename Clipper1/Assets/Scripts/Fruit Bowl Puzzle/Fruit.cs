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

    public void OnTriggerEnter(Collider other) {

        // Check if the collider is from the fruit bowl
        FruitBowlController fbc = other.gameObject.GetComponent<FruitBowlController>();
        if(fbc != null) {
            
            fbc.AddFruit(type);
        }
    }

    public void OnTriggerExit(Collider other) {
        
        // Check if the collider is from the fruit bowl
        FruitBowlController fbc = other.gameObject.GetComponent<FruitBowlController>();
        if(fbc != null) {
            
            fbc.RemoveFruit(type);
        }
    }
}
