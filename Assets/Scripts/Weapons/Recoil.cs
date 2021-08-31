using UnityEngine;
using System;

[Serializable]
public class Recoil
{
    [SerializeField] private float duration = default;
    [SerializeField] private float amplitude = default;
    [SerializeField] private AnimationCurve curve = default;

    public float Duration { get { return duration; } }
    public float Amplitude { get { return amplitude; } }
    public AnimationCurve Curve { get { return curve; } }
}
