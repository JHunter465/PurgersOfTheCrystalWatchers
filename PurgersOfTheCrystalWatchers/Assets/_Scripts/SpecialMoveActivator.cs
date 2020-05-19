using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using BasHelpers;

namespace POTCW
{
    public class SpecialMoveActivator : MonoBehaviour
    {
        public TextMeshProUGUI FeedbackTextField;
        public SpecialMode ActivateSpecialModeType;
        
        public void ActivateSpecialMode()
        {
            Debug.Log("Activated: " + ActivateSpecialModeType.ToString());
            FeedbackTextField.gameObject.SetActive(true);
            FeedbackTextField.text = "Boss Mode Switched To: " + ActivateSpecialModeType.ToString();
            FeedbackTextField.gameObject.DeactivateAfterTime(this, 2f);
            EventManager<SpecialMode>.BroadCast(EVENT.SwitchBossSpecialModeType, ActivateSpecialModeType);
        }
    }
}
