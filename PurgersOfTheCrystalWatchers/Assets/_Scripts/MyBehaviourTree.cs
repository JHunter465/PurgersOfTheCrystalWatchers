using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class MyBehaviourTree : BehaviourTree<EnemyAgent>
    {
        protected EnemyBlackBoard board;

        public MyBehaviourTree(EnemyBlackBoard board)
        {
            this.board = board;
        }

        protected override BehaviourNode<EnemyAgent> GetRootNode()
        {
            return new SelectorNode<EnemyAgent>(
                new Selection<EnemyAgent>(ctx => PlayerDistanceCheck(board.EnemyAgent.PlayerCloseRange),
                    new SequenceNode<EnemyAgent>(
                        //This are the actions we do when the player is really close
                        new FireProjectileNode(board),
                        new LeapNode(board),
                        new SummonNode(board))),
                new Selection<EnemyAgent>(ctx => PlayerDistanceCheck(board.EnemyAgent.PlayerFarRange),
                    new SequenceNode<EnemyAgent>(
                        //This are the actions we doe when the player is far away
                        new FireProjectileNode(board),
                        new LeapNode(board),
                        new AoEShieldSlamNode(board))));
        }

        public bool PlayerDistanceCheck(float range)
        {
            if (Vector3.Distance(board.EnemyAgent.transform.position, board.EnemyAgent.Player.transform.position) < range)
                return true;
            else
                return false;
        }
    }
}
