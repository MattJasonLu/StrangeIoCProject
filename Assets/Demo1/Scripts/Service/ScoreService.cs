using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreService : IScoreService
{
    public void RequestScore(string url)
    {
        Debug.Log("Request score from url : " + url);
        OnReceiveScore();
    }

    public void OnReceiveScore()
    {
        int score = Random.Range(0, 100);
        dispatcher.Dispatch(Demo1ServiceEvent.RequestScore, score);
    }

    public void UpdateScore(string url, int score)
    {
        Debug.Log("Update score to url : " + url + ", new score: " + score);
    }

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

}
