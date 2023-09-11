using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClass : MonoBehaviour {

    [SerializeField]
    private String levelName;
    [SerializeField]
    private UnityEditor.SceneAsset sceneAsset;
    [SerializeField]
    private UnityEditor.SceneAsset nextLevelSceneAsset;

    public UnityEditor.SceneAsset GetNextScene() {
        return nextLevelSceneAsset;
    }
}
