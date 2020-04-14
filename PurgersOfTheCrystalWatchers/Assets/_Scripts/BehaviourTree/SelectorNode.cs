using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    /// <summary>
    /// Execute the child nodes in order from the left, terminate when the child node returns success, and return success.
    ///If all child nodes return failure, it returns failure.
    ///It is used when you want to find a successful node in order from the left and you do not want to run subsequent nodes.
    /// </summary>
    public class SelectorNode : BaseNode
    {
        /// <summary>
        /// list of child nodes
        /// </summary>
        private BaseNode[] inputNodes;

        public SelectorNode(BlackBoard bb, params BaseNode[] _inputNodes)
        {
            this.blackBoard = bb;
            this.inputNodes = _inputNodes;
        }

        public override BehaviourTreeStatus Tick()
        {
            foreach(BaseNode node in inputNodes)
            {
                var childStatus = node.Tick();
                if(childStatus != BehaviourTreeStatus.Failure)
                {
                    return childStatus;
                }
            }

            return BehaviourTreeStatus.Failure;
        }
    }
}
