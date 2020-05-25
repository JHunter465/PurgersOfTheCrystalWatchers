using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;
using BasHelpers;

namespace POTCW
{
    public class PatrolNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public PatrolNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            board.AnimatorController.SetTrigger(Globals.BOSS_SHIELDSLAM_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);
            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);
            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            Vector3 enemyAgentPosition = board.EnemyAgent.transform.position;
            Vector3 playerPosition = board.EnemyAgent.Player.transform.position;
            if (Vector3.Distance(enemyAgentPosition, playerPosition) > board.EnemyAgent.PlayerCloseRange)
            {
                if (Vector3.Distance(enemyAgentPosition.ToZeroY(), board.EnemyAgent.PatrolPoints[board.EnemyAgent.PatrolIndex].transform.position.ToZeroY()) < 10f)
                {

                    if (board.EnemyAgent.PatrolIndex < board.EnemyAgent.PatrolPoints.Count - 1)
                    {
                        EventManager<int>.BroadCast(EVENT.GetPlayerDistance, board.EnemyAgent.GetPlayerDistanceFromBoss());
                        board.EnemyAgent.PatrolIndex++;
                    }
                    else
                        board.EnemyAgent.PatrolIndex = 0;
                }
                else
                {
                    if (board.EnemyAgent.PatrolIndex <= board.EnemyAgent.PatrolPoints.Count-1)
                    {
                        board.EnemyAgent.LookTransform = board.EnemyAgent.PatrolPoints[board.EnemyAgent.PatrolIndex];

                        board.EnemyAgent.NavMeshAgent.SetDestination(board.EnemyAgent.PatrolPoints[board.EnemyAgent.PatrolIndex].transform.position);
                    }
                    else
                    {
                        board.EnemyAgent.PatrolIndex = 0;
                    }
                }
                return State.IN_PROGRESS;
            }
            else
            {
                return State.SUCCESS;
            }
        }
    }
}
