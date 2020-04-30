using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            if (Vector3.Distance(transform.position, player.transform.position) > 2f)
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
