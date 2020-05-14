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
        protected int randomNumm = 0;
        protected BehaviourNode<EnemyAgent>[] specialMovesOpenTerrainMode;
        protected BehaviourNode<EnemyAgent>[] specialMovesPlatformMode;
        protected BehaviourNode<EnemyAgent>[] specialMovesNarrowClifsMode;

        public MyBehaviourTree(EnemyBlackBoard board)
        {
            this.board = board;
        }

        protected override BehaviourNode<EnemyAgent> GetRootNode()
        {


            specialMovesOpenTerrainMode = new BehaviourNode<EnemyAgent>[]
            {
                new CrystalTornadoNode(board),
                new AoEShieldSlamNode(board),
                new SummonNode(board)
            };

            specialMovesPlatformMode = new BehaviourNode<EnemyAgent>[] 
            {
                new SelectorNode<EnemyAgent>(
                    new Selection<EnemyAgent>(ctx => PlatformsAliveCheck(),
                        new SequenceNode<EnemyAgent>(
                            new FindPlatformNode(board),
                            new YeetPlatformNode(board)))),
                new SelectorNode<EnemyAgent>(
                    new Selection<EnemyAgent>(ctx => PlatformsAliveCheck(),
                        new SequenceNode<EnemyAgent>(
                            new FindPlatformNode(board),
                            new KristalCanonNode(board)))),
                new AoEProjectilesNode(board)
            };

            specialMovesNarrowClifsMode = new BehaviourNode<EnemyAgent>[]
            {
                new GrabNode(board),
                new SequenceNode<EnemyAgent>(
                    new GoUnderGroundNode(board),
                    new GoAboveGroundNode(board))
            };

            return new SelectorNode<EnemyAgent>(
                new Selection<EnemyAgent>(ctx => !DoSpecialMove(specialMovesNarrowClifsMode),
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
                new Selection<EnemyAgent>(ctx => DoSpecialMove(specialMovesNarrowClifsMode),
                    specialMovesNarrowClifsMode[randomNumm]));




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

        public bool PlatformsAliveCheck()
        {
            if (board.EnemyAgent.Platforms.Count > 0)
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

        public BehaviourNode<EnemyAgent>[] GetActiveSelectedSpecialMoves()
        {
            BehaviourNode<EnemyAgent>[] activeSpecialModes;
            //Als de speler N actie heeft gedaan moet er een lijst gekozen worden
            //1 activeSpecialModes = specialMovesOpenTerrainMode
            //2 activeSpecialModes = specialMovesPlatformMode
            //3 activeSpecialModes = specialMovesNarrowCliffs

            //untill we have the mode switch system, lets just do this
            activeSpecialModes = specialMovesNarrowClifsMode;

            return activeSpecialModes;
        }

        public bool DoSpecialMove(BehaviourNode<EnemyAgent>[] specialMoves)
        {
            randomNumm = Random.Range(0, specialMoves.Length);
            return board.EnemyAgent.ThresHoldCheck();
        }
    }
}
