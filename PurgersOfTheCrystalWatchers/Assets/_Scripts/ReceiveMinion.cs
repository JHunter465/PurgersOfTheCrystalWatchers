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
        public int ID;

        private Dictionary<int, MinionType> container = new Dictionary<int, MinionType>();

        private void Start()
        {
            container.Add(ID, RequiredMinionType);
        }

        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.HasComponent<IMinion>())
            {
                IMinion minion = other.gameObject.GetComponent<IMinion>();

                if (minion.GetMinionType() == RequiredMinionType)
                {
                    EventManager<Dictionary<int, MinionType>>.BroadCast(EVENT.CollectMinions, container);
                    other.gameObject.SetActive(false);
                }
                else
                    return;
            }
        }
    }
}
