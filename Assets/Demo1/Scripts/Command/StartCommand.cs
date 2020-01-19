using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 开始命令
public class StartCommand : Command
{
    [Inject]
    public AudioManager audioManager { get; set; }

    // 当命令被执行时，默认会调用该方法
    public override void Execute()
    {
        // manager init
        audioManager.Init();
        PoolManager.Instance.Init();
        LocalizationManager.Instance.Init();
    }
}
