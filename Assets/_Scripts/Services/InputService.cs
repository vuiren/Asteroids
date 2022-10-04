using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Services
{
    public class InputService : MonoBehaviour
    {
        public bool FireButtonPressed, FlyButtonPressed, FireLaserButtonPressed;
        public Vector2 RotateValue;

        public void FireButtonHandle(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            FireButtonPressed = value > 0.5f;
        }

        public void FireLaserButtonHandle(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            FireLaserButtonPressed = value > 0.5f;
        }

        public void FlyButtonHandle(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            FlyButtonPressed = value > 0.5f;
        }

        public void RotateHandle(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            RotateValue = value;
        }

        public void RotateRightHandle(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            RotateValue = new Vector2(value > 0.5f ? 1 : 0, 0);
        }

        public void RotateLeftHandle(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            RotateValue = new Vector2(value > 0.5f ? -1 : 0, 0);
        }
    }
}