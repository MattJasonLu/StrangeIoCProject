using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 处理CubeView与外界的交互
public class CubeMediator : Mediator
{
    [Inject]
    public CubeView cubeView { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)] // 全局的Dispatcher
    public IEventDispatcher dispatcher { get; set; }

    public override void OnRegister()
    {
        cubeView.Init();
        // 注册改变分数事件
        dispatcher.AddListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.AddListener(Demo1MediatorEvent.ClickDown, OnClickDown);

        // 通过Dispatcher发起请求分数命令
        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.RemoveListener(Demo1MediatorEvent.ClickDown, OnClickDown);
    }

    public void OnScoreChange(IEvent evt)
    {
        cubeView.UpdateScore((int) evt.data);
    }


    public void OnClickDown()
    {
        dispatcher.Dispatch(Demo1CommandEvent.UpdateScore);
    }
}
