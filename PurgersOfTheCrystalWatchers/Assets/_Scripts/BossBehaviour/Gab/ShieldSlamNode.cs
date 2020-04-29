using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class ShieldSlamNode : BaseNode
    {
        private int time = 0;
        private int holdTime;
        public ShieldSlamNode(BlackBoard bb, int _holdTime)
        {
            this.blackBoard = bb;
            this.holdTime = _holdTime;
        }

        public override BehaviourTreeStatus Tick()
        {
            time++;

            if (time > holdTime)
            {
                Debug.Log("Round");
                time = 0;

                return BehaviourTreeStatus.Succes;
            }
            else
                return BehaviourTreeStatus.Running;
        }
    }
}
