﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace POTCW
{
    public class FireProjectileNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public FireProjectileNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            
            board.AnimatorController.ResetTrigger(Globals.BOSS_LEAPING_ANIMATORBOOL);

            board.AnimatorController.SetTrigger(Globals.BOSS_FIRING_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);

            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);


            //Debug.Log("Start Fire Projectile+ animation lenght: " + currentClipInfo[0].clip.length);
 
            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                //Fire Projectile
                GameObject projectile = ObjectPooler.Instance.SpawnFromPool(board.EnemyAgent.ProjectilePrefab.name, board.EnemyAgent.ProjectileSpawn.transform.position, board.EnemyAgent.ProjectileSpawn.transform.rotation);
                projectile.GetComponent<Rigidbody>().AddRelativeForce(projectile.transform.forward * 1000);
                return State.SUCCESS;
            }
            else
            {
                return State.IN_PROGRESS;
            }
        }
    }
}
