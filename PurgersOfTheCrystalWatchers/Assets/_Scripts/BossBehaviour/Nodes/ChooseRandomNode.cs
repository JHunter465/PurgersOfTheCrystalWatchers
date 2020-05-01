using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class ChooseRandomNode : BehaviourNode<EnemyAgent>
    {
        protected EnemyBlackBoard board;
        protected BehaviourNode<EnemyAgent>[] nodes;

        public ChooseRandomNode(EnemyBlackBoard board, params BehaviourNode<EnemyAgent>[] nodes)
        {
            this.board = board;
            this.nodes = nodes;

            Debug.Log("Choose random?");
        }

        public override State Start()
        {
            var randomNumm = Random.Range(0, nodes.Length);
            Debug.Log("Special move :" + nodes[randomNumm]);
            return nodes[randomNumm].Start();
        }

        public override State Update()
        {
            return State.SUCCESS;
        }
    }
}
