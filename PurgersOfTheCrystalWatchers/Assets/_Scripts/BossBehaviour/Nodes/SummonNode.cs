using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace POTCW
{
    public class SummonNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;
        private int amount;

        public SummonNode(EnemyBlackBoard board, int amount)
        {
            this.board = board;
            this.amount = amount;
        }

        //Called when the node is entered
        public override State Start()
        {
            board.AnimatorController.ResetTrigger(Globals.BOSS_FIRING_ANIMATORBOOL);
            board.AnimatorController.SetTrigger(Globals.BOSS_SUMMON_ANIMATORBOOL);
            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);
            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);


            //Debug.Log("Start Summon+ animation lenght: " + currentClipInfo[0].clip.length);
            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                //Spawn Minions
                amount = amount / board.EnemyAgent.MinionSpawns.Count;
                foreach (Transform spawn in board.EnemyAgent.MinionSpawns)
                {
                    for(int i = 0; i < amount; i++)
                    {
                        GameObject minion = ObjectPooler.Instance.SpawnFromPool(board.EnemyAgent.MinionPrefab.name, spawn.position, Quaternion.identity);
                        minion.GetComponent<IMinion>().Init(board.EnemyAgent.Player);                            
                    }          
                }
                return State.SUCCESS;
            }
            else
                return State.IN_PROGRESS;
        }
    }
}
