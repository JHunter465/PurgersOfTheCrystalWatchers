using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace POTCW
{
    public class BossUIManager : MonoBehaviour
    {
        public TextMeshProUGUI CurrentActiveBossMode;
        public TextMeshProUGUI CurrentArea;
        public Image PlayerDetectionStatus;

        private void Start()
        {
            EventManager<SpecialMode>.AddHandler(EVENT.SwitchBossSpecialModeType, UpdateCurrentActiveBossMode);
            EventManager<SpecialMode>.AddHandler(EVENT.SwitchInCurrentArea, UpdateCurrentArea);
            EventManager<int>.AddHandler(EVENT.GetPlayerDistance, UpdatePlayerDetectionStatus);
        }

        private void UpdateCurrentActiveBossMode(SpecialMode activeMode)
        {
            CurrentActiveBossMode.text = activeMode.ToString();
        }

        private void UpdateCurrentArea(SpecialMode area)
        {
            CurrentArea.text = "Area: " + area;
        }

        private void UpdatePlayerDetectionStatus(int check)
        {
            switch(check)
            {
                case 0:
                    PlayerDetectionStatus.color = Color.green;
                    break;
                case 1:
                    PlayerDetectionStatus.color = Color.yellow;
                    break;
                case 2: PlayerDetectionStatus.color = Color.red;
                    break;
                default:
                    PlayerDetectionStatus.color = Color.green;
                    break;
            }
        }
    }
}
