using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class Aim : ActionNode
{
    private float aimTime = 0.25f;
    private float startTime;

    protected override void OnStart()
    {
        startTime = Time.time;
    }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        if (Time.time - startTime > aimTime)
        {
            return State.Success;
        }

        return State.Running;
    }
}
