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

        public void Initialise()
        {
            A = Keys.None;
            B = Keys.None;
            X = Keys.None;
            Y = Keys.None;
            LeftTrigger = Keys.None;
            RightTrigger = Keys.None;
            LeftShoulder = Keys.None;
            RightShoulder = Keys.None;
            LeftStick = Keys.None;
            RightStick = Keys.None;
            Start = Keys.None;
            Back = Keys.None;
            LeftThumbstickUp = Keys.None;
            LeftThumbstickDown = Keys.None;
            LeftThumbstickLeft = Keys.None;
            LeftThumbstickRight = Keys.None;
            RightThumbstickUp = Keys.None;
            RightThumbstickDown = Keys.None;
            RightThumbstickLeft = Keys.None;
            RightThumbstickRight = Keys.None;
            DPadUp = Keys.None;
            DPadDown = Keys.None;
            DPadLeft = Keys.None;
            DPadRight = Keys.None;
        }
    }
}
