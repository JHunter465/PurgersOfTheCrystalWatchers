using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;
using BasHelpers;

namespace POTCW
{
    public class FindPlatformNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public FindPlatformNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            board.AnimatorController.SetTrigger(Globals.BOSS_YEETPLATFORM_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);
            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);

            int numm = 0;
            board.EnemyAgent.CurrentSelectedPlatform = board.EnemyAgent.Platforms[numm];
            switch (board.EnemyAgent.GetYeetPlatformType())
            {
                case FindPlatformType.Random:
                    numm = Random.Range(0, board.EnemyAgent.Platforms.Count);
                    board.EnemyAgent.CurrentSelectedPlatform = board.EnemyAgent.Platforms[numm];
                    break;
                case FindPlatformType.CloseByPlayer:
                    foreach (Transform platform in board.EnemyAgent.Platforms)
                    {
                        if (board.EnemyAgent.PlayerDistanceCheck(platform, board.EnemyAgent.PlatformCloseDistance))
                        {
                            board.EnemyAgent.CurrentSelectedPlatform = platform;
                        }
                    }
                    break;
            }

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
                return State.IN_PROGRESS;
        }
    }
}
