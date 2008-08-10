using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input.GameControllers
{
    class NullGameController : IVirtualGameController
    {
        public NullGameController()
        { }

        #region IVirtualGameController Members
        public KeyboardAssignment KeyboardAssignment
        {
            get { return new KeyboardAssignment(); }
            set { ; }
        }

        public bool A
        {
            get { return false; }
        }

        public bool B
        {
            get { return false; }
        }

        public bool X
        {
            get { return false; }
        }

        public bool Y
        {
            get { return false; }
        }

        public bool Start
        {
            get { return false; }
        }

        public bool Back
        {
            get { return false; }
        }

        public bool LeftStick
        {
            get { return false; }
        }

        public bool RightStick
        {
            get { return false; }
        }

        public bool RightShoulder
        {
            get { return false; }
        }

        public bool LeftShoulder
        {
            get { return false; }
        }

        public float LeftStickX
        {
            get { return 0.0f; }
        }

        public float LeftStickY
        {
            get { return 0.0f; }
        }

        public float RightStickX
        {
            get { return 0.0f; }
        }

        public float RightStickY
        {
            get { return 0.0f; }
        }

        public float LeftTrigger
        {
            get { return 0.0f; }
        }

        public float RightTrigger
        {
            get { return 0.0f; }
        }

        public bool DPadUp
        {
            get { return false; }
        }

        public bool DPadDown
        {
            get { return false; }
        }

        public bool DPadLeft
        {
            get { return false; }
        }

        public bool DPadRight
        {
            get { return false; }
        }

        public void UpdateKeyboardState(ref KeyboardState keyboardState)
        {
            ;
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
    }
}
