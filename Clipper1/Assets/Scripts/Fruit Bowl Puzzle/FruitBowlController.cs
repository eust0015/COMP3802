using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBowlController : MonoBehaviour {

    // The target amount of each fruit in the bowl
    public int targetApples = -1;
    public int targetBananas = -1;
    public int targetOranges = -1;
    
    // List of the planks to destroy when puzzle is solved
    public List<GameObject> planks;
    
    // The number of each type of fruit in the bowl at the moment
    private int[] fruitCounts;

    // Whether the puzzle has been solved or not
    private bool solved = false;
    
    // Start is called before the first frame update
    void Start() {

        fruitCounts = new int[Enum.GetNames(typeof(FruitType)).Length];
    }

    // Update is called once per frame
    void Update() {

        Debug.Log((fruitCounts[0]/4) + ", " + (fruitCounts[1]/4) + ", " + (fruitCounts[2]/4));
        
        if (!solved && FruitsMatchTargets()) {
            
            Debug.Log("Fruit Bowl Puzzle Solved");
            
            // Delete the collider that prevents the player from grabbing the key
            Destroy(this.GetComponent<MeshCollider>());

            // Delete the planks on the front of the fruit cabinet
            foreach (GameObject plank in planks) {

                plank.transform.parent = null;
                plank.AddComponent<Rigidbody>();
            }
            
            // Set solved to true
            solved = true;
        }
    }

    public bool FruitsMatchTargets() {

        return (fruitCounts[0] / 4) == targetApples && (fruitCounts[1] / 4) == targetBananas && (fruitCounts[2] / 4) == targetOranges;
    }
    
    public void AddFruit(FruitType fruitType) {

        fruitCounts[(int)fruitType]++;
    }

    public void RemoveFruit(FruitType fruitType) {
        
        fruitCounts[(int)fruitType]--;
    }
}
