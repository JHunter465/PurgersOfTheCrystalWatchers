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
        private float currentClipLenght = 0;
        private float duration;
        private AnimatorClipInfo[] currentClipInfo;

        protected BlackBoard blackBoard;
        
        public abstract BehaviourTreeStatus Tick();

        public virtual void NodeEnter(string lastAnimationBool, string nextAnimationBool)
        {            
            blackBoard.AnimationController.SetBool(lastAnimationBool, false);
            blackBoard.AnimationController.SetBool(nextAnimationBool, true);
            currentClipInfo = this.blackBoard.AnimationController.GetCurrentAnimatorClipInfo(0);
            //Access the current length of the clip
            duration = currentClipInfo[0].clip.length;
            Debug.Log(duration);
        }

        public float GetAnimationClipDuration()
        {
            return duration;
        }
    }
}
