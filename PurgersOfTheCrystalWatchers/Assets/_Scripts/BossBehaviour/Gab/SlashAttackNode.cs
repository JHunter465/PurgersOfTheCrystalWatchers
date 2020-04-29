using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class SlashAttackNode : BaseNode
    {
        private int time = 0;
        private float duration;
        private AnimationData animationData;

        public SlashAttackNode(BlackBoard bb, AnimationData _animationData)
        {
            this.blackBoard = bb;
            this.animationData = _animationData;
            duration = blackBoard.AnimationController.GetCurrentAnimatorStateInfo(0).length;
        }

        public override BehaviourTreeStatus Tick()
        {
            //blackBoard.Boss.transform.LerpTransform(blackBoard.Boss, new Vector3(0, 0, 0), 5);
            
            if (duration > 0)
            {
                Debug.Log("Lets go" + duration);
                duration--;
                return BehaviourTreeStatus.Running;
            }
            else
            {
                Debug.Log("move next");
                blackBoard.AnimationController.SetBool(animationData.AnimationBoolName, true);
                return BehaviourTreeStatus.Succes;
            }
        }
    }
}
