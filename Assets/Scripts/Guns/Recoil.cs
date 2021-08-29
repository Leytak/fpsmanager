using UnityEngine;
using System;

[Serializable]
public class Recoil
{
    [SerializeField] private float _duration = default;
    [SerializeField] private float _amplitude = default;
    [SerializeField] private AnimationCurve _curve = default;

    public float Duration { get { return _duration; } }
    public float Amplitude { get { return _amplitude; } }
    public AnimationCurve Curve { get { return _curve; } }
}
