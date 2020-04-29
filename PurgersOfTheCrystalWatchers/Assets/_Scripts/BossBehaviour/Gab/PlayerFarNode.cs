using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class PlayerFarNode : BaseNode
    {
        private BaseNode[] choices;

        public PlayerFarNode(BlackBoard bb, params BaseNode[] inputs)
        {
            this.blackBoard = bb;
            this.choices = inputs;
        }

        public override BehaviourTreeStatus Tick()
        {
            //if player is far away and out of close combat range

            //We have to decide what to do
            BaseNode chooseRandomNode = choices[Random.Range(0, choices.Length)];
            var node = chooseRandomNode.Tick();
            Debug.Log(Random.Range(0, choices.Length));
            return node;
            //Fire projectile?
            //Summon minions?
            //Fire Projectile (fake) ?
            //Leap at player to get close?
            //Special ability from current mode

            //Return succes and choose next move

        }
    }
}
