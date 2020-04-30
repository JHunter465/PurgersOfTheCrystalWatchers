using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class BaseMinion : BaseEntity
    {
        public float AttackRange = 2f;
        public float MovementSpeed = 5f;
        public float LifeTime = 10f;

        private GameObject player;

        public void Init(GameObject playerRef)
        {
            player = playerRef;
            this.gameObject.DeactivateAfterTime(this, LifeTime);
        }

        private void Update()
        {
            if (player == null) return;

            if (Vector3.Distance(transform.position, player.transform.position) > AttackRange)
            {
                float step = MovementSpeed * Time.deltaTime;
                //step by step move towards the player
                Vector3 deltaPos = transform.position - player.transform.position;
                Vector3 tmpPosition = transform.position;
                transform.position = Vector3.MoveTowards(tmpPosition, player.transform.position, step);
            }
        }
    }
}
