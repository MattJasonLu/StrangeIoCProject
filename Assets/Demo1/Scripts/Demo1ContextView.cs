using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1ContextView : ContextView
{
    void Awake()
    {
        // 启动StrangeIoC框架
        this.context = new Demo1Context(this);
    }
}
