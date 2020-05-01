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

        private GameObject player;

        public void Init(GameObject playerRef)
        {
            player = playerRef;
        }

        private void Update()
        {
            if (player == null) return;

            transform.LookAt(player.transform);
            if (Vector3.Distance(transform.position, player.transform.position) > AttackRange)
            {
                float step = MovementSpeed * Time.deltaTime;
                //step by step move towards the  
                Vector3 deltaPos = transform.position - player.transform.position;
                Vector3 tmpPosition = transform.position;
                transform.position = Vector3.MoveTowards(tmpPosition, player.transform.position, step);
            }
        }
    }
}
