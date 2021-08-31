using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int damage = default;
    [SerializeField] private float shootInterval = default;
    [SerializeField] private Recoil recoil = default;

    public float ShootInterval { get { return shootInterval; } }

    private Player player;

    private const float maxRange = 200;

    private void Start()
    {
        player = GetComponentInParent<Player>();

        Debug.Assert(player, $"Non-assigned Gun: {name}. It must be a child of a 'Player' object!");
    }

    public void Shoot()
    {
        Ray ray = new Ray(player.Camera.transform.position, player.Camera.transform.forward);
        
        foreach (RaycastHit hitInfo in Physics.RaycastAll(ray, maxRange))
        {
            if (hitInfo.collider.gameObject == gameObject) continue;

            if (hitInfo.collider.TryGetComponent(out HitBox hitBox))
            {
                hitBox.Hit(damage, ray.direction, player);
            }
            else
            {
                // TO DO: Implement wallbangs
            }
        }

        StartCoroutine(AnimateRecoil());
    }

    private IEnumerator AnimateRecoil()
    {
       Quaternion startRotation = transform.localRotation;

        for (float progress = 0; progress < 1; progress += Time.deltaTime / recoil.Duration)
        {
            transform.localRotation = startRotation * Quaternion.Euler(0, 0, recoil.Curve.Evaluate(progress) * -recoil.Amplitude);

            yield return null;
        }

        transform.localRotation = startRotation;
    }
}
