using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input.GameControllers
{
    public class ArcadeStickGameController : AbstractGameController, IVirtualGameController
    {
        public ArcadeStickGameController() : base()
        { }

        #region IVirtualGameController Members
        public bool A
        {
            get { return IsButtonReleased(Buttons.A, keyboardAssignment.A); }
        }

        public bool B
        {
            get { return IsButtonReleased(Buttons.B, keyboardAssignment.B); }
        }

        public bool X
        {
            get { return IsButtonReleased(Buttons.X, keyboardAssignment.X); }
        }

        public bool Y
        {
            get { return IsButtonReleased(Buttons.Y, keyboardAssignment.Y); }
        }

        public bool Start
        {
            get { return IsButtonReleased(Buttons.Start, keyboardAssignment.Start); }
        }

        public bool Back
        {
            get { return IsButtonReleased(Buttons.Back, keyboardAssignment.Back); }
        }

        public float LeftStickX
        {
            get
            {
                if (IsButtonDown(Buttons.DPadLeft, keyboardAssignment.DPadLeft))
                    return -1f;
                else if (IsButtonDown(Buttons.DPadRight, keyboardAssignment.DPadRight))
                    return 1f;
                else
                    return 0f;
            }
        }

        public float LeftStickY
        {
            get
            {
                if (IsButtonDown(Buttons.DPadDown, keyboardAssignment.DPadDown))
                    return -1f;
                else if (IsButtonDown(Buttons.DPadUp, keyboardAssignment.DPadUp))
                    return 1f;
                else
                    return 0f;
            }
        }

        public bool LeftThumbstickUp
        {
            get { return DPadUp; }
        }

        public bool LeftThumbstickDown
        {
            get { return DPadDown; }
        }

        public bool LeftThumbstickLeft
        {
            get { return DPadLeft; }
        }

        public bool LeftThumbstickRight
        {
            get { return DPadRight; }
        }

        public bool LeftStick
        {
            get { return false; }
        }

        public float RightStickX
        {
            get { return 0f; }
        }

        public float RightStickY
        {
            get { return 0f; }
        }

        public bool RightThumbstickUp
        {
            get { return false; }
        }

        public bool RightThumbstickDown
        {
            get { return false; }
        }

        public bool RightThumbstickLeft
        {
            get { return false; }
        }

        public bool RightThumbstickRight
        {
            get { return false; }
        }

        public bool RightStick
        {
            get { return false; }
        }

        public float LeftTrigger
        {
            get { return GetTriggerAmount(currentGamePadState.Triggers.Left, keyboardAssignment.LeftTrigger); }
        }

        public float RightTrigger
        {
            get { return GetTriggerAmount(currentGamePadState.Triggers.Right, keyboardAssignment.RightTrigger); }
        }

        public bool RightShoulder
        {
            get { return IsButtonReleased(Buttons.RightShoulder, keyboardAssignment.RightShoulder); }
        }

        public bool LeftShoulder
        {
            get { return IsButtonReleased(Buttons.LeftShoulder, keyboardAssignment.LeftShoulder); }
        }

        public bool DPadUp
        {
            get { return IsButtonReleased(Buttons.DPadUp, keyboardAssignment.DPadUp); }
        }

        public bool DPadDown
        {
            get { return IsButtonReleased(Buttons.DPadDown, keyboardAssignment.DPadDown); }
        }

        public bool DPadLeft
        {
            get { return IsButtonReleased(Buttons.DPadLeft, keyboardAssignment.DPadLeft); }
        }

        public bool DPadRight
        {
            get { return IsButtonReleased(Buttons.DPadRight, keyboardAssignment.DPadRight); }
        }
        #endregion
    }
}
