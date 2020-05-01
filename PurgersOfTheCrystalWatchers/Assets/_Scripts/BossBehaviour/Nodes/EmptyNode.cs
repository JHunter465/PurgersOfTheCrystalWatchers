using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timers;

namespace POTCW
{
    public class EmptyNode : BehaviourNode<EnemyAgent>
    {
        private bool check = false;
        private float timeToHold = 0;

        public EmptyNode(float timeToHold)
        {
            this.timeToHold = timeToHold;
        }

        public override State Start()
        {
            TimerManager.Instance.AddTimer(() => { check = !check; }, timeToHold);
            return State.IN_PROGRESS;
        }

        public override State Update()
        {
            if (check)
            {
                return State.SUCCESS;
            }
            else
            {
                return State.IN_PROGRESS;
            }
        }
    }
}
