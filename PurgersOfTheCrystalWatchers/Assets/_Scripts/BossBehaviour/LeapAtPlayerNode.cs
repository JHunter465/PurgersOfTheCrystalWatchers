using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class LeapAtPlayerNode : BaseNode
    {
        private string lastAnimationBool;
        private string nextAnimationBool;
        private float count = 0;
        private bool checker = true;
        public LeapAtPlayerNode(BlackBoard bb, string lastAnimationBool, string nextAnimationBool)
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

            while(count < GetAnimationClipDuration())
            {
                count += Time.deltaTime;
                Debug.Log("Leaping at player!"+ count);
                /*if (Vector3.Distance(blackBoard.Boss.transform.position, blackBoard.Player.transform.position) > blackBoard.PlayerRange)
                {
                    float step = blackBoard.BossMovementSpeed * Time.deltaTime;
                    //step by step move towards the player
                    Vector3 deltaPos = blackBoard.Boss.transform.position - blackBoard.Player.transform.position;
                    Vector3 tmpPosition = blackBoard.Boss.transform.position;
                    blackBoard.Boss.transform.position = Vector3.MoveTowards(tmpPosition, blackBoard.Player.transform.position, step);
                    //blackBoard.Boss.transform.LerpTransform(blackBoard.Boss, blackBoard.Player.transform.position, blackBoard.BossMovementSpeed);
                    //blackBoard.Boss.transform.position = Vector3.Lerp(blackBoard.Boss.transform.position, blackBoard.Player.transform.position, step);
                }*/
                return BehaviourTreeStatus.Running;
            }


            //blackBoard.AnimationController.SetBool("Leaping", false);
           //if (count >= GetAnimationClipDuration())
              // count = 0;
            return BehaviourTreeStatus.Succes;
            
        }

    }
}