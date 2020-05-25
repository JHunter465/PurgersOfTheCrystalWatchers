using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class Sword : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            BaseEnemy enemy = other.GetComponent<BaseEnemy>();
            if (enemy != null)
            {
                //enemy.TakeDamage(1);
            }
        }
    }
}
