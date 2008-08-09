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
    public class GamePadGameController : IVirtualGameController
    {
        protected GamePadState previousGamePadState;
        protected GamePadState currentGamePadState;
        protected KeyboardState currentKeyboardState;
        protected KeyboardState previousKeyboardState;
        protected KeyboardAssignment keyboardAssignment;

        public GamePadGameController(KeyboardAssignment keyboardAssignment)
        {
            this.keyboardAssignment = keyboardAssignment;
        }

        public GamePadGameController()
        { }

        #region IVirtualGameController Members
        public KeyboardAssignment KeyboardAssignment
        {
            get { return this.keyboardAssignment; }
            set { this.keyboardAssignment = value; }
        }

        public bool AButton
        {
            get { return ButtonPressed(Buttons.A); }
        }

        public bool BButton
        {
            get { return ButtonPressed(Buttons.B); }
        }

        public bool XButton
        {
            get { return ButtonPressed(Buttons.X); }
        }

        public bool YButton
        {
            get { return ButtonPressed(Buttons.Y); }
        }

        public bool StartButton
        {
            get { return ButtonPressed(Buttons.Start); }
        }

        public bool BackButton
        {
            get { return ButtonPressed(Buttons.Back); }
        }

        public bool LStickClick
        {
            get { return ButtonPressed(Buttons.LeftStick); }
        }

        public bool RStickClick
        {
            get { return ButtonPressed(Buttons.RightStick); }
        }

        public bool RBumper
        {
            get { return ButtonPressed(Buttons.RightShoulder); }
        }

        public bool LBumper
        {
            get { return ButtonPressed(Buttons.LeftShoulder); }
        }

        public float LStickX
        {
            get { return currentGamePadState.ThumbSticks.Left.X; }
        }

        public float LStickY
        {
            get { return currentGamePadState.ThumbSticks.Left.Y; }
        }

        public float RStickX
        {
            get { return currentGamePadState.ThumbSticks.Right.X; }
        }

        public float RStickY
        {
            get { return currentGamePadState.ThumbSticks.Right.Y; }
        }

        public float LTrigger
        {
            get { return currentGamePadState.Triggers.Left; }
        }

        public float RTrigger
        {
            get { return currentGamePadState.Triggers.Right; }
        }

        public bool DPadUp
        {
            get { return currentGamePadState.IsButtonDown(Buttons.DPadUp); }
        }

        public bool DPadDown
        {
            get { return currentGamePadState.IsButtonDown(Buttons.DPadDown); }
        }

        public bool DPadLeft
        {
            get { return currentGamePadState.IsButtonDown(Buttons.DPadLeft); }
        }

        public bool DPadRight
        {
            get { return currentGamePadState.IsButtonDown(Buttons.DPadRight); }
        }

        public void UpdateKeyboardState(KeyboardState keyboardState)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = keyboardState;
        }

        public void UpdateGamePadState(GamePadState gamePadState)
        {
            previousGamePadState = currentGamePadState;
            currentGamePadState = gamePadState;
        }

        #if !XBOX
        public void UpdateMouseState(MouseState mouseState)
        {
            ;
        }
        #endif
        #endregion

        /// Is it worth considering a composition model for the behaviour of the buttons, and D-Pad
        /// If this is done - we would certainly want separate behaviour for the UI screens in the
        /// application (to prevent the Rockblaster start-causes-the-UI-to-go-off-and-back-on issue).

        #region Utility Functions
        /// <summary>
        /// Tests for whether a button on the controller was pressed in a 'debounced' fashion,
        /// which only allows for a single button press in an action.
        /// </summary>
        /// <param name="button">The button on the controller to test</param>
        /// <returns>A bool indicating whether or not the button was pressed.</returns>
        protected bool ButtonPressed(Buttons button)
        {
            return currentGamePadState.IsButtonDown(button) && previousGamePadState.IsButtonUp(button);
        }
        #endregion
    }
}
