using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;
using BasHelpers;

namespace POTCW
{
    public class KristalCanonNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public KristalCanonNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            board.AnimatorController.SetTrigger(Globals.BOSS_DESTROYPLATFORM_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);
            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);


            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                //Destroy platform 
                GameObject destroyPlatformParticle = ObjectPooler.Instance.SpawnFromPool(board.EnemyAgent.DestroyPlatformParticleEffect.name, board.EnemyAgent.CurrentSelectedPlatform.transform.position, Quaternion.identity);
                board.EnemyAgent.CurrentSelectedPlatform.gameObject.DeactivateAfterTime(board.EnemyAgent, 1f);
                board.EnemyAgent.Platforms.Remove(board.EnemyAgent.CurrentSelectedPlatform);
                return State.SUCCESS;
            }
            else
            {
                //Do some visuals to show we are shooting at a platform

                return State.IN_PROGRESS;
            }
        }
    }
}
