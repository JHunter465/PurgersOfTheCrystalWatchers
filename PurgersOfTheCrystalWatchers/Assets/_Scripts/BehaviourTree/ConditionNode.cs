using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace POTCW
{
    public class ConditionNode : BaseNode
    {
        private BaseNode[] inputNodes;
        private Func<bool> condition;

        public ConditionNode(BlackBoard bb, Func<bool> _condition, params BaseNode[] _inputNodes)
        {
            this.blackBoard = bb;
            this.condition = _condition;
            this.inputNodes = _inputNodes;
        }

        public override BehaviourTreeStatus Tick()
        {
            if (!condition())
            {
                return BehaviourTreeStatus.Succes;
            }
            foreach (BaseNode node in inputNodes)
            {
                BehaviourTreeStatus result = node.Tick();

                switch (result)
                {
                    case BehaviourTreeStatus.Failure:
                        return BehaviourTreeStatus.Failure;
                    case BehaviourTreeStatus.Running:
                        return BehaviourTreeStatus.Running;
                    case BehaviourTreeStatus.Succes:
                        //only at succes it moves on to the next task
                        break;
                    default:
                        break;
                }
            }

            return BehaviourTreeStatus.Failure;
        }
    }
}
