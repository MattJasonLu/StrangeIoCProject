using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : View
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    [Inject]
    public AudioManager audioManager { get; set; }

    private Text scoreText;

    // 做初始化
    public void Init()
    {
        scoreText = GetComponentInChildren<Text>();
        Debug.Log(audioManager);
    }

    void Update()
    {
        transform.Translate(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)) * .2f);
        if (Input.GetMouseButtonDown(0))
        {
            PoolManager.Instance.GetInst("Bullet");
        }
    }

    void OnMouseDown()
    {
        // 加分
        Debug.Log("OnMouseDown");
        audioManager.Play("1");
        dispatcher.Dispatch(Demo1MediatorEvent.ClickDown);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
