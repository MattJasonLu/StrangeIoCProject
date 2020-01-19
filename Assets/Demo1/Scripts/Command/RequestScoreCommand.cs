using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestScoreCommand : EventCommand
{
    [Inject]
    public IScoreService scoreService { get; set; }

    [Inject]
    public ScoreModel scoreModel { get; set; }

    public override void Execute()
    {
        Retain(); // 对象不销毁
        // 请求分数结束后注册到OnComplete方法上
        scoreService.dispatcher.AddListener(Demo1ServiceEvent.RequestScore, OnComplete);
        scoreService.RequestScore("http://xx/xxx/xxx");
    }

    private void OnComplete(IEvent evt) // IEvent存储的就是参数
    {
        Debug.Log("request score complete " + evt.data);
        scoreService.dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore, OnComplete);
        scoreModel.Score = (int) evt.data;
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange, evt.data);


        Release(); // 销毁对象
    }
}
