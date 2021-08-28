using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class Stop : ActionNode
{
    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        context.agent.ResetPath();

        return State.Success;
    }
}
