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
        protected bool patroling = true;
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
                new SummonNode(board, board.EnemyAgent.MinionSpawnAmount)
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
                            new AoEProjectileSpawnNode(board),
                            new KristalCanonNode(board)))),
                new SequenceNode<EnemyAgent>(
                    new AoEProjectileSpawnNode(board),
                    new AoEProjectilesNode(board))
            };

            specialMovesNarrowClifsMode = new BehaviourNode<EnemyAgent>[]
            {
                new GrabNode(board),
                new SequenceNode<EnemyAgent>(
                    new GoUnderGroundNode(board),
                    new GoAboveGroundNode(board)),
                new QuickAttackNode(board)
            };

            return new SelectorNode<EnemyAgent>(
                new Selection<EnemyAgent>(ctx => DoPatrolUntil(),
                    new PatrolNode(board)),
                new Selection<EnemyAgent>(ctx => !DoSpecialMove(GetActiveSelectedSpecialMoves()),
                    new SequenceNode<EnemyAgent>(
                        new LeapNode(board),
                        new FireProjectileNode(board),                        
                        new SummonNode(board, board.EnemyAgent.MinionSpawnAmount/2),
                            new SelectorNode<EnemyAgent>(
                                new Selection<EnemyAgent>(ctx => PlayerDistanceCheck(board.EnemyAgent.PlayerCloseRange),
                                    new JabLegNode(board))))),
                        /*new SelectorNode<EnemyAgent>(
                            new Selection<EnemyAgent>(ctx => DoSpecialMove(),
                                specialMoves[randomNumm])))));*/
            
                //This works hela fine
                new Selection<EnemyAgent>(ctx => DoSpecialMove(GetActiveSelectedSpecialMoves()),
                    GetActiveSelectedSpecialMoves()[randomNumm]));




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

        public bool DoPatrolUntil()
        {
            if (patroling)
            {
                if (PlayerDistanceCheck(board.EnemyAgent.PlayerFarRange))
                {
                    patroling = false;
                    board.EnemyAgent.LookTransform = board.EnemyAgent.Player.transform;
                    return false;
                }
                return true;
            }
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
           // EventManager<Color>.BroadCast(EVENT.SpecialAttackFeedback, Color.red);
            //Afhankelijk van welke pyramide kan de speler heeft aangezet voor het laast
            //Moeten we de boss het huidige active special moves aanzetten. 
            switch(board.EnemyAgent.SpecialModeActive)
            {
                case SpecialMode.OpenTerrain:
                    activeSpecialModes = specialMovesOpenTerrainMode;
                    break;
                case SpecialMode.PlatformArea:
                    activeSpecialModes = specialMovesPlatformMode;
                    break;
                case SpecialMode.NarrowClifs:
                    activeSpecialModes = specialMovesNarrowClifsMode;
                    break;
                default:
                    activeSpecialModes = specialMovesOpenTerrainMode;
                    break;
            }

            return activeSpecialModes;
        }

        public bool DoSpecialMove(BehaviourNode<EnemyAgent>[] specialMoves)
        {
            if(board.EnemyAgent.ThresHoldCheck())
            {
                EventManager<Color>.BroadCast(EVENT.SpecialAttackFeedback, Color.red);
            }
            else
            {
                EventManager<Color>.BroadCast(EVENT.SpecialAttackFeedback, Color.blue);
            }

            randomNumm = Random.Range(0, specialMoves.Length);
            return board.EnemyAgent.ThresHoldCheck();
        }
    }
}
