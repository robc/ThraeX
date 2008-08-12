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
            get { return WasKeyPressed(keyboardAssignment.A); }
        }

        public bool B
        {
            get { return WasKeyPressed(keyboardAssignment.B); }
        }

        public bool X
        {
            get { return WasKeyPressed(keyboardAssignment.X); }
        }

        public bool Y
        {
            get { return WasKeyPressed(keyboardAssignment.Y); }
        }

        public bool Start
        {
            get { return WasKeyPressed(keyboardAssignment.Start); }
        }

        public bool Back
        {
            get { return WasKeyPressed(keyboardAssignment.Back); }
        }

        public bool LeftStick
        {
            get { return WasKeyPressed(keyboardAssignment.LeftStick); }
        }

        public bool RightStick
        {
            get { return WasKeyPressed(keyboardAssignment.RightStick); }
        }

        public bool RightShoulder
        {
            get { return WasKeyPressed(keyboardAssignment.RightShoulder); }
        }

        public bool LeftShoulder
        {
            get { return WasKeyPressed(keyboardAssignment.LeftShoulder); }
        }

        public float LeftStickX
        {
            get { return GetInputAmountForKeyboardRange(keyboardAssignment.LeftThumbstickLeft, keyboardAssignment.LeftThumbstickRight); }
        }

        public float LeftStickY
        {
            get { return GetInputAmountForKeyboardRange(keyboardAssignment.LeftThumbstickUp, keyboardAssignment.LeftThumbstickDown); }
        }

        public float RightStickX
        {
            get { return GetInputAmountForKeyboardRange(keyboardAssignment.RightThumbstickLeft, keyboardAssignment.RightThumbstickRight); }
        }

        public float RightStickY
        {
            get { return GetInputAmountForKeyboardRange(keyboardAssignment.RightThumbstickUp, keyboardAssignment.RightThumbstickDown); }
        }

        public float LeftTrigger
        {
            get { return (currentKeyboardState.IsKeyDown(keyboardAssignment.LeftTrigger) ? 1f : 0f); }
        }

        public float RightTrigger
        {
            get { return (currentKeyboardState.IsKeyDown(keyboardAssignment.RightTrigger) ? 1f : 0f); }
        }

        public bool DPadUp
        {
            get { return IsKeyDown(keyboardAssignment.DPadUp); }
        }

        public bool DPadDown
        {
            get { return IsKeyDown(keyboardAssignment.DPadDown); }
        }

        public bool DPadLeft
        {
            get { return IsKeyDown(keyboardAssignment.DPadLeft); }
        }

        public bool DPadRight
        {
            get { return IsKeyDown(keyboardAssignment.DPadRight); }
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
