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

        public void Init(GameObject plyr)
        {
            transform.LerpTransform(this, plyr.transform.position, Speed);
            this.gameObject.DeactivateAfterTime(this, LifeTime);
        }
    }
}
