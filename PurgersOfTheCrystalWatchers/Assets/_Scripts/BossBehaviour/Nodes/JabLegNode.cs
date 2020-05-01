using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace POTCW
{
    public class JabLegNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public JabLegNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            board.AnimatorController.SetTrigger(Globals.BOSS_JABLEG_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);

            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length + board.EnemyAgent.TimeBetweenNodes);

            // Debug.Log("Start Leap + animation lenght: "+ currentClipInfo[0].clip.length);
            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                //Jab Leg
                board.EnemyAgent.ShockWaveTriggerObject.SetActive(true);
                board.EnemyAgent.ShockWaveTriggerObject.GetComponent<SphereCollider>().radius = board.EnemyAgent.ShockWaveRange;

                return State.SUCCESS;
            }
            else
            {
                return State.IN_PROGRESS;
            }
        }
    }
}
