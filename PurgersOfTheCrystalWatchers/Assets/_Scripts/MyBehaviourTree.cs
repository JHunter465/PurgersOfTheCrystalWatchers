using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace POTCW
{
    public class MyBehaviourTree : BehaviourTree<EnemyAgent>
    {
        protected EnemyBlackBoard board;
        protected float thresHold = 10;

        private int randomNumm = 0;
        BehaviourNode<EnemyAgent>[] specialMoves; 

        public MyBehaviourTree(EnemyBlackBoard board)
        {
            this.board = board;
        }

        protected override BehaviourNode<EnemyAgent> GetRootNode()
        {

            specialMoves = new BehaviourNode<EnemyAgent>[]{ new CrystalTornadoNode(board) ,
                        new AoEShieldSlamNode(board),
                        new SummonNode(board) };

            return new SelectorNode<EnemyAgent>(
                new Selection<EnemyAgent>(ctx => !DoSpecialMove(),
                    new SequenceNode<EnemyAgent>(
                        new LeapNode(board),
                        new FireProjectileNode(board),
                        new SummonNode(board),
                            new SelectorNode<EnemyAgent>(
                                new Selection<EnemyAgent>(ctx => PlayerDistanceCheck(board.EnemyAgent.PlayerCloseRange),
                                    new JabLegNode(board))))),
                        /*new SelectorNode<EnemyAgent>(
                            new Selection<EnemyAgent>(ctx => DoSpecialMove(),
                                specialMoves[randomNumm])))));*/
            
                //This works hela fine
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

        
        //This fucking buggs hard, when I set trheshold at 100 everything works fine but when I lower it
        //It keeps calling the nodes multiple times
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
                thresHold = 10;
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
            randomNumm = Random.Range(0, specialMoves.Length);
            Debug.Log(board.EnemyAgent.ThresHoldCheck());
            return board.EnemyAgent.ThresHoldCheck();
        }
    }
}
