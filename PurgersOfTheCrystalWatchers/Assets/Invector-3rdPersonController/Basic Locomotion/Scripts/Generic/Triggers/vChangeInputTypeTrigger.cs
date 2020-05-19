using UnityEngine;
using System.Collections;
using Invector.vCharacterController;
using UnityEngine.Events;
namespace Invector.vItemManager
{
    
    public class vChangeInputTypeTrigger : MonoBehaviour
    {
        [Header("Events called when InputType changed")]
        public UnityEvent OnChangeToKeyboard;
        public UnityEvent OnChangeToMobile;
        public UnityEvent OnChangeToJoystick;

        public Camera MyCam;
        public vInput vInpuut;

        void Start()
        {/*
            vCamera.vThirdPersonCamera TPC = null;
            vInpuut.onChangeInputType -= OnChangeInput;
            vInpuut.onChangeInputType += OnChangeInput;
            OnChangeInput(vInpuut.inputDevice);
            */
        }

        public void OnChangeInput(InputDevice type)
        {
            switch(type)
            {
                case InputDevice.MouseKeyboard:
                    OnChangeToKeyboard.Invoke();
                    break;
                case InputDevice.Mobile:
                    OnChangeToMobile.Invoke();
                    break;
                case InputDevice.Joystick:
                    OnChangeToJoystick.Invoke();
                    break;
            }
        }
    }
    
}
