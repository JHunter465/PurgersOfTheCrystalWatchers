using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;
using UnityEngine.Timers;

namespace POTCW
{
    public class AoEProjectilesNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public AoEProjectilesNode(EnemyBlackBoard board)
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
                //AoE Projectile Rain Attack
                for (int i = 0; i < board.EnemyAgent.AoEProjectilesAmount; i++)
                {
                    GameObject aoEProjectile = ObjectPooler.Instance.SpawnFromPool(board.EnemyAgent.ProjectilePrefab.name, board.EnemyAgent.AoEProjectileRainSpawn.position, board.EnemyAgent.AoEProjectileRainSpawn.rotation);
                    
                }
                return State.SUCCESS;
            }
            else
            {
                board.EnemyAgent.AoEProjectileRainSpawn.position = board.EnemyAgent.Player.transform.position + Vector3.up * board.EnemyAgent.AoEProjectileRainSpawnPlayerDistanceHeight;

                return State.IN_PROGRESS;
            }
        }
    }
}
