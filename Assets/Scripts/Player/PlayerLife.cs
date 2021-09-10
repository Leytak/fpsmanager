using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerLife : MonoBehaviour
{
    private const int maxHealth = 100;
    private const int maxArmor = 100;

    private int currentHealth;
    private int currentArmor;

    public int Health { get { return currentHealth; } }
    public int Armor { get { return currentArmor; } }
    public bool IsAlive { get { return currentHealth > 0; } }

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();

        Respawn();
    }

    public void Respawn()
    {
        currentHealth = maxHealth;
        currentArmor = maxArmor;
    }

    public void Hit(int damage, Vector3 direction, Player damageDealer, HitBox.Type hitboxType)
    {
        Debug.Log($"{damageDealer.name} dealth {damage} damage to {player.name} ({hitboxType.ToString()})");

        damage = Mathf.Min(damage, currentHealth);
        currentHealth -= damage;

        if (currentHealth <= 0) Die(direction, damageDealer);
    }

    public void Die(Vector3 direction, Player killer)
    {
        Debug.Log($"{killer.name} killed {player.name}");

        Destroy(gameObject);
    }
}
