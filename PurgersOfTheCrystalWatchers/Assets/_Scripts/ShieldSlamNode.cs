using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class ShieldSlamNode : BaseNode
    {
        public ShieldSlamNode(BlackBoard bb)
        {
            this.blackBoard = bb;
        }

        public override BehaviourTreeStatus Tick()
        {
            return BehaviourTreeStatus.Succes;
        }
    }
}
