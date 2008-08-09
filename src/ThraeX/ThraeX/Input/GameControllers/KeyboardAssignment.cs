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

        /// <summary>
        /// TODO: See if there's a better way to simplify the setup - perhaps default them all
        /// to a "NoKey" type key, and have the user pass in a Hash containing all of the
        /// configured keys?  The sheer number of constructor parameters here feels like an
        /// incredible smell to me, even if this is a basic struct (so it's just to hold
        /// configuration data).
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Start"></param>
        /// <param name="Back"></param>
        /// <param name="LeftShoulder"></param>
        /// <param name="RightShoulder"></param>
        /// <param name="LeftTrigger"></param>
        /// <param name="RightTrigger"></param>
        /// <param name="LeftStick"></param>
        /// <param name="RightStick"></param>
        /// <param name="LeftThumbstickUp"></param>
        /// <param name="LeftThumbstickDown"></param>
        /// <param name="LeftThumbstickLeft"></param>
        /// <param name="LeftThumbstickRight"></param>
        /// <param name="RightThumbstickUp"></param>
        /// <param name="RightThumbstickDown"></param>
        /// <param name="RightThumbstickLeft"></param>
        /// <param name="RightThumbstickRight"></param>
        /// <param name="DPadUp"></param>
        /// <param name="DPadDown"></param>
        /// <param name="DPadLeft"></param>
        /// <param name="DPadRight"></param>
        public KeyboardAssignment(Keys A, Keys B, Keys X, Keys Y, Keys Start,
            Keys Back, Keys LeftShoulder, Keys RightShoulder, Keys LeftTrigger,
            Keys RightTrigger, Keys LeftStick, Keys RightStick, Keys LeftThumbstickUp,
            Keys LeftThumbstickDown, Keys LeftThumbstickLeft, Keys LeftThumbstickRight,
            Keys RightThumbstickUp, Keys RightThumbstickDown, Keys RightThumbstickLeft,
            Keys RightThumbstickRight, Keys DPadUp, Keys DPadDown, Keys DPadLeft,
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
