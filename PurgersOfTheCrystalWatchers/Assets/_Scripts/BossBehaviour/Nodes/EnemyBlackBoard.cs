using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class EnemyBlackBoard : BehaviourTreeBoard<EnemyAgent>
    {
        public Animator AnimatorController;

        public EnemyAgent EnemyAgent;
    }
}
