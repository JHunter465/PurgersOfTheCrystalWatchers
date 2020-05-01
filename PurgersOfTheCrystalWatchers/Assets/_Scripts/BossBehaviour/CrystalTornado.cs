using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class CrystalTornado : MonoBehaviour
    {
        public float LifeTime = 10f;
        public float Speed = 10f;

        private GameObject player;

        public void Init(GameObject plyr)
        {
            player = plyr;
            this.gameObject.DeactivateAfterTime(this, LifeTime);
        }

        private void LateUpdate()
        {
            if (player == null) return;

            transform.LerpTransform(this, player.transform.position, Speed);
        }
    }
}
