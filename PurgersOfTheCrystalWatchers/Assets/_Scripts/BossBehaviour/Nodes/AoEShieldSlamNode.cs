using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace POTCW
{
    public class AoEShieldSlamNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public AoEShieldSlamNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            board.AnimatorController.SetTrigger(Globals.BOSS_SHIELDSLAM_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);
            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);


            Debug.Log("Start Shield Slam");
            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                //Shield Slam
                board.EnemyAgent.ShockWaveTriggerObject.SetActive(true);
                board.EnemyAgent.ShockWaveTriggerObject.GetComponent<SphereCollider>().radius = board.EnemyAgent.ShockWaveRange;

                return State.SUCCESS;
            }
            else
                return State.IN_PROGRESS;
        }
    }
}
