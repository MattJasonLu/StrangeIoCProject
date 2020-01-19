using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    private static string audioTextPathPrefix = Application.dataPath + "\\Framework\\Resources\\";
    private const string audioTextPathMidfix = "audiolist";
    private const string audioTextPathPostfix = ".txt";

    public static string AudioTextPath
    {
        get
        {
            return audioTextPathPrefix + audioTextPathMidfix + audioTextPathPostfix;
        }
    }

    private Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();

    public bool isMute = false;

    public void Init()
    {
        LoadAudioClip();
    }

    private void LoadAudioClip()
    {
        audioClipDict = new Dictionary<string, AudioClip>();
        TextAsset ta = Resources.Load<TextAsset>(audioTextPathMidfix);
        string[] lines = ta.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] kv = line.Split(',');
            string key = kv[0];
            AudioClip value = Resources.Load<AudioClip>(kv[1]);
            audioClipDict.Add(key, value);
        }
    }

    public void Play(string name)
    {
        Play(name, Vector3.zero);
    }

    public void Play(string name, Vector3 postion)
    {
        if (isMute) return;
        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, postion);
        }
    }


}
