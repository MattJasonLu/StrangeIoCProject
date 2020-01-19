using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveForTime : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnEnable()
    {
        Invoke("Deactive", 3);
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
