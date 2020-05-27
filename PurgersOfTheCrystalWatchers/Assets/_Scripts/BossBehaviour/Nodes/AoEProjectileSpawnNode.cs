using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace POTCW
{
    public class AoEProjectileSpawnNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public AoEProjectileSpawnNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            board.AnimatorController.SetTrigger(Globals.BOSS_AOEBARRAGE_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);

            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);

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
            {
                //Do some visuals to show we are shooting at a platform
                for (int i = 0; i < board.EnemyAgent.AoEProjectilesAmount; i++)
                {
                    GameObject aoEProjectile = ObjectPooler.Instance.SpawnFromPool(board.EnemyAgent.ProjectilePrefab.name, board.EnemyAgent.ProjectileSpawn.transform.position, board.EnemyAgent.ProjectileSpawn.transform.rotation);
                }
                return State.IN_PROGRESS;
            }
        }
    }
}
