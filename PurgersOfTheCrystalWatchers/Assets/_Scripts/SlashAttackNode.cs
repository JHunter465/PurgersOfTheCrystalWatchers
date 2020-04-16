using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class SlashAttackNode : BaseNode
    {
        private int time = 0;
        private int holdTime;
        public SlashAttackNode(BlackBoard bb, int _holdTime)
        {
            this.blackBoard = bb;
            this.holdTime = _holdTime;
        }

        public override BehaviourTreeStatus Tick()
        {
            //blackBoard.Boss.transform.LerpTransform(blackBoard.Boss, new Vector3(0, 0, 0), 5);
            time++;
            if(time > holdTime)
            {
                Debug.Log("Lets go");
                time = 0;
                return BehaviourTreeStatus.Succes;
            }
            else
                return BehaviourTreeStatus.Running;
        }
    }
}
