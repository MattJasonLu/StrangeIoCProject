using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager
{
    private static LocalizationManager _instance;
    public static LocalizationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LocalizationManager();
            }
            return _instance;
        }
    }

    public const string Chinese = "Localization/Chinese";
    public const string English = "Localization/English";

    public const string Language = Chinese;

    private Dictionary<string, string> dict = new Dictionary<string, string>();

    public LocalizationManager()
    {
        // 将文件内容添加到字典
        dict = new Dictionary<string, string>();
        TextAsset ta = Resources.Load<TextAsset>(Language);
        string[] lines = ta.text.Split('\n');
        foreach (string line in lines)
        {
            if (!string.IsNullOrEmpty(line))
            {
                string[] kv = line.Split('=');
                dict.Add(kv[0], kv[1]);
            }
        }
    }

    public void Init()
    {
        // Do nothing
    }

    public string GetValue(string key)
    {
        string value;
        dict.TryGetValue(key, out value);
        return value;
    }
}
