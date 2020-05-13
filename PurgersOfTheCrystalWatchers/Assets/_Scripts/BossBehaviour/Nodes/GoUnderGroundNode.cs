using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;
using BasHelpers;

namespace POTCW
{
    public class GoUnderGroundNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public GoUnderGroundNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            board.AnimatorController.SetTrigger(Globals.BOSS_MINE_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);
            TimerManager.Instance.AddTimer(() => { check = !check; }, 2);

            //Go underground
            board.EnemyAgent.SearchPlayerGameObject.SetActive(true);
            Debug.Log("Go Under Ground");
            //10 units op de Y axis naar beneden
            board.EnemyAgent.transform.LerpTransform(board.EnemyAgent, board.EnemyAgent.transform.position - Vector3.up * board.EnemyAgent.MineDepth, board.EnemyAgent.YeetSpeed);

            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                board.EnemyAgent.transform.position = board.EnemyAgent.transform.position.KeepOwnY(board.EnemyAgent.SearchPlayerGameObject.transform.position);
                Debug.Log("Move To Underneath player");
                return State.SUCCESS;
            }
            else
            {
                 //Search Player Position
                board.EnemyAgent.SearchPlayerGameObject.transform.LerpTransform(board.EnemyAgent,board.EnemyAgent.Player.transform.position, board.EnemyAgent.YeetSpeed);

                return State.IN_PROGRESS;
            }
        }
    }
}
