using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTrees;

public class FindTarget : ActionNode
{
    private List<Player> enemies = new List<Player>();

    private const float maxRange = 5;  // TO DO: calculate it from player's skill

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
            if (context.player.CanSee(enemy.Collider))
            {
                blackboard.aimTarget = enemy.transform;
                AircraftAxes exactAxes = new AircraftAxes(enemy.transform.position - context.player.ViewPoint.position);
                blackboard.aimAxes = new AircraftAxes(exactAxes.Yaw + DiceRoller.Roll(GetMaxRange(context.player.Yaw, exactAxes.Yaw)),
                                                      exactAxes.Pitch + DiceRoller.Roll(GetMaxRange(context.player.Pitch, exactAxes.Pitch)));
                return State.Success;
            }
        }

        return State.Failure;
    }

    private float GetMaxRange(float startAngle, float endAngle)
    {
        float delta = Mathf.DeltaAngle(startAngle, endAngle);
        return Mathf.Min(delta, maxRange);
    }
}
