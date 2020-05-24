using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class EnemyTrigger : MonoBehaviour
    {
        BaseEnemy enemy;

        private void Awake()
        {
            enemy = GetComponentInParent<BaseEnemy>();
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            if (enemy.player == null && other.tag == "Player")
            {
                enemy.animator.SetBool("Running", true);
                enemy.player = other.transform;
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                enemy.animator.SetBool("Running", false);
                enemy.player = null;
            }
        }
    }
}

