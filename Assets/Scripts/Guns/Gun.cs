using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int _damage = default;
    [SerializeField] private float _shootInterval = default;
    [SerializeField] private Recoil _recoil = default;

    public float ShootInterval { get { return _shootInterval; } }

    public void Shoot()
    {
        StartCoroutine(AnimateRecoil());
    }

    private IEnumerator AnimateRecoil()
    {
       Quaternion startRotation = transform.localRotation;

        for (float progress = 0; progress < 1; progress += Time.deltaTime / _recoil.Duration)
        {
            transform.localRotation = startRotation * Quaternion.Euler(0, 0, _recoil.Curve.Evaluate(progress) * -_recoil.Amplitude);

            yield return null;
        }

        transform.localRotation = startRotation;
    }
}
