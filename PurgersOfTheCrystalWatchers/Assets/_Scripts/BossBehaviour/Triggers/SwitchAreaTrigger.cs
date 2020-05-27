using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class SwitchAreaTrigger : MonoBehaviour
    {
        public SpecialMode Area;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.HasComponent<EnemyAgent>())
            {
                EventManager<SpecialMode>.BroadCast(EVENT.SwitchInCurrentArea, Area);
                return;
            }
        }
    }
}
