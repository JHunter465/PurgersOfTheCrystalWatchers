using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class SummonMinionsNode : BaseNode
    {
        private Transform[] spawns;

        private string lastAnimationBool;
        private string nextAnimationBool;
        private float count = 0;
        private bool checker = true;

        public SummonMinionsNode(BlackBoard bb, string lastAnimationBool, string nextAnimationBool, params Transform[] _spawns)
        {
            this.blackBoard = bb;
            this.spawns = _spawns;
            this.lastAnimationBool = lastAnimationBool;
            this.nextAnimationBool = nextAnimationBool;
        }

        public override BehaviourTreeStatus Tick()
        {
            if (checker)
            {
                NodeEnter(lastAnimationBool, nextAnimationBool);
                checker = false;
            }
            if (count < GetAnimationClipDuration() + 10)
            {
                //We are now playing the animation and summoning minions
                count += Time.deltaTime;
                Debug.Log("Summon minions!" + count);
                //return BehaviourTreeStatus.Running;
                return BehaviourTreeStatus.Running;
            }
            else
            {
                for (int i = 0; i < spawns.Length; i++)
                {
                    GameObject minion = GameObject.Instantiate(blackBoard.MinionPrefab, spawns[i].position, Quaternion.identity);
                }
                count = 0;
                checker = true;
                return BehaviourTreeStatus.Succes;
            }
        }
    }
}
