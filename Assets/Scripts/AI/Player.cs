using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform viewPoint = default;

    public NavMeshAgent agent { get; private set; }
    public Collider ownCollider { get; private set; }
    public Camera ownCamera { get; private set; }

    public float yaw
    {
        get { return transform.rotation.eulerAngles.y; }
        set { transform.rotation = Quaternion.Euler(0, value, 0); }
    }

    public float pitch
    {
        get { return viewPoint.localRotation.eulerAngles.x; }
        set { viewPoint.localRotation = Quaternion.Euler(value, 0, 0); }
    }

    private int occlusionLayers;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ownCollider = GetComponent<Collider>();
        ownCamera = GetComponentInChildren<Camera>();

        occlusionLayers = LayerMask.GetMask("Default");
    }

    public bool CanSee(Collider enemyCollider)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(ownCamera);

        return GeometryUtility.TestPlanesAABB(planes, enemyCollider.bounds)
                && !Physics.Linecast(viewPoint.position, enemyCollider.transform.position, occlusionLayers);
    }

    public void LookAt(Vector3 target)
    {
        Vector3 direction = target - viewPoint.position;

        yaw = AircraftAxes.Yaw(direction);
        pitch = AircraftAxes.Pitch(direction);
    }

    public void LerpRotation(Vector3 target, float startYaw, float startPitch, float lerpValue)
    {
        Vector3 direction = target - viewPoint.position;

        yaw = Mathf.LerpAngle(startYaw, AircraftAxes.Yaw(direction), lerpValue);
        pitch = Mathf.LerpAngle(startPitch, AircraftAxes.Pitch(direction), lerpValue);
    }
}
