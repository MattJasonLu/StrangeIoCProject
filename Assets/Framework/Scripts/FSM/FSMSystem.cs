using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 状态机系统类，有限状态机系统类
public class FSMSystem
{
    // 当前状态机下面有哪些状态
    private Dictionary<StateId, FSMState> states;
    // 状态机处于什么状态
    private FSMState currentState;

    public FSMState CurrentState
    {
        get
        {
            return currentState;
        }
    }

    public FSMSystem()
    {
        states = new Dictionary<StateId, FSMState>();
    }

    // 往状态机中添加状态
    public void AddState(FSMState state)
    {
        if (state == null)
        {
            Debug.LogError("The state you want to add is null.");
            return;
        }
        if (states.ContainsKey(state.Id))
        {
            Debug.LogError("The state " + state.Id + " you want to add has already been added.");
            return;
        }
        state.fsm = this;
        states.Add(state.Id, state);
    }

    // 从状态机里面移除状态
    public void DeleteState(FSMState state)
    {
        if (state == null)
        {
            Debug.LogError("The state " + state.Id + " you want to delete is not exist.");
            return;
        }
        states.Remove(state.Id);
    }

    // 控制状态直接的转换
    public void PerformTransition(Transition trans)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("NullTransition is not allowed for a real transition.");
            return;
        }
        StateId id = currentState.GetOutputState(trans);
        if (id == StateId.NullStateId)
        {
            Debug.Log("Transition is not to be happened! 没有符合条件的转换");
            return;
        }
        FSMState state;
        states.TryGetValue(id, out state);
        currentState.DoBeforeLeaving();
        currentState = state;
        currentState.DoBeforeEntering();
    }

    public void Start(StateId id)
    {
        FSMState state;
        bool isGet = states.TryGetValue(id, out state);
        if (isGet)
        {
            state.DoBeforeEntering();
            currentState = state;
        }
        else
        {
            Debug.LogError("The state is " + id + " is not exist in the fsm.");
        }
    }
}
