using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input.GameControllers
{
    public struct KeyboardAssignment
    {
        #region Fields
        public Keys A = Keys.None;
        public Keys B = Keys.None;
        public Keys X = Keys.None;
        public Keys Y = Keys.None;
        public Keys LeftTrigger = Keys.None;
        public Keys RightTrigger = Keys.None;
        public Keys LeftShoulder = Keys.None;
        public Keys RightShoulder = Keys.None;
        public Keys LeftStick = Keys.None;
        public Keys RightStick = Keys.None;
        public Keys Start = Keys.None;
        public Keys Back = Keys.None;
        public Keys LeftThumbstickUp = Keys.None;
        public Keys LeftThumbstickDown = Keys.None;
        public Keys LeftThumbstickLeft = Keys.None;
        public Keys LeftThumbstickRight = Keys.None;
        public Keys RightThumbstickUp = Keys.None;
        public Keys RightThumbstickDown = Keys.None;
        public Keys RightThumbstickLeft = Keys.None;
        public Keys RightThumbstickRight = Keys.None;
        public Keys DPadUp = Keys.None;
        public Keys DPadDown = Keys.None;
        public Keys DPadLeft = Keys.None;
        public Keys DPadRight = Keys.None;
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
