using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public enum BehaviourTreeStatus
    {
        Failure = 0,
        Running = 1,
        Succes = 2,
    }

    public abstract class BaseNode
    {
        protected BlackBoard blackBoard;

        public abstract BehaviourTreeStatus Tick();
    }
}
