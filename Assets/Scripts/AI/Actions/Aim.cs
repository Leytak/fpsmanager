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
        startYaw = context.player.Yaw;
        startPitch = context.player.Pitch;
    }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        if (!blackboard.IsTargetAlive())
        {
            blackboard.aimTarget = null;
            return State.Failure;
        }

        if (Time.time - startTime > aimTime)
        {
            context.player.Yaw = blackboard.aimAxes.Yaw;
            context.player.Pitch = blackboard.aimAxes.Pitch;
            return State.Success;
        }

        float aimProgress = Time.time - startTime / aimTime;
        context.player.Yaw = Mathf.LerpAngle(startYaw, blackboard.aimAxes.Yaw, aimProgress);
        context.player.Pitch = Mathf.LerpAngle(startPitch, blackboard.aimAxes.Pitch, aimProgress);

        return State.Running;
    }
}
