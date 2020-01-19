using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameObjectPool
{
    [SerializeField]
    public string name;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int maxAmount;

    [NonSerialized]
    private List<GameObject> goList = new List<GameObject>();

    /// <summary>
    /// 表示从资源池中获取一个实例
    /// </summary>
    public GameObject GetInst()
    {
        foreach (GameObject go in goList)
        {
            if (go.activeInHierarchy == false)
            {
                go.SetActive(true);
                return go;
            }
        }
        // 到达最大容量
        if (goList.Count >= maxAmount)
        {
            GameObject.Destroy(goList[0]);
            goList.RemoveAt(0);
        }
        GameObject temp = GameObject.Instantiate(prefab);
        goList.Add(temp);
        return temp;
    }
}
