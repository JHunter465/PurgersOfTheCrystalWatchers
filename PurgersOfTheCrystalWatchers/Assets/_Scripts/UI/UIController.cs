using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Invector.vCharacterController;

namespace POTCW
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Slider healthBar, crystalBar;
        [SerializeField] private vThirdPersonController controller;

        private void Awake()
        {
            healthBar.maxValue = controller.MaxHealth;
            healthBar.value = controller.currentHealth;

            crystalBar.maxValue = controller.maxStamina;
            crystalBar.value = controller.maxStamina;
        }

        public void ChangeHealth(float value)
        {
            healthBar.value -= value;
        }

        public void ChangeStamina(float value)
        {
            crystalBar.value -= value;
        }

        public void AddStamina(float value)
        {
            crystalBar.value += value;
        }
    }
}

