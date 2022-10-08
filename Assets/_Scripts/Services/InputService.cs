using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Services
{
    public class InputService
    {
        public bool FireButtonPressed, FlyButtonPressed, FireLaserButtonPressed;
        public Vector2 RotateValue;

        public InputService(PlayerInput playerInput)
        {
            foreach (var inputActionEvent in playerInput.actionEvents.Where(inputActionEvent =>
                         inputActionEvent.actionName.Contains("Player")))
                switch (inputActionEvent.actionName)
                {
                    case "Player/Fire[/XInputControllerWindows/rightShoulder,/Keyboard/space]":
                        inputActionEvent.AddListener(FireButtonHandle);
                        break;
                    case "Player/FlyUp[/Keyboard/upArrow,/XInputControllerWindows/buttonSouth]":
                        inputActionEvent.AddListener(FlyButtonHandle);
                        break;
                    case "Player/Rotate[/XInputControllerWindows/dpad,/Mouse/delta]":
                        inputActionEvent.AddListener(RotateHandle);
                        break;
                    case "Player/FireLaser[/XInputControllerWindows/leftTrigger,/Keyboard/shift]":
                        inputActionEvent.AddListener(FireLaserButtonHandle);
                        break;
                    case "Player/RotateRight[/Keyboard/rightArrow]":
                        inputActionEvent.AddListener(RotateRightHandle);
                        break;
                    case "Player/RotateLeft[/Keyboard/leftArrow]":
                        inputActionEvent.AddListener(RotateLeftHandle);
                        break;
                }
        }

        private void FireButtonHandle(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            FireButtonPressed = value > 0.5f;
        }

        private void FireLaserButtonHandle(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            FireLaserButtonPressed = value > 0.5f;
        }

        private void FlyButtonHandle(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            FlyButtonPressed = value > 0.5f;
        }

        private void RotateHandle(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            RotateValue = value;
        }

        private void RotateRightHandle(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            RotateValue = new Vector2(value > 0.5f ? 1 : 0, 0);
        }

        private void RotateLeftHandle(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            RotateValue = new Vector2(value > 0.5f ? -1 : 0, 0);
        }
    }
}