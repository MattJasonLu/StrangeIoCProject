using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PoolManagerEditor
{
    [MenuItem("Manager/Create GameObjectPoolConfig")]
    static void CreateGameObjectList()
    {
        GameObjectPoolList poolList = ScriptableObject.CreateInstance<GameObjectPoolList>();
        string path = PoolManager.PoolConfigPath;
        AssetDatabase.CreateAsset(poolList, path);
        AssetDatabase.SaveAssets();
    }
}

