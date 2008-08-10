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
        public bool AButton
        {
            get { return WasKeyPressed(keyboardAssignment.A); }
        }

        public bool BButton
        {
            get { return WasKeyPressed(keyboardAssignment.B); }
        }

        public bool XButton
        {
            get { return WasKeyPressed(keyboardAssignment.X); }
        }

        public bool YButton
        {
            get { return WasKeyPressed(keyboardAssignment.Y); }
        }

        public bool StartButton
        {
            get { return WasKeyPressed(keyboardAssignment.Start); }
        }

        public bool BackButton
        {
            get { return WasKeyPressed(keyboardAssignment.Back); }
        }

        public bool LStickClick
        {
            get { return WasKeyPressed(keyboardAssignment.LeftStick); }
        }

        public bool RStickClick
        {
            get { return WasKeyPressed(keyboardAssignment.RightStick); }
        }

        public bool RBumper
        {
            get { return WasKeyPressed(keyboardAssignment.RightShoulder); }
        }

        public bool LBumper
        {
            get { return WasKeyPressed(keyboardAssignment.LeftShoulder); }
        }

        public float LStickX
        {
            get { return GetInputAmountForKeyboardRange(keyboardAssignment.LeftThumbstickLeft, keyboardAssignment.LeftThumbstickRight); }
        }

        public float LStickY
        {
            get { return GetInputAmountForKeyboardRange(keyboardAssignment.LeftThumbstickUp, keyboardAssignment.LeftThumbstickDown); }
        }

        public float RStickX
        {
            get { return GetInputAmountForKeyboardRange(keyboardAssignment.RightThumbstickLeft, keyboardAssignment.RightThumbstickRight); }
        }

        public float RStickY
        {
            get { return GetInputAmountForKeyboardRange(keyboardAssignment.RightThumbstickUp, keyboardAssignment.RightThumbstickDown); }
        }

        public float LTrigger
        {
            get { return (currentKeyboardState.IsKeyDown(keyboardAssignment.LeftTrigger) ? 1f : 0f); }
        }

        public float RTrigger
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

        public void UpdateMouseState(ref MouseState mouseState)
        {
            ;
        }
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

        public bool IsKeyDown(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key));
        }

        public bool IsHoldingKey(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyDown(key));
        }

        public bool WasKeyPressed(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key));
        }

        public bool HasReleasedKey(Keys key)
        {
            return (currentKeyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key));
        }
    }
}
