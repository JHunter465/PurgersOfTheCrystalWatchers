using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class FireProjectileNode : BaseNode
    { 
        
        public FireProjectileNode(BlackBoard bb)
        {
            this.blackBoard = bb;
        }

        public override BehaviourTreeStatus Tick()
        {
            Debug.Log("fire projectile");

            Rigidbody projectile = GameObject.Instantiate(blackBoard.ProjectilePrefab, blackBoard.Boss.transform.position + Vector3.up*3, Quaternion.identity);
            projectile.velocity = blackBoard.Boss.transform.forward * 10;

            return BehaviourTreeStatus.Succes;
        }
    }
}