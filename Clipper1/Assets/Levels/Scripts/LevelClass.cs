using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "LevelClass", menuName = "ScriptableObjects/LevelClassScriptableObject", order = 1)]
public class LevelClass : ScriptableObject {
    
    [SerializeField]
   private String levelName;
    [SerializeField]
    private String sceneName;

    public string GetSceneName() {
        return sceneName;
    }
}
