using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    [System.Serializable]
    public class Blackboard
    {
        public Vector3 moveToPosition;
        public Transform aimTarget;

        public bool IsTargetAlive()
        {
            return aimTarget != null && aimTarget.TryGetComponent(out PlayerLife playerLife) && playerLife.IsAlive;
        }
    }
}