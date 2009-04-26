using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input
{
    public class GameInputMapper
    {
        public const String MENU_ITEM_ACCEPT_ACTION = "MenuAccept";
        public const String MENU_ITEM_CANCEL_ACTION = "MenuCancel";

        private Dictionary<String, Keys> keyboardActionAssignments;

        public GameInputMapper(PlayerIndex playerIndex)
        {
            PlayerIndex = playerIndex;
            
            keyboardActionAssignments = new Dictionary<String, Keys>();
            keyboardActionAssignments.Add(MENU_ITEM_ACCEPT_ACTION, Keys.None);
            keyboardActionAssignments.Add(MENU_ITEM_CANCEL_ACTION, Keys.None);
        }

        public void SetKeyForAction(String actionName, Keys keyboardKey)
        {
            if (keyboardActionAssignments.ContainsKey(actionName))
                keyboardActionAssignments[actionName] = keyboardKey;
            else
                keyboardActionAssignments.Add(actionName, keyboardKey);
        }

        public Keys GetKeyForAction(String actionName)
        {
            if (keyboardActionAssignments.ContainsKey(actionName))
                return keyboardActionAssignments[actionName];

            return Keys.None;
        }

        #region Menu UI Actions
        public bool GameStart
        {
            get
            {
                return IsButtonReleased(Buttons.Start)
                    || IsKeyReleased(Keys.Enter);
            }
        }
        
        public bool MenuUp
        {
            get
            {
                return IsButtonDown(Buttons.LeftThumbstickUp)
                    || IsButtonDown(Buttons.DPadUp)
                    || IsKeyDown(Keys.Up);
            }
        }

        public bool MenuDown
        {
            get
            {
                return IsButtonDown(Buttons.LeftThumbstickDown)
                    || IsButtonDown(Buttons.DPadDown)
                    || IsKeyDown(Keys.Down);
            }
        }

        public bool MenuLeft
        {
            get
            {
                return IsButtonDown(Buttons.LeftThumbstickLeft)
                    || IsButtonDown(Buttons.DPadLeft)
                    || IsKeyDown(Keys.Left);
            }
        }

        public bool MenuRight
        {
            get
            {
                return IsButtonDown(Buttons.LeftThumbstickRight)
                    || IsButtonDown(Buttons.DPadRight)
                    || IsKeyDown(Keys.Right);
            }
        }

        public bool MenuAccept
        {
            get
            {
                return IsButtonReleased(Buttons.A)
                    || IsKeyReleased(GetKeyForAction(MENU_ITEM_ACCEPT_ACTION))
                    || IsKeyReleased(Keys.Enter);
            }
        }

        public bool MenuCancel
        {
            get
            {
            	return IsButtonReleased(Buttons.B)
                    || IsButtonReleased(Buttons.Back)
                    || IsKeyReleased(GetKeyForAction(MENU_ITEM_CANCEL_ACTION))
                    || IsKeyReleased(Keys.Escape);
            }
        }

        public bool Pause
        {
            get
            {
                return IsButtonReleased(Buttons.Start)
                    || IsKeyReleased(Keys.Escape);
            }
        }
        #endregion

        #region Rumble Actions
        public void KillRumble()
        {
            SetRumble(0f, 0f);
        }

        protected void SetRumble(float leftMotor, float rightMotor)
        {
            GamePad.SetVibration(PlayerIndex, leftMotor, rightMotor);
        }
        #endregion

        #region Keyboard, Gamepad Properties
        protected KeyboardState CurrentKeyboardState
        {
            get; private set;
        }

        protected KeyboardState PreviousKeyboardState
        {
            get; private set;
        }

        protected GamePadState CurrentGamePadState
        {
            get; private set;
        }

        protected GamePadState PreviousGamePadState
        {
            get; private set;
        }

        public PlayerIndex PlayerIndex
        {
            get; private set;
        }

        public bool EnableTimedRumble
        {
            get; protected set;
        }

        protected TimeSpan RumbleTime
        {
            get; set;
        }

        protected float RumbleStrength
        {
            get; set;
        }
        #endregion

        #region Update Keyboard/GamePad status
        public void UpdateKeyboardState(ref KeyboardState keyboardState)
        {
            PreviousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = keyboardState;
        }

        public void UpdateGamePadState(ref GamePadState gamePadState)
        {
            PreviousGamePadState = CurrentGamePadState;
            CurrentGamePadState = gamePadState;
        }

        public void UpdateRumbleStatus(GameTime gameTime)
        {
            RumbleTime -= gameTime.ElapsedGameTime;
            if (RumbleTime <= TimeSpan.Zero)
            {
                EnableTimedRumble = false;
                KillRumble();
            }
            else
                SetRumble(RumbleStrength, RumbleStrength);
        }
        #endregion

        #region Tests for Keys
        protected bool IsKeyDown(Keys key)
        {
            return CurrentKeyboardState.IsKeyDown(key);
        }

        protected bool IsKeyHeldDown(Keys key)
        {
            return CurrentKeyboardState.IsKeyDown(key) && PreviousKeyboardState.IsKeyDown(key);
        }

        protected bool IsKeyReleased(Keys key)
        {
            return PreviousKeyboardState.IsKeyDown(key) && CurrentKeyboardState.IsKeyUp(key);
        }

        protected float IsKeyDownForTrigger(Keys key)
        {
            return (IsKeyDown(key) ? 1f : 0f);
        }

        protected float IsKeyDownForThumbstick(Keys negativeKey, Keys positiveKey)
        {
            if (IsKeyDown(negativeKey)) return -1f;
            else if (IsKeyDown(positiveKey)) return 1f;
            return 0f;
        }
        #endregion

        #region Tests for GamePad buttons
        protected bool IsButtonDown(Buttons button)
        {
            return CurrentGamePadState.IsButtonDown(button);
        }

        protected bool IsButtonHeldDown(Buttons button)
        {
            return CurrentGamePadState.IsButtonDown(button) && PreviousGamePadState.IsButtonDown(button);
        }

        protected bool IsButtonReleased(Buttons button)
        {
            return CurrentGamePadState.IsButtonUp(button) && PreviousGamePadState.IsButtonDown(button);
        }
        #endregion

        #region Status Tests
        public bool IsConnected
        {
            get
            {
        	    return CurrentGamePadState.IsConnected;
            }
        }
        #endregion
    }
}
