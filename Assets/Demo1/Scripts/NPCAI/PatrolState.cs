using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    private int targetWaypoint;
    private Transform[] waypoints;
    private GameObject npc;
    private Rigidbody npcRgd;
    private GameObject player;

    public PatrolState(Transform[] wp, GameObject npc, GameObject player)
    {
        stateId = StateId.Patrol;
        targetWaypoint = 0;
        waypoints = wp;
        this.npc = npc;
        npcRgd = npc.GetComponent<Rigidbody>();
        this.player = player;
    }

    public override void DoBeforeEntering()
    {
        Debug.Log("Entering state " + Id);
    }

    public override void DoUpdate()
    {
        CheckTransition();
        PatrolMove();
    }

    // 检查转换条件
    private void CheckTransition()
    {
        if (Vector3.Distance(player.transform.position, npc.transform.position) < 5)
        {
            // 触发事件
            fsm.PerformTransition(Transition.SawPlayer);
        }
    }

    private void PatrolMove()
    {
        npcRgd.velocity = npc.transform.forward * 3;
        Transform targetTrans = waypoints[targetWaypoint];
        Vector3 targetPosition = targetTrans.position;
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(targetPosition);
        if (Vector3.Distance(npc.transform.position, targetPosition) < 1)
        {
            targetWaypoint++;
            targetWaypoint %= waypoints.Length;
        }
    }
}
