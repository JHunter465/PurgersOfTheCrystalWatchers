using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace POTCW
{
    public class BossUIManager : MonoBehaviour
    {
        public GameObject HealthBar;
        public TextMeshProUGUI CurrentActiveBossMode;
        public TextMeshProUGUI CurrentArea;
        public Image PlayerDetectionStatus;
        public CameraShake[] CameraShakes;
        public float ShakeDuration = 2f;

        protected SpecialMode activeMode;
        protected SpecialMode currentArea;

        private void Awake()
        {
            EventManager<SpecialMode>.AddHandler(EVENT.SwitchBossSpecialModeType, UpdateCurrentActiveBossMode);
            EventManager<SpecialMode>.AddHandler(EVENT.SwitchInCurrentArea, UpdateCurrentArea);
            EventManager<int>.AddHandler(EVENT.GetPlayerDistance, UpdatePlayerDetectionStatus);
            EventManager<bool>.AddHandler(EVENT.ActivateBoss, ActivateHealthBar);
        }

        private void UpdateCurrentActiveBossMode(SpecialMode activeMode)
        {
            CurrentActiveBossMode.text = activeMode.ToString() + " Mode";
            this.activeMode = activeMode;
            if (currentArea == this.activeMode)
            {
                CurrentActiveBossMode.color = Color.red;
                foreach(var shake in CameraShakes)
                {
                    shake.enabled = true;
                    shake.shakeDuration = ShakeDuration;
                }
            }
            else
            {
                foreach (var shake in CameraShakes)
                {
                    shake.enabled = false;
                    shake.shakeDuration = ShakeDuration;
                }
                CurrentActiveBossMode.color = Color.yellow;
            }
            //CurrentActiveBossMode.color = currentArea == this.activeMode ? Color.red : Color.yellow;
        }

        private void UpdateCurrentArea(SpecialMode area)
        {           
            CurrentArea.text = "Area: " + area;
            this.currentArea = area;
            UpdateCurrentActiveBossMode(activeMode);
        }

        private void ActivateHealthBar(bool value)
        {
            if (value)
                HealthBar.SetActive(true);
            else
                HealthBar.SetActive(false);                
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
