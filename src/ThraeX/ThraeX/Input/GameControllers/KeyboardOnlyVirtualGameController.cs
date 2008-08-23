using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input.GameControllers
{
    public class KeyboardOnlyVirtualGameController : AbstractGameController, IVirtualGameController
    {
        public KeyboardOnlyVirtualGameController(KeyboardAssignment keyboardAssignment) : base()
        {
            this.keyboardAssignment = keyboardAssignment;
        }

        #region IVirtualGameController Members
        public bool A
        {
            get { return IsKeyReleased(keyboardAssignment.A); }
        }

        public bool B
        {
            get { return IsKeyReleased(keyboardAssignment.B); }
        }

        public bool X
        {
            get { return IsKeyReleased(keyboardAssignment.X); }
        }

        public bool Y
        {
            get { return IsKeyReleased(keyboardAssignment.Y); }
        }

        public bool Start
        {
            get { return IsKeyReleased(keyboardAssignment.Start); }
        }

        public bool Back
        {
            get { return IsKeyReleased(keyboardAssignment.Back); }
        }

        public bool LeftStick
        {
            get { return IsKeyReleased(keyboardAssignment.LeftStick); }
        }

        public bool RightStick
        {
            get { return IsKeyReleased(keyboardAssignment.RightStick); }
        }

        public bool RightShoulder
        {
            get { return IsKeyReleased(keyboardAssignment.RightShoulder); }
        }

        public bool LeftShoulder
        {
            get { return IsKeyReleased(keyboardAssignment.LeftShoulder); }
        }

        public float LeftStickX
        {
            get { return GetThumbstickAxisAmountForKeys(keyboardAssignment.LeftThumbstickLeft, keyboardAssignment.LeftThumbstickRight); }
        }

        public float LeftStickY
        {
            get { return GetThumbstickAxisAmountForKeys(keyboardAssignment.LeftThumbstickDown, keyboardAssignment.LeftThumbstickUp); }
        }

        public bool LeftThumbstickLeft
        {
            get { return IsKeyReleased(keyboardAssignment.LeftThumbstickLeft); }
        }

        public bool LeftThumbstickRight
        {
            get { return IsKeyReleased(keyboardAssignment.LeftThumbstickRight); }
        }

        public bool LeftThumbstickUp
        {
            get { return IsKeyReleased(keyboardAssignment.LeftThumbstickUp); }
        }

        public bool LeftThumbstickDown
        {
            get { return IsKeyReleased(keyboardAssignment.LeftThumbstickDown); }
        }

        public float RightStickX
        {
            get { return GetThumbstickAxisAmountForKeys(keyboardAssignment.RightThumbstickLeft, keyboardAssignment.RightThumbstickRight); }
        }

        public float RightStickY
        {
            get { return GetThumbstickAxisAmountForKeys(keyboardAssignment.RightThumbstickDown, keyboardAssignment.RightThumbstickUp); }
        }

        public bool RightThumbstickLeft
        {
            get { return IsKeyReleased(keyboardAssignment.RightThumbstickLeft); }
        }

        public bool RightThumbstickRight
        {
            get { return IsKeyReleased(keyboardAssignment.RightThumbstickRight); }
        }

        public bool RightThumbstickUp
        {
            get { return IsKeyReleased(keyboardAssignment.RightThumbstickUp); }
        }

        public bool RightThumbstickDown
        {
            get { return IsKeyReleased(keyboardAssignment.RightThumbstickDown); }
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
        #endregion
    }
}
