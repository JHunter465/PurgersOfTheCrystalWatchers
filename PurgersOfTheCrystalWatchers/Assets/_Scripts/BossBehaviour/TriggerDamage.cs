using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using Invector;
using BasHelpers;

namespace POTCW
{
    public class TriggerDamage : MonoBehaviour
    {
        public vTagMask TriggerTag;
        public int Damage;
        public float LifeTime = 2f;
        public bool DeactivateAfterAwake = true;

        private void OnEnable()
        {
            if(DeactivateAfterAwake)
                this.gameObject.DeactivateAfterTime(this, LifeTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            vDamage dmg = new vDamage(Damage);
            
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Damage player with: " + dmg.damageValue);
                var x = other.GetComponent<vThirdPersonController>();
                x.TakeDamage(dmg);
                Debug.Log(x);

            }
        }

        private void OnDrawGizmos()
        {
            if (GetComponent<SphereCollider>() == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, GetComponent<SphereCollider>().radius);
        }
    }
}
