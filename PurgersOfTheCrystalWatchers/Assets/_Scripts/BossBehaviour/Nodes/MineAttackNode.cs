using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;
using BasHelpers;

namespace POTCW
{
    public class MineAttackNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public MineAttackNode(EnemyBlackBoard board)
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
            Debug.Log("Go underground");
            board.EnemyAgent.SearchPlayerGameObject.SetActive(true);

            board.EnemyAgent.transform.LerpTransform(board.EnemyAgent, board.EnemyAgent.transform.position - Vector3.up * board.EnemyAgent.MineDepth, board.EnemyAgent.YeetSpeed);

            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                //Go above ground
                Debug.Log("Go Above Ground");
                board.EnemyAgent.transform.LerpTransform(board.EnemyAgent, board.EnemyAgent.transform.position + Vector3.up * board.EnemyAgent.MineDepth, board.EnemyAgent.YeetSpeed);
                board.EnemyAgent.SearchPlayerGameObject.SetActive(false);
                return State.SUCCESS;
            }
            else
            {
                //Search Player Position
                board.EnemyAgent.SearchPlayerGameObject.transform.LerpTransform(board.EnemyAgent, board.EnemyAgent.Player.transform.position, board.EnemyAgent.YeetSpeed);
                board.EnemyAgent.transform.position = board.EnemyAgent.transform.position.KeepOwnY(board.EnemyAgent.SearchPlayerGameObject.transform.position);

                return State.IN_PROGRESS;
            }
        }
    }
}
