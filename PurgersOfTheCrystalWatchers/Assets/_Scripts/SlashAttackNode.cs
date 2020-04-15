using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class SlashAttackNode : BaseNode
    {
        public SlashAttackNode(BlackBoard bb)
        {
            this.blackBoard = bb;
        }

        public override BehaviourTreeStatus Tick()
        {
            //blackBoard.Boss.transform.position += Vector3.left * 10;
            return BehaviourTreeStatus.Succes;
        }
    }
}
