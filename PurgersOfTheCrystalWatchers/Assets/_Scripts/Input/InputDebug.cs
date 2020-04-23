using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace POTCW
{
    public class InputDebug : MonoBehaviour
    {
        private InputState inputState;
        private void Start()
        {
            inputState = GetComponent<InputState>();
        }
        private void Update()
        {
            var button = inputState.GetButtonValue(Buttons.A);
            if(button)
            {
                Debug.Log("Input done" + inputState.GetButtonHoldTime(Buttons.A));
            }
        }
    }
}
