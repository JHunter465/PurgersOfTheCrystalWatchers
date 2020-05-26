using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;
using BasHelpers;

namespace POTCW
{
    public class GrabNode : BehaviourNode<EnemyAgent>
    {
        EnemyBlackBoard board;
        private bool check = false;
        AnimatorClipInfo[] currentClipInfo;

        public GrabNode(EnemyBlackBoard board)
        {
            this.board = board;
        }

        //Called when the node is entered
        public override State Start()
        {
            board.AnimatorController.SetTrigger(Globals.BOSS_GRAB_ANIMATORBOOL);

            currentClipInfo = board.AnimatorController.GetCurrentAnimatorClipInfo(0);

            TimerManager.Instance.AddTimer(() => { check = !check; }, currentClipInfo[0].clip.length);

            board.EnemyAgent.PlayerInGrabRange = false;

            //Grab player
            board.EnemyAgent.GrabObject.SetActive(true);
            //board.EnemyAgent.GrabObject.transform.LerpTransform(board.EnemyAgent, board.EnemyAgent.Player.transform.position, board.EnemyAgent.GrabSpeed);
            
            //Transform raycastfrom = board.EnemyAgent.GrabSpawn.transform;
            //Vector3 fwd = raycastfrom.TransformDirection(raycastfrom.forward);
            //Debug.DrawRay(raycastfrom.position, fwd * 400, Color.green);
            //RaycastHit objectHit;

            //Debug.Log("Grab attack");

            //if (Physics.Raycast(raycastfrom.position, fwd, out objectHit, 400))
            //{
            //    //do something if hit object ie
            //    if (objectHit.collider.gameObject.tag == "Player")
            //    {
            //        Debug.Log("Grab has hit player");

            //        objectHit.collider.enabled = false;
            //    }
            //}
        
            
            return State.IN_PROGRESS;
        }

        //Called everey frame while the node is active
        public override State Update()
        {
            if (check)
            {
                board.EnemyAgent.GrabObject.DeactivateAfterTime(board.EnemyAgent, 1f);

                //This does'nt work, why?!
                //board.EnemyAgent.GrabObject.transform.position = board.EnemyAgent.GrabSpawn.transform.position;
                //board.EnemyAgent.GrabObject.SetActive(false);
                return State.SUCCESS;
            }
            else
            {

                return State.IN_PROGRESS;
            }
        }
    }
}
