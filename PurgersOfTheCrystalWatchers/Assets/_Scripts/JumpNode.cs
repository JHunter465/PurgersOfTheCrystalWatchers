using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class JumpNode : BaseNode
    {
        private bool onGround = false;

        public JumpNode(BlackBoard bb, string animatorBoolName)
        {
            this.blackBoard = bb;
            //blackBoard.AnimationController.SetBool(animatorBoolName, true);
        }

        public override BehaviourTreeStatus Tick()
        {
            blackBoard.Boss.transform.LerpTransform(blackBoard.Boss, new Vector3(10, 10, 10), 5);
            //The Time
            float time = Time.time;

            //old position
            Vector3 transformOldPosition = blackBoard.Boss.transform.position;
            Vector3 targetPosition = new Vector3(10, 10, 10);
            //While loop
            while (blackBoard.Boss.transform.position != targetPosition)
            {
                try
                {
                    if (blackBoard.Boss.transform != null)
                        blackBoard.Boss.transform.position = Vector3.MoveTowards(transformOldPosition, targetPosition, (Time.time - time) * 5);
                    else
                        return BehaviourTreeStatus.Failure;
                }
                catch (MissingReferenceException)
                {
                    break;
                }
            }

            return BehaviourTreeStatus.Succes;
        }
    }
}
