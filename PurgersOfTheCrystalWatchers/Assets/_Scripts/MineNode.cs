using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class MineNode : BaseNode
    {
        private float holdTime;
        private float time = 0;
        private bool mine;
        private AnimationData animationData;
        public MineNode(BlackBoard bb, float _holdTime, AnimationData _animationData)
        {
            this.blackBoard = bb;
            this.holdTime = _holdTime;
            this.animationData = _animationData;
        }

        public override BehaviourTreeStatus Tick()
        {
            //Boss animates
            //Boss goes underground(boss is gone)
            //Boss algoritme om player positie of aantal random posities te verkrijgen en hier een circel op te zetten
            //Boss komt op gevonde plek uit de grond en valt speler aan als in range
            
            time++;

            //Get the boss his animator controller

            //Activate animation state
            //Boss is now animating
            //controller.SetBool(animationData.AnimationBoolName, true);
            float duration = blackBoard.AnimationController.GetCurrentAnimatorStateInfo(0).length;
            
            if(duration > 0)
            {
                //Now we can do our code that can be used at the same time as the animation
                duration--;
                return BehaviourTreeStatus.Running;
            }
            else
            {
                //Alright, animation is done, we move on to the next node
                blackBoard.AnimationController.SetBool(animationData.AnimationBoolName, true);
                return BehaviourTreeStatus.Succes;
            }

            if (time < holdTime)
            {               
                Debug.Log("Mine");

                //animatie
                blackBoard.Boss.gameObject.GetComponent<MeshRenderer>().enabled = false;

                //Find new positions
                Vector3 playerPosition = blackBoard.Boss.Player.transform.position;
                if(!mine) blackBoard.Boss.transform.LerpTransform(blackBoard.Boss, playerPosition, 10);
                //ik moet een systeem bouwen wat ervoor zorgt dat een node een bepaalde actie uitvoerd 
                //waarna hij pas verder gaat als deze actie klaar is
                return BehaviourTreeStatus.Running;
            }
            else
            {
                time = 0;
                mine = true;
                blackBoard.Boss.gameObject.GetComponent<MeshRenderer>().enabled = true;
                return BehaviourTreeStatus.Succes;
            }
        }
    }

    
}
