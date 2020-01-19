using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour
{
    private FSMSystem fsm;
    private GameObject player;

    public Transform[] waypoints;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InitFSM();
    }

    /// <summary>
    /// 初始化状态机
    /// </summary>
    void InitFSM()
    {
        fsm = new FSMSystem();
        PatrolState patrolState = new PatrolState(waypoints, gameObject, player);
        // 巡逻状态添加事件，发现玩家则进行追逐
        patrolState.AddTransition(Transition.SawPlayer, StateId.Chase);
        ChaseState chaseState = new ChaseState(gameObject, player);
        // 追逐状态添加事件，丢失玩家则进行巡逻
        chaseState.AddTransition(Transition.LostPlayer, StateId.Patrol);
        fsm.AddState(patrolState);
        fsm.AddState(chaseState);
        // 初始状态是巡逻状态
        fsm.Start(StateId.Patrol);
    }

    void Update()
    {
        fsm.CurrentState.DoUpdate();
    }
}
