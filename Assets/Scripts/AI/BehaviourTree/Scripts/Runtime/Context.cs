using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviourTrees
{
    public class Context
    {
        public GameObject gameObject;
        public Transform transform;
        public NavMeshAgent agent;
        public Player player;

        public static Context CreateFromGameObject(GameObject gameObject)
        {
            Context context = new Context();
            context.gameObject = gameObject;
            context.transform = gameObject.transform;
            context.agent = gameObject.GetComponent<NavMeshAgent>();
            context.player = gameObject.GetComponent<Player>();

            return context;
        }
    }
} 