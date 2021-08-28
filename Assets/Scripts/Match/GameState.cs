using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private List<Player> offenseTeam = default;
    [SerializeField] private List<Player> defenseTeam = default;

    public List<Player> GetEnemies(Player player)
    {
        if (offenseTeam.Contains(player))
            return defenseTeam;

        if (defenseTeam.Contains(player))
            return offenseTeam;

        Debug.LogWarning("No enemies were found for " + player.name);
        return null;
    }

    public Player GetEnemy(Player player)
    {
        var enemies = GetEnemies(player);

        if (enemies == null) return null;

        foreach (var enemy in GetEnemies(player))
        {
            Vector3 direction = player.transform.position - enemy.transform.position;
            float angle = Vector3.Angle(Vector3.forward, direction);
            if (angle <= 45)
                return enemy;
        }

        return null;
    }
}
