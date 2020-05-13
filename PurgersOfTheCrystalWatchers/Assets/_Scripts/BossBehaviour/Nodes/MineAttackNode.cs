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
            board.AnimatorController.SetTrigger(Globals.BOSS_YEETPLATFORM_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);
            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);

            board.EnemyAgent.transform.LerpTransform(board.EnemyAgent, board.EnemyAgent.transform.position - Vector3.up * 10, board.EnemyAgent.YeetSpeed);

            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {

                return State.SUCCESS;
            }
            else
                return State.IN_PROGRESS;
        }
    }
}
