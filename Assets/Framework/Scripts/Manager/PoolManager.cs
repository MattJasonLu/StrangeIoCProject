using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    private static PoolManager _instance;

    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PoolManager();
            }
            return _instance;
        }
    }

    private static string poolConfigPathPrefix = Application.dataPath + "\\Framework\\Resources\\";
    private const string poolConfigPathMidfix = "gameobjectpool";
    private const string poolConfigPathPostfix = ".asset";

    public static string PoolConfigPath
    {
        get
        {
            return poolConfigPathPrefix + poolConfigPathMidfix + poolConfigPathPostfix;
        }
    }

    private Dictionary<string, GameObjectPool> poolDict;

    private PoolManager()
    {
        // 创建池
        GameObjectPoolList poolList = Resources.Load<GameObjectPoolList>(poolConfigPathMidfix);
        poolDict = new Dictionary<string, GameObjectPool>();
        // 添加字典
        foreach (GameObjectPool pool in poolList.poolList)
        {
            poolDict.Add(pool.name, pool);
        }
    }

    public void Init()
    {
        // Do nothing
    }

    public GameObject GetInst(string poolName)
    {
        GameObjectPool pool;
        if (poolDict.TryGetValue(poolName, out pool))
        {
            return pool.GetInst();
        }
        Debug.LogWarning("Pool : " + poolName + " is not exits!!!");
        return null;
    }
}
