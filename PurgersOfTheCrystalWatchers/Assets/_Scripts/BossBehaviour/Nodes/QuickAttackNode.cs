using BasHelpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace POTCW
{
    public class QuickAttackNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public QuickAttackNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            board.AnimatorController.SetTrigger(Globals.BOSS_QUICKATTACK_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);

            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);

            board.EnemyAgent.QuickAttackObject.SetActive(true);

            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                board.EnemyAgent.QuickAttackObject.SetActive(false);
                return State.SUCCESS;
            }
            else
            {
                return State.IN_PROGRESS;
            }
        }
    }
}
