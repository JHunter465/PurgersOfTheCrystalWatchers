using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class SpecialMoveActivator : MonoBehaviour, IInteractable
    {
        public TextMeshProUGUI FeedbackTextField;
        public SpecialMode ActivateSpecialModeType;
        
        public void Interact()
        {
            Debug.Log("Activated: " + ActivateSpecialModeType.ToString());
            FeedbackTextField.gameObject.SetActive(true);
            FeedbackTextField.text = "Boss Mode Switched To: " + ActivateSpecialModeType.ToString();
            FeedbackTextField.gameObject.DeactivateAfterTime(this, 2f);
            EventManager<SpecialMode>.BroadCast(EVENT.SwitchBossSpecialModeType, ActivateSpecialModeType);
        }
    }
}
