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

        // TODO: This constructor could be deprecated - our initialisation code
        // simply uses the property to set it, instead of the constructor
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

        public bool A
        {
            get { return ButtonPressed(Buttons.A); }
        }

        public bool B
        {
            get { return ButtonPressed(Buttons.B); }
        }

        public bool X
        {
            get { return ButtonPressed(Buttons.X); }
        }

        public bool Y
        {
            get { return ButtonPressed(Buttons.Y); }
        }

        public bool Start
        {
            get { return ButtonPressed(Buttons.Start); }
        }

        public bool Back
        {
            get { return ButtonPressed(Buttons.Back); }
        }

        public bool LeftStick
        {
            get { return ButtonPressed(Buttons.LeftStick); }
        }

        public bool RightStick
        {
            get { return ButtonPressed(Buttons.RightStick); }
        }

        public bool RightShoulder
        {
            get { return ButtonPressed(Buttons.RightShoulder); }
        }

        public bool LeftShoulder
        {
            get { return ButtonPressed(Buttons.LeftShoulder); }
        }

        public float LeftStickX
        {
            get { return currentGamePadState.ThumbSticks.Left.X; }
        }

        public float LeftStickY
        {
            get { return currentGamePadState.ThumbSticks.Left.Y; }
        }

        public float RightStickX
        {
            get { return currentGamePadState.ThumbSticks.Right.X; }
        }

        public float RightStickY
        {
            get { return currentGamePadState.ThumbSticks.Right.Y; }
        }

        public float LeftTrigger
        {
            get { return currentGamePadState.Triggers.Left; }
        }

        public float RightTrigger
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

        public void UpdateKeyboardState(ref KeyboardState keyboardState)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = keyboardState;
        }

        public void UpdateGamePadState(ref GamePadState gamePadState)
        {
            previousGamePadState = currentGamePadState;
            currentGamePadState = gamePadState;
        }

        #if !XBOX
        public void UpdateMouseState(ref MouseState mouseState)
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
