using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class Aim : ActionNode
{
    private float aimTime = 1;

    private float startTime;
    private float startYaw;
    private float startPitch;

    protected override void OnStart()
    {
        startTime = Time.time;
        startYaw = context.player.yaw;
        startPitch = context.player.pitch;
    }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        if (Time.time - startTime > aimTime)
        {
            context.player.LookAt(blackboard.aimTarget.position);
            return State.Success;
        }

        context.player.LerpRotation(blackboard.aimTarget.position, startYaw, startPitch, Time.time - startTime / aimTime);

        return State.Running;
    }
}
