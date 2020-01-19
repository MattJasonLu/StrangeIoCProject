using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationText : MonoBehaviour
{
    public string key;

    // Start is called before the first frame update
    void Start()
    {
        string value = LocalizationManager.Instance.GetValue(key);
        GetComponent<Text>().text = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
