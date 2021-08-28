using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    public class Repeat : DecoratorNode
    {

        public bool restartOnSuccess = true;
        public bool restartOnFailure = false;

        protected override void OnStart() { }

        protected override void OnStop() { }

        protected override State OnUpdate()
        {
            switch (child.Update())
            {
                case State.Running:
                    break;
                case State.Failure:
                    return restartOnFailure ? State.Running : State.Failure;
                case State.Success:
                    return restartOnSuccess ? State.Running : State.Success;
            }
            return State.Running;
        }
    }
}
