using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace POTCW
{
    public class LeapNode : BehaviourNode<EnemyAgent>
    {

        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public LeapNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            
            board.AnimatorController.SetTrigger(Globals.BOSS_LEAPING_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);
            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);


            Debug.Log("Start Leap + animation lenght: "+ currentClipInfo[0].clip.length);
            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
                return State.SUCCESS;
            else
            {
                if (Vector3.Distance(board.EnemyAgent.transform.position, board.EnemyAgent.Player.transform.position) > board.EnemyAgent.PlayerCloseRange)
                {
                    float step = board.EnemyAgent.MovementSpeed * Time.deltaTime;
                    //step by step move towards the player
                    Vector3 deltaPos = board.EnemyAgent.transform.position - board.EnemyAgent.Player.transform.position;
                    Vector3 tmpPosition = board.EnemyAgent.transform.position;
                    board.EnemyAgent.transform.position = Vector3.MoveTowards(tmpPosition, board.EnemyAgent.Player.transform.position, step);
                    //blackBoard.Boss.transform.LerpTransform(blackBoard.Boss, blackBoard.Player.transform.position, blackBoard.BossMovementSpeed);
                    //blackBoard.Boss.transform.position = Vector3.Lerp(blackBoard.Boss.transform.position, blackBoard.Player.transform.position, step);
                    return State.IN_PROGRESS;

                }
                else
                    return State.SUCCESS;
            }
        }
    }
}
