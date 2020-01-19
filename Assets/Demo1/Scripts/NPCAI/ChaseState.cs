using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    private GameObject npc;
    private Rigidbody npcRgd;
    private GameObject player;
    public ChaseState(GameObject npc, GameObject player)
    {
        stateId = StateId.Chase;
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
        ChaseMove();
    }

    private void CheckTransition()
    {
        if (Vector3.Distance(player.transform.position, npc.transform.position) > 10)
        {
            // 触发事件
            fsm.PerformTransition(Transition.LostPlayer);
        }
    }

    private void ChaseMove()
    {
        npcRgd.velocity = npc.transform.forward * 5;
        Vector3 targetposition = player.transform.position;
        targetposition.y = npc.transform.position.y;
        npc.transform.LookAt(targetposition);
    }
}
