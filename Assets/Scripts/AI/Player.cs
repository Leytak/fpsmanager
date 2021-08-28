using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
public class Player : MonoBehaviour
{
    public NavMeshAgent agent { get; private set; }
    public Collider ownCollider { get; private set; }
    public Camera ownCamera { get; private set; }

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
                && !Physics.Linecast(transform.position, enemyCollider.transform.position, occlusionLayers);
    }
}
