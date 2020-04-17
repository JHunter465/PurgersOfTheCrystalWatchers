using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class JumpNode : BaseNode
    {

        private int time = 0;
        private int holdTime;

        public JumpNode(BlackBoard bb, string animatorBoolName, int _holdTime)
        {
            this.blackBoard = bb;
            this.holdTime = _holdTime;
            //blackBoard.AnimationController.SetBool(animatorBoolName, true);
        }

        public override BehaviourTreeStatus Tick()
        {
            //blackBoard.Boss.transform.LerpTransform(blackBoard.Boss, new Vector3(10, 10, 10), 5);
            time++;

            if (time < holdTime)
            {

                Debug.Log("jump");
                blackBoard.BossBody.AddRelativeForce(Vector3.up * 100);

                return BehaviourTreeStatus.Running;
            }
            else
            {
                time = 0;
                return BehaviourTreeStatus.Succes;
            }


        }
    }
}
