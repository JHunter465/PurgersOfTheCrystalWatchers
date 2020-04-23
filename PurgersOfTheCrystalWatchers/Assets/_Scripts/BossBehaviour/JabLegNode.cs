using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class JabLegNode : BaseNode
    {
        private string lastAnimationBool;
        private string nextAnimationBool;
        private float count = 0;
        private bool checker = true;

        public JabLegNode(BlackBoard bb, string lastAnimationBool, string nextAnimationBool)
        {
            this.blackBoard = bb;
            this.lastAnimationBool = lastAnimationBool;
            this.nextAnimationBool = nextAnimationBool;
        }

        public override BehaviourTreeStatus Tick()
        {
            if (checker)
            {
                NodeEnter(lastAnimationBool, nextAnimationBool);
                checker = false;
            }
            while (count < GetAnimationClipDuration())
            {
                //We are now playing the animation and summoning minions
                count += Time.deltaTime;
                Debug.Log("Jab leg" + count);
                return BehaviourTreeStatus.Running;
            }
            //if (count >= GetAnimationClipDuration())
                //count = 0;

            //Reset al other nodes
            return BehaviourTreeStatus.Succes;
        }
    }
}
