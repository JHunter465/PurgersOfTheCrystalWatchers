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
        public BossBase Boss;
        public Rigidbody BossBody;
        public Animator AnimationController;
        public GameObject Player;
        public float PlayerRange = 10;
        public float BossMovementSpeed = 10f;
        public Rigidbody ProjectilePrefab;
        public GameObject MinionPrefab;
    }
}
