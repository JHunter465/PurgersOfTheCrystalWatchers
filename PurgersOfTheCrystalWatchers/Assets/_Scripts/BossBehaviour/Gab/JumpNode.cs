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
        private AnimationData animationData;

        public JumpNode(BlackBoard bb, AnimationData _animationData, int _holdTime)
        {
            this.blackBoard = bb;
            this.holdTime = _holdTime;
            this.animationData = _animationData;
            //blackBoard.AnimationController.SetBool(animatorBoolName, true);
        }

        public override BehaviourTreeStatus Tick()
        {
            //blackBoard.Boss.transform.LerpTransform(blackBoard.Boss, new Vector3(10, 10, 10), 5);
            float duration = blackBoard.AnimationController.GetCurrentAnimatorStateInfo(0).length;

            if (duration > 0)
            {
                //Now we can do our code that can be used at the same time as the animation
                duration--;
                Debug.Log("jump");
                blackBoard.BossBody.AddRelativeForce(Vector3.up * 100);
                return BehaviourTreeStatus.Running;
            }
            else
            {
                //Alright, animation is done, we move on to the next node
                blackBoard.AnimationController.SetBool(animationData.AnimationBoolName, true);
                return BehaviourTreeStatus.Succes;
            }
        }
    }
}
