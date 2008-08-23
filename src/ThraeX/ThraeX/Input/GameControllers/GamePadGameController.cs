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
            get { return WasPadButtonPressed(Buttons.A) || WasKeyPressed(keyboardAssignment.A.Value); }
        }

        public bool B
        {
            get { return WasPadButtonPressed(Buttons.B) || WasKeyPressed(keyboardAssignment.B.Value); }
        }

        public bool X
        {
            get { return WasPadButtonPressed(Buttons.X) || WasKeyPressed(keyboardAssignment.X.Value); }
        }

        public bool Y
        {
            get { return WasPadButtonPressed(Buttons.Y) || WasKeyPressed(keyboardAssignment.Y.Value); }
        }

        public bool Start
        {
            get { return WasPadButtonPressed(Buttons.Start) || WasKeyPressed(keyboardAssignment.Start.Value); }
        }

        public bool Back
        {
            get { return WasPadButtonPressed(Buttons.Back) || WasKeyPressed(keyboardAssignment.Back.Value); }
        }

        public bool LeftStick
        {
            get { return WasPadButtonPressed(Buttons.LeftStick) || WasKeyPressed(keyboardAssignment.LeftStick.Value); }
        }

        public bool RightStick
        {
            get { return WasPadButtonPressed(Buttons.RightStick) || WasKeyPressed(keyboardAssignment.RightStick.Value); }
        }

        public bool RightShoulder
        {
            get { return WasPadButtonPressed(Buttons.RightShoulder) || WasKeyPressed(keyboardAssignment.RightShoulder.Value); }
        }

        public bool LeftShoulder
        {
            get { return WasPadButtonPressed(Buttons.LeftShoulder) || WasKeyPressed(keyboardAssignment.LeftShoulder.Value); }
        }

        public float LeftStickX
        {
            get { return ReadStickAxis(currentGamePadState.ThumbSticks.Left.X, keyboardAssignment.LeftThumbstickLeft.Value, keyboardAssignment.LeftThumbstickRight.Value); }
        }

        public float LeftStickY
        {
            get { return ReadStickAxis(currentGamePadState.ThumbSticks.Left.Y, keyboardAssignment.LeftThumbstickDown.Value, keyboardAssignment.LeftThumbstickUp.Value); }
        }

        public bool LeftThumbstickLeft
        {
            get { return WasPadButtonPressed(Buttons.LeftThumbstickLeft) || WasKeyPressed(keyboardAssignment.LeftThumbstickLeft.Value); }
        }

        public bool LeftThumbstickRight
        {
            get { return WasPadButtonPressed(Buttons.LeftThumbstickRight) || WasKeyPressed(keyboardAssignment.LeftThumbstickRight.Value); }
        }

        public bool LeftThumbstickUp
        {
            get { return WasPadButtonPressed(Buttons.LeftThumbstickUp) || WasKeyPressed(keyboardAssignment.LeftThumbstickUp.Value); }
        }

        public bool LeftThumbstickDown
        {
            get { return WasPadButtonPressed(Buttons.LeftThumbstickDown) || WasKeyPressed(keyboardAssignment.LeftThumbstickDown.Value); }
        }

        public float RightStickX
        {
            get { return ReadStickAxis(currentGamePadState.ThumbSticks.Right.X, keyboardAssignment.RightThumbstickLeft.Value, keyboardAssignment.RightThumbstickRight.Value); }
        }

        public float RightStickY
        {
            get { return ReadStickAxis(currentGamePadState.ThumbSticks.Right.Y, keyboardAssignment.RightThumbstickDown.Value, keyboardAssignment.RightThumbstickUp.Value); }
        }

        public bool RightThumbstickLeft
        {
            get { return WasPadButtonPressed(Buttons.RightThumbstickLeft) || WasKeyPressed(keyboardAssignment.RightThumbstickLeft.Value); }
        }

        public bool RightThumbstickRight
        {
            get { return WasPadButtonPressed(Buttons.RightThumbstickRight) || WasKeyPressed(keyboardAssignment.RightThumbstickRight.Value); }
        }

        public bool RightThumbstickUp
        {
            get { return WasPadButtonPressed(Buttons.RightThumbstickUp) || WasKeyPressed(keyboardAssignment.RightThumbstickUp.Value); }
        }

        public bool RightThumbstickDown
        {
            get { return WasPadButtonPressed(Buttons.RightThumbstickDown) || WasKeyPressed(keyboardAssignment.RightThumbstickDown.Value); }
        }

        public float LeftTrigger
        {
            get { return ReadTriggerAxis(currentGamePadState.Triggers.Left, keyboardAssignment.LeftTrigger.Value); }
        }

        public float RightTrigger
        {
            get { return ReadTriggerAxis(currentGamePadState.Triggers.Right, keyboardAssignment.RightTrigger.Value); }
        }

        public bool DPadUp
        {
            get { return WasPadButtonPressed(Buttons.DPadUp) || WasKeyPressed(keyboardAssignment.DPadUp.Value); }
        }

        public bool DPadDown
        {
            get { return WasPadButtonPressed(Buttons.DPadDown) || WasKeyPressed(keyboardAssignment.DPadDown.Value); }
        }

        public bool DPadLeft
        {
            get { return WasPadButtonPressed(Buttons.DPadLeft) || WasKeyPressed(keyboardAssignment.DPadLeft.Value); }
        }

        public bool DPadRight
        {
            get { return WasPadButtonPressed(Buttons.DPadRight) || WasKeyPressed(keyboardAssignment.DPadRight.Value); }
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

        #region Utility Functions
        /// <summary>
        /// Tests for whether a button on the controller was pressed in a 'debounced' fashion,
        /// which only allows for a single button press in an action.
        /// </summary>
        /// <param name="button">The button on the controller to test</param>
        /// <returns>A bool indicating whether or not the button was pressed.</returns>
        protected bool WasPadButtonPressed(Buttons button)
        {
            return currentGamePadState.IsButtonDown(button) && previousGamePadState.IsButtonUp(button);
        }

        protected bool IsPadButtonDown(Buttons button)
        {
            return currentGamePadState.IsButtonDown(button);
        }

        protected bool IsKeyDown(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key));
        }

        // TODO: Review & confirm to see if we actually care about this...
        protected bool IsHoldingKey(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyDown(key));
        }

        protected bool WasKeyPressed(Keys key)
        {
            return (currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key));
        }

        protected bool WasKeyReleased(Keys key)
        {
            return (currentKeyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key));
        }

        protected float ReadStickAxis(float gamePadAxis, Keys negativeKey, Keys positiveKey)
        {
            float result = 0f;

            if (currentKeyboardState.IsKeyDown(negativeKey))
                result = -1f;
            else if (currentKeyboardState.IsKeyDown(positiveKey))
                result = 1f;

            if (gamePadAxis != 0)
                result = gamePadAxis;

            return result;            
        }

        protected float ReadTriggerAxis(float triggerAxis, Keys triggerKey)
        {
            float result = 0f;

            if (currentKeyboardState.IsKeyDown(triggerKey))
                result = 1f;

            if (triggerAxis != 0)
                result = triggerAxis;

            return result;
        }
        #endregion
    }
}
