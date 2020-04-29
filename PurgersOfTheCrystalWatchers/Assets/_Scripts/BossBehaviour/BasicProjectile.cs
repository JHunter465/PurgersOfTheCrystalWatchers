using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class BasicProjectile : MonoBehaviour
    {
        public float Speed = 100;
        public float DeactivationTime = 10;

        private Rigidbody rBody;

        private void Start()
        {
            if (GetComponent<Rigidbody>() == null) return;

            rBody = GetComponent<Rigidbody>();

            

            this.gameObject.DeactivateAfterTime(this, DeactivationTime);


        }       
    }
}
