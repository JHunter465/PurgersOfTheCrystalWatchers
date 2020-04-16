using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class BlackBoard
    {
        public float BaseDamage;
        public float HeavyDamage;
        public float JumpMultiplier =2;
        public MonoBehaviour Boss;
        public Rigidbody BossBody;
        public Animator AnimationController;
    }
}
