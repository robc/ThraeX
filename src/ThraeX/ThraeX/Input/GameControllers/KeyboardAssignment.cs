using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input.GameControllers
{
    // TODO: Default initialisation required - apparently we can't allow that
    // to be done by default...
    public struct KeyboardAssignment
    {
        public Keys? A;
        public Keys? B;
        public Keys? X;
        public Keys? Y;
        public Keys? LeftTrigger;
        public Keys? RightTrigger;
        public Keys? LeftShoulder;
        public Keys? RightShoulder;
        public Keys? LeftStick;
        public Keys? RightStick;
        public Keys? Start;
        public Keys? Back;
        public Keys? LeftThumbstickUp;
        public Keys? LeftThumbstickDown;
        public Keys? LeftThumbstickLeft;
        public Keys? LeftThumbstickRight;
        public Keys? RightThumbstickUp;
        public Keys? RightThumbstickDown;
        public Keys? RightThumbstickLeft;
        public Keys? RightThumbstickRight;
        public Keys? DPadUp;
        public Keys? DPadDown;
        public Keys? DPadLeft;
        public Keys? DPadRight;
    }
}
