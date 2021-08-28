using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class FindTarget : ActionNode
{
    private List<Player> enemies = new List<Player>();

    protected override void OnStart()
    {
        enemies.Clear();
        foreach (Player player in FindObjectsOfType<Player>())
            if (player != context.player)
                enemies.Add(player);
    }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        foreach (Player enemy in enemies)
        {
            if (context.player.CanSee(enemy.ownCollider))
            {
                blackboard.aimTarget = enemy.transform;
                return State.Success;
            }
        }

        return State.Failure;
    }
}
