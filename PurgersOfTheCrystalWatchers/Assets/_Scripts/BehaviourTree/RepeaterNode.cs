using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class RepeaterNode : BaseNode
    {
        /// <summary>
        /// List of child nodes.
        /// </summary>
        private BaseNode[] inputNodes;

        public RepeaterNode(BlackBoard bb, params BaseNode[] _inputNodes)
        {
            this.blackBoard = bb;
            this.inputNodes = _inputNodes;
        }

        public override BehaviourTreeStatus Tick()
        {
            foreach (BaseNode node in inputNodes)
            {
                var childStatus = node.Tick();
                return childStatus;              
            }
            return BehaviourTreeStatus.Succes;
        }   
    }
}
