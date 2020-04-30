using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class ChooseRandomNode : ComplexSequenceNode<EnemyAgent>
    {
        protected EnemyBlackBoard board;
        protected BehaviourNode<EnemyAgent>[] nodes;

        public ChooseRandomNode(EnemyBlackBoard board, params BehaviourNode<EnemyAgent>[] nodes)
        {
            this.board = board;
            this.nodes = nodes;
        }

        public override IEnumerable<BehaviourNode<EnemyAgent>> GetChilds()
        {
            var randomNumm = Random.Range(0, nodes.Length);
            Debug.Log("Special move :" + nodes[randomNumm]);
            yield return nodes[randomNumm];
        }
    }
}
