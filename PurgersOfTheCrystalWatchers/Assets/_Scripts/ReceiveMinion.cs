using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public enum MinionType
    {
        UnstableCrystalGolem = 0,
        FeetGnawer = 1,
        DrainSlime = 2,
    }

    public class ReceiveMinion : MonoBehaviour
    {
        public MinionType RequiredMinionType;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.HasComponent<IMinion>())
            {
                IMinion minion = other.gameObject.GetComponent<IMinion>();

                if (minion.GetMinionType() == RequiredMinionType)
                    EventManager<MinionType>.BroadCast(EVENT.CollectMinions, RequiredMinionType);
                else
                    return;
            }
        }
    }
}
