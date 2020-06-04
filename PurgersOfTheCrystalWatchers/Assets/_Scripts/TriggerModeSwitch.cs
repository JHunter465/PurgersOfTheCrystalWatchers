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
            if(other.gameObject.HasComponent<IInteractable>())
            {
                IInteractable activator = other.gameObject.GetComponent<IInteractable>();
                activator.Interact();

                this.gameObject.SetActive(false);
            }
        }
    }
}
