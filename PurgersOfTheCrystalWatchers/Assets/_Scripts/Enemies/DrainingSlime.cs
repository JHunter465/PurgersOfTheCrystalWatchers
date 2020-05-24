using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace POTCW
{
    public class DrainingSlime : BaseEnemy
    {
        [SerializeField] private float drainDistance;

        protected override void Update()
        {
            base.Update();
            DrainCrystal();
        }

        private void DrainCrystal()
        {
            if(Vector3.Distance(transform.position, player.position) < drainDistance)
            {

            }
        }
    }
}