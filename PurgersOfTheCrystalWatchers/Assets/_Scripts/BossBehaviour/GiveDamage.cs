using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using Invector;
using BasHelpers;

namespace POTCW
{
    public class GiveDamage : MonoBehaviour
    {
        public int Damage;
        public float LifeTime = 2f;

        private void OnTriggerEnter(Collider other)
        {
            vDamage dmg = new vDamage(Damage);
            
            if (other.gameObject.tag == "Player")
            {
                other.GetComponent<vThirdPersonController>().TakeDamage(dmg);
                this.gameObject.DeactivateAfterTime(this, LifeTime);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, GetComponent<SphereCollider>().radius);
        }
    }
}
