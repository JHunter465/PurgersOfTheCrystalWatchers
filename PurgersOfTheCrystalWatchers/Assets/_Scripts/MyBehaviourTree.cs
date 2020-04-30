using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class MyBehaviourTree : BehaviourTree<EnemyAgent>
    {
        protected EnemyBlackBoard board;
        protected float thresHold = 100;

        public MyBehaviourTree(EnemyBlackBoard board)
        {
            this.board = board;
        }

        protected override BehaviourNode<EnemyAgent> GetRootNode()
        {
            BehaviourNode<EnemyAgent>[] specialMoves = new BehaviourNode<EnemyAgent>[3]{ new CrystalTornadoNode(board) ,
                        new AoEShieldSlamNode(board),
                        new SummonNode(board) };

            var randomNumm = Random.Range(0, specialMoves.Length);

            return new SelectorNode<EnemyAgent>(
                new Selection<EnemyAgent>(ctx => DoStandardBehaviour(),
                    new SequenceNode<EnemyAgent>(
                        new LeapNode(board),
                        new FireProjectileNode(board),
                        new SummonNode(board))),
                new Selection<EnemyAgent>(ctx => DoSpecialMove(),
                    specialMoves[randomNumm]));
                    /*new ChooseRandomNode(board,
                        new CrystalTornadoNode(board),
                        new AoEShieldSlamNode(board),
                        new SummonNode(board))));
                    
                /*
                 * Hier ergens zit de bug:
                new Selection<EnemyAgent>(ctx => DoSpecialMove(),
                    GetRandomSpecialAttackNode(new List<BehaviourNode<EnemyAgent>>()
                    {
                        new CrystalTornadoNode(board),
                        new AoEShieldSlamNode(board),
                        new SummonNode(board)
                    })));
            /*
                new Selection<EnemyAgent>(ctx => !DoStandardBehaviour(),
                    new SequenceNode<EnemyAgent>(
                        new CrystalTornadoNode(board))),
                new Selection<EnemyAgent>(ctx => SelectRandomSpecialAttack(1),
                    new SequenceNode<EnemyAgent>(
                        new AoEShieldSlamNode(board))),
                new Selection<EnemyAgent>(ctx => SelectRandomSpecialAttack(2),
                    new SequenceNode<EnemyAgent>(
                        new SummonNode(board))));*/
        }

        public bool PlayerDistanceCheck(float range)
        {
            if (Vector3.Distance(board.EnemyAgent.transform.position, board.EnemyAgent.Player.transform.position) < range)
                return true;
            else
                return false;
        }

        public bool DoStandardBehaviour()
        {
            if (thresHold > 0.1f)
            {
                thresHold--;
                Debug.Log(thresHold);
                return true;
            }
            else
            {
                Debug.Log("threshold reached, do special move");
                thresHold = 100;
                return false;
            }
        }

        public BehaviourNode<EnemyAgent> GetRandomSpecialAttackNode(List<BehaviourNode<EnemyAgent>> moves)
        {
            var randomNumm = Random.Range(0, moves.Count);
            Debug.Log("Special move :" + moves[randomNumm]);
            return moves[randomNumm];
        }

        public bool DoSpecialMove()
        {
            return true;
        }
    }
}
