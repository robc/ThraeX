using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input.GameControllers
{
    public class KeyboardOnlyVirtualGameController : IVirtualGameController
    {
        private KeyboardAssignment keyboardAssignment;
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public KeyboardOnlyVirtualGameController(KeyboardAssignment keyboardAssignment)
        {
            this.keyboardAssignment = keyboardAssignment;
        }

        #region IVirtualGameController Members
        public bool A
        {
            get { return WasKeyPressed(keyboardAssignment.A.Value); }
        }

        public bool B
        {
            get { return WasKeyPressed(keyboardAssignment.B.Value); }
        }

        public bool X
        {
            get { return WasKeyPressed(keyboardAssignment.X.Value); }
        }

        public bool Y
        {
            get { return WasKeyPressed(keyboardAssignment.Y.Value); }
        }

        public bool Start
        {
            get { return WasKeyPressed(keyboardAssignment.Start.Value); }
        }

        public bool Back
        {
            get { return WasKeyPressed(keyboardAssignment.Back.Value); }
        }

        public bool LeftStick
        {
            get { return WasKeyPressed(keyboardAssignment.LeftStick.Value); }
        }

        public bool RightStick
        {
            get { return WasKeyPressed(keyboardAssignment.RightStick.Value); }
        }

        public bool RightShoulder
        {
            get { return WasKeyPressed(keyboardAssignment.RightShoulder.Value); }
        }

        public bool LeftShoulder
        {
            get { return WasKeyPressed(keyboardAssignment.LeftShoulder.Value); }
        }

        public float LeftStickX
        {
            get { return GetInputAmountForKeyboardRange(keyboardAssignment.LeftThumbstickLeft.Value, keyboardAssignment.LeftThumbstickRight.Value); }
        }

        public float LeftStickY
        {
            get { return GetInputAmountForKeyboardRange(keyboardAssignment.LeftThumbstickUp.Value, keyboardAssignment.LeftThumbstickDown.Value); }
        }

        public bool LeftThumbstickLeft
        {
            get { return WasKeyPressed(keyboardAssignment.LeftThumbstickLeft.Value); }
        }

        public bool LeftThumbstickRight
        {
            get { return WasKeyPressed(keyboardAssignment.LeftThumbstickRight.Value); }
        }

        public bool LeftThumbstickUp
        {
            get { return WasKeyPressed(keyboardAssignment.LeftThumbstickUp.Value); }
        }

        public bool LeftThumbstickDown
        {
            get { return WasKeyPressed(keyboardAssignment.LeftThumbstickDown.Value); }
        }

        public float RightStickX
        {
            get { return GetInputAmountForKeyboardRange(keyboardAssignment.RightThumbstickLeft.Value, keyboardAssignment.RightThumbstickRight.Value); }
        }

        public float RightStickY
        {
            get { return GetInputAmountForKeyboardRange(keyboardAssignment.RightThumbstickUp.Value, keyboardAssignment.RightThumbstickDown.Value); }
        }

        public bool RightThumbstickLeft
        {
            get { return WasKeyPressed(keyboardAssignment.RightThumbstickLeft.Value); }
        }

        public bool RightThumbstickRight
        {
            get { return WasKeyPressed(keyboardAssignment.RightThumbstickRight.Value); }
        }

        public bool RightThumbstickUp
        {
            get { return WasKeyPressed(keyboardAssignment.RightThumbstickUp.Value); }
        }

        public bool RightThumbstickDown
        {
            get { return WasKeyPressed(keyboardAssignment.RightThumbstickDown.Value); }
        }

        public float LeftTrigger
        {
            get { return (currentKeyboardState.IsKeyDown(keyboardAssignment.LeftTrigger.Value) ? 1f : 0f); }
        }

        public float RightTrigger
        {
            get { return (currentKeyboardState.IsKeyDown(keyboardAssignment.RightTrigger.Value) ? 1f : 0f); }
        }

        public bool DPadUp
        {
            get { return (keyboardAssignment.DPadUp == null ? false : IsKeyDown(keyboardAssignment.DPadUp.Value)); }
        }

        public bool DPadDown
        {
            get { return (keyboardAssignment.DPadDown == null ? false : IsKeyDown(keyboardAssignment.DPadDown.Value)); }
        }

        public bool DPadLeft
        {
            get { return (keyboardAssignment.DPadLeft == null ? false : IsKeyDown(keyboardAssignment.DPadLeft.Value)); }
        }

        public bool DPadRight
        {
            get { return (keyboardAssignment.DPadRight == null ? false : IsKeyDown(keyboardAssignment.DPadRight.Value)); }
        }

        public KeyboardAssignment KeyboardAssignment
        {
            get { return this.keyboardAssignment; }
            set { this.keyboardAssignment = value; }
        }

        public void UpdateKeyboardState(ref KeyboardState keyboardState)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = keyboardState;
        }

        public void UpdateGamePadState(ref GamePadState gamePadState)
        {
            ;
        }

        #if !XBOX
        public void UpdateMouseState(ref MouseState mouseState)
        {
            ;
        }
        #endif
        #endregion

        private float GetInputAmountForKeyboardRange(Keys negativeKey, Keys positiveKey)
        {
            float result = 0f;

            if (currentKeyboardState.IsKeyDown(negativeKey))
                result = -1f;
            else if (currentKeyboardState.IsKeyDown(positiveKey))
                result = 1f;

            return result;
        }

        private bool IsKeyDown(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key));
        }

        private bool IsHoldingKey(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyDown(key));
        }

        private bool WasKeyPressed(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key));
        }

        private bool HasReleasedKey(Keys key)
        {
            return (currentKeyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key));
        }
    }
}
