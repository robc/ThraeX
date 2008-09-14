using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ThraeX.Input;

namespace ThraeX.Input.GameControllers
{
    public class AbstractGameController
    {
        protected GamePadState previousGamePadState;
        protected GamePadState currentGamePadState;
        protected KeyboardState currentKeyboardState;
        protected KeyboardState previousKeyboardState;
        protected KeyboardAssignment keyboardAssignment;

        public KeyboardAssignment KeyboardAssignment
        {
            get { return this.keyboardAssignment; }
            set { this.keyboardAssignment = value; }
        }

        #region Keyboard & Gamepad Utility Methods
        protected bool IsKeyDown(Keys key)
        {
            bool state = false;
            if (key != Keys.None)
                state = currentKeyboardState.IsKeyDown(key);
            return state;
        }

        protected bool IsKeyHeldDown(Keys key)
        {
            bool state = false;
            if (key != Keys.None)
                state = currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyDown(key);
            return state;
        }

        protected bool IsKeyReleased(Keys key)
        {
            bool state = false;
            if (key != Keys.None)
                state = currentKeyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key);
            return state;
        }

        protected bool IsButtonDown(Buttons button, Keys key)
        {
            bool state = currentGamePadState.IsButtonDown(button);
            if (key != Keys.None) state |= IsKeyDown(key);
            return state;
        }

        protected bool IsButtonHeldDown(Buttons button, Keys key)
        {
            bool state = (currentGamePadState.IsButtonDown(button) && previousGamePadState.IsButtonDown(button));
            if (key != Keys.None) state |= IsKeyHeldDown(key);
            return state;
        }

        protected bool IsButtonReleased(Buttons button, Keys key)
        {
            bool state = (currentGamePadState.IsButtonUp(button) && previousGamePadState.IsButtonDown(button));
            if (key != Keys.None) state |= IsKeyReleased(key);
            return state;
        }

        protected float GetTriggerAmount(float triggerAxis, Keys triggerKey)
        {
            float result = 0f;

            if (triggerKey != Keys.None && currentKeyboardState.IsKeyDown(triggerKey))
                result = 1f;

            if (triggerAxis != 0)
                result = triggerAxis;

            return result;
        }

        protected float GetThumbstickAxisAmount(float gamePadAxisAmount, Keys negativeAxisKey, Keys positiveAxisKey)
        {
            float result = GetThumbstickAxisAmountForKeys(negativeAxisKey, positiveAxisKey);
            if (gamePadAxisAmount != 0)
                result = gamePadAxisAmount;
            return result;
        }

        protected float GetThumbstickAxisAmountForKeys(Keys negativeAxisKey, Keys positiveAxisKey)
        {
            float result = 0f;
            if (currentKeyboardState.IsKeyDown(negativeAxisKey))
                result = -1f;
            else if (currentKeyboardState.IsKeyDown(positiveAxisKey))
                result = 1f;
            return result;
        }
        #endregion

        #region Updating Input States
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
    }
}
