using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input.GameControllers
{
    public struct KeyboardAssignment
    {
        #region Fields
        public Keys A;
        public Keys B;
        public Keys X;
        public Keys Y;
        public Keys LeftTrigger;
        public Keys RightTrigger;
        public Keys LeftShoulder;
        public Keys RightShoulder;
        public Keys LeftStick;
        public Keys RightStick;
        public Keys Start;
        public Keys Back;
        public Keys LeftThumbstickUp;
        public Keys LeftThumbstickDown;
        public Keys LeftThumbstickLeft;
        public Keys LeftThumbstickRight;
        public Keys RightThumbstickUp;
        public Keys RightThumbstickDown;
        public Keys RightThumbstickLeft;
        public Keys RightThumbstickRight;
        public Keys DPadUp;
        public Keys DPadDown;
        public Keys DPadLeft;
        public Keys DPadRight;
        #endregion

        public KeyboardAssignment(
            Keys A,
            Keys B,
            Keys X,
            Keys Y,
            Keys Start,
            Keys Back,
            Keys LeftShoulder,
            Keys RightShoulder,
            Keys LeftTrigger,
            Keys RightTrigger,
            Keys LeftStick,
            Keys RightStick,
            Keys LeftThumbstickUp,
            Keys LeftThumbstickDown,
            Keys LeftThumbstickLeft,
            Keys LeftThumbstickRight,
            Keys RightThumbstickUp,
            Keys RightThumbstickDown,
            Keys RightThumbstickLeft,
            Keys RightThumbstickRight,
            Keys DPadUp,
            Keys DPadDown,
            Keys DPadLeft,
            Keys DPadRight)
        {
            this.A = A;
            this.B = B;
            this.X = X;
            this.Y = Y;
            this.Start = Start;
            this.Back = Back;
            this.LeftShoulder = LeftShoulder;
            this.RightShoulder = RightShoulder;
            this.LeftTrigger = LeftTrigger;
            this.RightTrigger = RightTrigger;
            this.LeftStick = LeftStick;
            this.RightStick = RightStick;
            this.LeftThumbstickDown = LeftThumbstickDown;
            this.LeftThumbstickUp = LeftThumbstickUp;
            this.LeftThumbstickLeft = LeftThumbstickLeft;
            this.LeftThumbstickRight = LeftThumbstickRight;
            this.RightThumbstickDown = RightThumbstickDown;
            this.RightThumbstickUp = RightThumbstickUp;
            this.RightThumbstickLeft = RightThumbstickLeft;
            this.RightThumbstickRight = RightThumbstickRight;
            this.DPadDown = DPadDown;
            this.DPadUp = DPadUp;
            this.DPadLeft = DPadLeft;
            this.DPadRight = DPadRight;
        }
    }
}
