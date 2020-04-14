using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    /// <summary>
    /// Execute the child nodes in order from the left, terminate when the child node returns failure, and return a failure.
    ///If all child nodes return success, success is returned.
    ///It is used when you want to execute all as long as the child node returns success.
    /// </summary>
    public class SequenceNode : BaseNode
    {
        /// <summary>
        /// List of child nodes.
        /// </summary>
        private BaseNode[] inputNodes;

        public SequenceNode(BlackBoard bb, params BaseNode[] _inputNodes)
        {
            this.blackBoard = bb;
            this.inputNodes = _inputNodes;
        }

        public override BehaviourTreeStatus Tick()
        {
            foreach(BaseNode node in inputNodes)
            {
                var childStatus = node.Tick();
                if(childStatus != BehaviourTreeStatus.Succes)
                {
                    return childStatus;
                }
            }

            return BehaviourTreeStatus.Succes;
        }
    }
}
