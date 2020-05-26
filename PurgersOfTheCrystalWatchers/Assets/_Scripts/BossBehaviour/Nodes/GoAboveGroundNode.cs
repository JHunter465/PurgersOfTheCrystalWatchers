using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;
using BasHelpers;

namespace POTCW
{
    public class GoAboveGroundNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public GoAboveGroundNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);
            TimerManager.Instance.AddTimer(() => { check = !check; },10);

            //Go AboveGround
            //MineDepth units op de Y axis naar boven
            //board.EnemyAgent.transform.LerpTransform(board.EnemyAgent, board.EnemyAgent.transform.position + Vector3.up * board.EnemyAgent.MineDepth, board.EnemyAgent.YeetSpeed);
            //board.EnemyAgent.SearchPlayerGameObject.SetActive(false);

            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                board.AnimatorController.SetTrigger(Globals.BOSS_MINEABOVE_ANIMATORBOOL);

                return State.SUCCESS;
            }
            else
            {            
                return State.IN_PROGRESS;
            }
        }
    }
}
