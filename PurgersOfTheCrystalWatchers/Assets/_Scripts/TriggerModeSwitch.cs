using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class TriggerModeSwitch : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.HasComponent<SpecialMoveActivator>())
            {
                SpecialMoveActivator activator = other.gameObject.GetComponent<SpecialMoveActivator>();
                activator.ActivateSpecialMode();

                this.gameObject.SetActive(false);
            }
        }
    }
}
