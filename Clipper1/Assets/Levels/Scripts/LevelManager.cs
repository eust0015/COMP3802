using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    private LevelClass currentLevel;
    
    [Header("This is a list of all levels/rooms (LevelData) that exist in the clipper. \n(Prefab should only be edited to include all levels)")]
    public List<GameObject> levels = new List<GameObject>();

    public void Start() {

        if (GameObject.FindWithTag("LevelData").GetComponent<LevelClass>()) {
            currentLevel = GameObject.FindWithTag("LevelData").GetComponent<LevelClass>();
        } else {
            Debug.LogError("No LevelData Object in Scene!");
        }
    }

    public void NextLevel() {

        Debug.Log("Changing to Scene: " + currentLevel.GetNextScene().name);
        SceneManager.LoadScene(currentLevel.GetNextScene().name);
    }
}
