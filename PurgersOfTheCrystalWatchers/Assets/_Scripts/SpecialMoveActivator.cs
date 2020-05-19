using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class SpecialMoveActivator : MonoBehaviour
    {
        public SpecialMode ActivateSpecialModeType;

        public void ActivateSpecialMode()
        {
            Debug.Log("Activated: " + ActivateSpecialModeType.ToString());
            EventManager<SpecialMode>.BroadCast(EVENT.SwitchBossSpecialModeType, ActivateSpecialModeType);
        }
    }
}
