using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace POTCW
{
    public class CrystalTornadoNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public CrystalTornadoNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);
            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);

            board.AnimatorController.SetTrigger(Globals.BOSS_SHIELDSLAM_ANIMATORBOOL);

            Debug.Log("Start Crystal Tornado");
            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                //Summon Crystal Tornado
                GameObject crystalTornado = GameObject.Instantiate(board.EnemyAgent.CrystalTornadoPrefab, board.EnemyAgent.transform.position, Quaternion.identity);
                crystalTornado.GetComponent<CrystalTornado>().Init(board.EnemyAgent.Player);
                return State.SUCCESS;
            }
            else
                return State.IN_PROGRESS;
        }
    }
}
