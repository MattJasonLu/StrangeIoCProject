using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Text;
using System.IO;

public class AudioWindowEditor : EditorWindow
{
    [MenuItem("Manager/AudioManager")]
    static void CreateWindow()
    {
        Debug.Log("SHOW");
        Rect rect = new Rect(400, 400, 400, 400);
        /*AudioWindowEditor window = EditorWindow.GetWindowWithRect(typeof(AudioWindowEditor), rect) as AudioWindowEditor;*/
        AudioWindowEditor window = EditorWindow.GetWindow<AudioWindowEditor>("音效管理");
        window.Show();
    }

    private string audioPath;
    private string audioName;
    private Dictionary<string, string> audioDict = new Dictionary<string, string>();

    void Awake()
    {
        LoadAudioList();
    }

    void OnGUI()
    { 
        /*// 前置标签加文字
        EditorGUILayout.TextField("输入文字", text);
        // 初始文字
        GUILayout.TextField("输入文字2");*/
        GUILayout.BeginHorizontal();
        GUILayout.Label("音效名称");
        GUILayout.Label("音效路径");
        GUILayout.Label("操作");
        GUILayout.EndHorizontal();
        foreach (string key in audioDict.Keys)
        {
            string val;
            audioDict.TryGetValue(key, out val);
            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(val);
            if (GUILayout.Button("删除"))
            {
                audioDict.Remove(key);
                SaveAudioList();
                return;
            }
            GUILayout.EndHorizontal();
        }

        audioName = EditorGUILayout.TextField("名字", audioName);
        audioPath = EditorGUILayout.TextField("音效路径", audioPath);
        if (GUILayout.Button("添加音效"))
        {
            object o = Resources.Load(audioPath);
            if (o == null)
            {
                Debug.LogWarning("音效不存在于" + audioPath + "，添加不成功");
                audioPath = "";
            }
            else
            {
                if (!audioDict.ContainsKey(audioName))
                {
                    audioDict.Add(audioName, audioPath);
                    SaveAudioList();
                }
                else
                {
                    Debug.LogWarning("名字已经存在，请修改");
                }
            }
        }

    }

    private void OnInspectorUpdate()
    {
        LoadAudioList();
    }

    private void SaveAudioList()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string key in audioDict.Keys)
        {
            string val;
            audioDict.TryGetValue(key, out val);
            sb.Append(key + "," + val + "\n");
        }

        
        File.WriteAllText(AudioManager.AudioTextPath, sb.ToString());
    }

    private void LoadAudioList()
    {
        audioDict = new Dictionary<string, string>();
        if (!File.Exists(AudioManager.AudioTextPath)) return;
        string[] lines = File.ReadAllLines(AudioManager.AudioTextPath);
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] kv = line.Split(',');
            audioDict.Add(kv[0], kv[1]);
        }
    }
}
