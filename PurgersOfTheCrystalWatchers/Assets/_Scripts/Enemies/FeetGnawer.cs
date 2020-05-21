using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using static Invector.vCharacterController.vThirdPersonMotor;
namespace POTCW
{
    public class FeetGnawer : BaseEnemy
    {
        [SerializeField] private float slowDistance, slowPercentage;

        [SerializeField] private int buttonsPressesForRelease;

        public GenericInput AntiSlowKey = new GenericInput("Horizontal", "LeftAnalogHorizontal", "Horizontal");

        private int currentButtonPresses;

        vThirdPersonController controller;

        private bool slowed;

        protected override void OnTriggerStay(Collider other)
        {
            if (!slowed)
            {
                base.OnTriggerStay(other);
            }
        }

        protected override void OnTriggerExit(Collider other)
        {
            if (!slowed)
            {
                base.OnTriggerExit(other);
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            currentSpeed = BaseSpeed;
        }

        protected override void Update()
        {
            base.Update();
            if (!slowed)
            {
                CheckSlowPlayer();
            }
            else
            {
                CheckSlowStopInput();
                StickToPlayer();
            }
        }

        private void CheckSlowPlayer()
        {
            //return out of method if there is no player assigned
            if (player == null)
            {
                return;
            }

            if (Vector3.Distance(transform.position, player.position) < slowDistance)
            {
                slowed = true;
                SlowPlayer();
            }

        }

        private void CheckSlowStopInput()
        {
            if (AntiSlowKey.GetButtonDown())
            {
                currentButtonPresses++;
            }
            if (currentButtonPresses >= buttonsPressesForRelease)
            {
                DisableSlow();
            }
        }

        private void SlowPlayer()
        {
            GetComponent<CapsuleCollider>().enabled = false;
            transform.parent = player.transform;
            controller = player.GetComponent<vThirdPersonController>();
            vMovementSpeed movementSpeed = controller.freeSpeed;
            movementSpeed.walkSpeed -= controller.BaseSpeed.walkSpeed * (slowPercentage / 100);
            movementSpeed.runningSpeed -= controller.BaseSpeed.runningSpeed * (slowPercentage / 100);
            movementSpeed.sprintSpeed -= controller.BaseSpeed.sprintSpeed * (slowPercentage / 100);

            controller.SetControllerMoveSpeed(movementSpeed);
        }

        private void DisableSlow()
        {
            vMovementSpeed movementSpeed = controller.freeSpeed;

            movementSpeed.walkSpeed += controller.BaseSpeed.walkSpeed * (slowPercentage / 100);
            movementSpeed.runningSpeed += controller.BaseSpeed.runningSpeed * (slowPercentage / 100);
            movementSpeed.sprintSpeed += controller.BaseSpeed.sprintSpeed * (slowPercentage / 100);

            controller.SetControllerMoveSpeed(movementSpeed);

            gameObject.SetActive(false);
        }

        private void StickToPlayer()
        {
            transform.position = player.position;
        }
    }
}
