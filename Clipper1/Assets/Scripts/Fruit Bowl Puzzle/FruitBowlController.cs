using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBowlController : MonoBehaviour {

    // The target amount of each fruit in the bowl
    public int targetApples = -1;
    public int targetBananas = -1;
    public int targetOranges = -1;

    private HashSet<Fruit> fruitHashSet = new HashSet<Fruit>();
    
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

        int apples = 0;
        int bananas = 0;
        int oranges = 0;
        
        // Count each fruit type in the fruitHashset
        foreach (Fruit f in fruitHashSet) {

            switch (f.type) {
                case FruitType.Apple:
                    apples++;
                    break;
                case FruitType.Banana:
                    bananas++;
                    break;
                case FruitType.Orange:
                    oranges++;
                    break;
            }
        }

        Debug.Log(apples + ", " + bananas + ", " + oranges);
        return apples == targetApples && bananas == targetBananas && oranges == targetOranges;
    }
    
    public void AddFruit(Fruit f_) {

        fruitHashSet.Add(f_);
    }

    public void RemoveFruit(Fruit f_) {

        fruitHashSet.Remove(f_);
    }
}
