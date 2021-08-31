using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
public class HitBox : MonoBehaviour
{
    [Serializable]
    public enum Type
    {
        Body,
        Head,
        Limb
    }

    [SerializeField] private Type type = default;

    private PlayerLife playerLife;

    private void Start()
    {
        playerLife = GetComponentInParent<PlayerLife>();

        Debug.Assert(playerLife, $"Non-assigned hitbox: {name}. It must be a child of a 'PlayerLife' object!");
    }

    public void Hit(int damage, Vector3 direction, Player damageDealer)
    {
        playerLife.Hit(damage, direction, damageDealer, type);
    }
}
