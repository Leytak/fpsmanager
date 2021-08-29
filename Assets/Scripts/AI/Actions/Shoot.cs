using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class Shoot : ActionNode
{
    private float startTime;

    protected override void OnStart()
    {
        context.player.Gun.Shoot();
        startTime = Time.time;
    }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        if (Time.time - startTime > context.player.Gun.ShootInterval)
        {
            return State.Success;
        }

        context.player.LookAt(blackboard.aimTarget.position);

        return State.Running;
    }
}
