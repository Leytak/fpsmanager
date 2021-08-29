﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _viewPoint = default;

    public NavMeshAgent Agent { get; private set; }
    public Collider Collider { get; private set; }
    public Camera Camera { get; private set; }
    public Gun Gun { get; private set; }

    public float Yaw
    {
        get { return transform.rotation.eulerAngles.y; }
        set { transform.rotation = Quaternion.Euler(0, value, 0); }
    }

    public float Pitch
    {
        get { return _viewPoint.localRotation.eulerAngles.x; }
        set { _viewPoint.localRotation = Quaternion.Euler(value, 0, 0); }
    }

    private int occlusionLayers;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Collider = GetComponent<Collider>();
        Camera = GetComponentInChildren<Camera>();
        Gun = GetComponentInChildren<Gun>();

        occlusionLayers = LayerMask.GetMask("Default");
    }

    public bool CanSee(Collider enemyCollider)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera);

        return GeometryUtility.TestPlanesAABB(planes, enemyCollider.bounds)
                && !Physics.Linecast(_viewPoint.position, enemyCollider.transform.position, occlusionLayers);
    }

    public void LookAt(Vector3 target)
    {
        Vector3 direction = target - _viewPoint.position;

        Yaw = AircraftAxes.Yaw(direction);
        Pitch = AircraftAxes.Pitch(direction);
    }

    public void LerpRotation(Vector3 target, float startYaw, float startPitch, float lerpValue)
    {
        Vector3 direction = target - _viewPoint.position;

        Yaw = Mathf.LerpAngle(startYaw, AircraftAxes.Yaw(direction), lerpValue);
        Pitch = Mathf.LerpAngle(startPitch, AircraftAxes.Pitch(direction), lerpValue);
    }
}
