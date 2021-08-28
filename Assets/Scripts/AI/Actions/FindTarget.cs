using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class FindTarget : ActionNode
{
    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        return State.Failure;
    }
}
