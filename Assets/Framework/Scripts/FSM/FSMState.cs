using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 有哪些状态转换的条件
public enum Transition
{
    NullTransition = 0,
    SawPlayer,  // 看到玩家
    LostPlayer   // 看不到玩家
}

// 状态ID，是每一个状态的唯一标识，一个状态有一个stateId，而且跟其他状态不可以重复
public enum StateId
{
    NullStateId = 0,
    Patrol,          // 巡逻
    Chase           // 追逐
}

public abstract class FSMState
{
    protected StateId stateId;
    public StateId Id
    {
        get
        {
            return stateId;
        }
    }

    protected Dictionary<Transition, StateId> map = new Dictionary<Transition, StateId>();

    public FSMSystem fsm;
    
    public void AddTransition(Transition trans, StateId id)
    {
        if (trans == Transition.NullTransition || id == StateId.NullStateId)
        {
            Debug.LogError("Transition or stateid is null!");
            return;
        }
        if (map.ContainsKey(trans))
        {
            Debug.LogError("State " + stateId + " is already has transition " + trans);
            return;
        }
        map.Add(trans, id);
    }

    public void DeleteTransition(Transition trans)
    {
        if (map.ContainsKey(trans) == false)
        {
            Debug.LogWarning("The transition " + trans + " you want to delete is not exist in map");
            return;
        }
        map.Remove(trans);
    }

    // 根据传递过来的转换条件，判断一下是否可以发生转换
    public StateId GetOutputState(Transition trans)
    {
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }
        return StateId.NullStateId;
    }

    // 在进入当前状态之前需要做的事情
    public virtual void DoBeforeEntering() { }

    // 在进入当前状态之前需要做的事情
    public virtual void DoBeforeLeaving() { }
    // 当状态机处于当前状态时候会一直调用
    public abstract void DoUpdate();
}
