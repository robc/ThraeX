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

        public bool AButton
        {
            get { return false; }
        }

        public bool BButton
        {
            get { return false; }
        }

        public bool XButton
        {
            get { return false; }
        }

        public bool YButton
        {
            get { return false; }
        }

        public bool StartButton
        {
            get { return false; }
        }

        public bool BackButton
        {
            get { return false; }
        }

        public bool LStickClick
        {
            get { return false; }
        }

        public bool RStickClick
        {
            get { return false; }
        }

        public bool RBumper
        {
            get { return false; }
        }

        public bool LBumper
        {
            get { return false; }
        }

        public float LStickX
        {
            get { return 0.0f; }
        }

        public float LStickY
        {
            get { return 0.0f; }
        }

        public float RStickX
        {
            get { return 0.0f; }
        }

        public float RStickY
        {
            get { return 0.0f; }
        }

        public float LTrigger
        {
            get { return 0.0f; }
        }

        public float RTrigger
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
