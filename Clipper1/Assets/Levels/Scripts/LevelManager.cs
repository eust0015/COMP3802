using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    private LevelClass currentLevel;
    
    [Header("This is a list of all levels/rooms (LevelData) that exist in the clipper. \n(Prefab should only be edited to include all levels)")]
    public List<LevelClass> levels = new List<LevelClass>();

    // Switches to the desired scene based on the scenes index in the levels list/array.
    public void SwitchLevel(int newLevelIndex) {

        SceneManager.LoadScene(levels[newLevelIndex].GetSceneName());
    }
}
