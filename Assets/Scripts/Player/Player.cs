using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Collider), typeof(PlayerLife))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform viewPoint = default;

    public NavMeshAgent Agent { get; private set; }
    public Collider Collider { get; private set; }
    public Camera Camera { get; private set; }
    public Gun Gun { get; private set; }
    public Transform ViewPoint { get { return viewPoint; } }

    public float Yaw
    {
        get { return transform.rotation.eulerAngles.y; }
        set { transform.rotation = Quaternion.Euler(0, value, 0); }
    }

    public float Pitch
    {
        get { return viewPoint.localRotation.eulerAngles.x; }
        set { viewPoint.localRotation = Quaternion.Euler(value, 0, 0); }
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
                && !Physics.Linecast(viewPoint.position, enemyCollider.transform.position, occlusionLayers);
    }
}
