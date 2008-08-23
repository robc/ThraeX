using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input.GameControllers
{
    /// <summary>
    /// An implementation of the IVirtualGameController which handles the Xbox
    /// 360 game pad.  This class also serves as the base of the 
    /// IVirtualGameController implementations, allowing us to create subclasses
    /// which don't need to implement each function of the interface.
    /// </summary>
    public class GamePadGameController : AbstractGameController, IVirtualGameController
    {
        public GamePadGameController() : base()
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

        public bool LeftStick
        {
            get { return IsButtonReleased(Buttons.LeftStick, keyboardAssignment.LeftStick); }
        }

        public bool RightStick
        {
            get { return IsButtonReleased(Buttons.RightStick, keyboardAssignment.RightStick); }
        }

        public bool RightShoulder
        {
            get { return IsButtonReleased(Buttons.RightShoulder, keyboardAssignment.RightShoulder); }
        }

        public bool LeftShoulder
        {
            get { return IsButtonReleased(Buttons.LeftShoulder, keyboardAssignment.LeftShoulder); }
        }

        public float LeftStickX
        {
            get { return GetThumbstickAxisAmount(currentGamePadState.ThumbSticks.Left.X, keyboardAssignment.LeftThumbstickLeft, keyboardAssignment.LeftThumbstickRight); }
        }

        public float LeftStickY
        {
            get { return GetThumbstickAxisAmount(currentGamePadState.ThumbSticks.Left.Y, keyboardAssignment.LeftThumbstickDown, keyboardAssignment.LeftThumbstickUp); }
        }
        
        public bool LeftThumbstickLeft
        {
            get { return IsButtonReleased(Buttons.LeftThumbstickLeft, keyboardAssignment.LeftThumbstickLeft); }
        }

        public bool LeftThumbstickRight
        {
            get { return IsButtonReleased(Buttons.LeftThumbstickRight, keyboardAssignment.LeftThumbstickRight); }
        }

        public bool LeftThumbstickUp
        {
            get { return IsButtonReleased(Buttons.LeftThumbstickUp, keyboardAssignment.LeftThumbstickUp); }
        }

        public bool LeftThumbstickDown
        {
            get { return IsButtonReleased(Buttons.LeftThumbstickDown, keyboardAssignment.LeftThumbstickDown); }
        }

        public float RightStickX
        {
            get { return GetThumbstickAxisAmount(currentGamePadState.ThumbSticks.Right.X, keyboardAssignment.RightThumbstickLeft, keyboardAssignment.RightThumbstickRight); }
        }

        public float RightStickY
        {
            get { return GetThumbstickAxisAmount(currentGamePadState.ThumbSticks.Right.Y, keyboardAssignment.RightThumbstickDown, keyboardAssignment.RightThumbstickUp); }
        }

        public bool RightThumbstickLeft
        {
            get { return IsButtonReleased(Buttons.RightThumbstickLeft, keyboardAssignment.RightThumbstickLeft); }
        }

        public bool RightThumbstickRight
        {
            get { return IsButtonReleased(Buttons.RightThumbstickRight, keyboardAssignment.RightThumbstickRight); }
        }

        public bool RightThumbstickUp
        {
            get { return IsButtonReleased(Buttons.RightThumbstickUp, keyboardAssignment.RightThumbstickUp); }
        }

        public bool RightThumbstickDown
        {
            get { return IsButtonReleased(Buttons.RightThumbstickDown, keyboardAssignment.RightThumbstickDown); }
        }

        public float LeftTrigger
        {
            get { return GetTriggerAmount(currentGamePadState.Triggers.Left, keyboardAssignment.LeftTrigger); }
        }

        public float RightTrigger
        {
            get { return GetTriggerAmount(currentGamePadState.Triggers.Right, keyboardAssignment.RightTrigger); }
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
