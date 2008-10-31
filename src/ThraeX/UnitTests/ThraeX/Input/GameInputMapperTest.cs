using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ThraeX.Input;
using Xunit;

namespace UnitTests.ThraeX.Input
{
    public class GameInputMapperTest : GameInputMapper
    {
        #region Keyboard Test Values
        readonly Keys[] currentKeysList = { Keys.A, Keys.C };
        readonly Keys[] previousKeysList = { Keys.A, Keys.B };
        private KeyboardState currentKeyboardState, previousKeyboardState;
        #endregion

        #region Current Gamepad Test Values
        private GamePadState currentGamePadState;
        readonly GamePadThumbSticks currentThumbsticks = new GamePadThumbSticks(new Vector2(0.3f, -0.9f), new Vector2(0.8f, -0.6f));
        readonly GamePadTriggers currentTriggers = new GamePadTriggers(0.4f, 0.8f);
        readonly GamePadButtons currentButtons = new GamePadButtons(Buttons.A | Buttons.X);
        readonly GamePadDPad currentDPad = new GamePadDPad(ButtonState.Pressed, ButtonState.Released, ButtonState.Released, ButtonState.Released);
        #endregion

        #region Previous Gamepad Test Values
        private GamePadState previousGamePadState;
        readonly GamePadThumbSticks previousThumbsticks = new GamePadThumbSticks(new Vector2(-0.75f, 0.1f), new Vector2(0.2f, -0.3f));
        readonly GamePadTriggers previousTriggers = new GamePadTriggers(0.95f, 0.3f);
        readonly GamePadButtons previousButtons = new GamePadButtons(Buttons.A | Buttons.B);
        readonly GamePadDPad previousDPad = new GamePadDPad(ButtonState.Pressed, ButtonState.Pressed, ButtonState.Released, ButtonState.Released);
        #endregion

        #region Constructor (sets up test data)
        public GameInputMapperTest() : base(PlayerIndex.One)
        {
            previousKeyboardState = new KeyboardState(previousKeysList);
            currentKeyboardState = new KeyboardState(currentKeysList);
            UpdateKeyboardState(ref previousKeyboardState);
            UpdateKeyboardState(ref currentKeyboardState);

            currentGamePadState = new GamePadState(currentThumbsticks, currentTriggers, currentButtons, currentDPad);
            previousGamePadState = new GamePadState(previousThumbsticks, previousTriggers, previousButtons, previousDPad);
            UpdateGamePadState(ref previousGamePadState);
            UpdateGamePadState(ref currentGamePadState);
        }
        #endregion

        #region Test updating the Keyboard State
        [Fact]
        public void UpdateKeyboardStateShouldStoreThePassedInKeyboardStateInCurrentKeyboardState()
        {
            Assert.Equal<KeyboardState>(currentKeyboardState, CurrentKeyboardState);
        }

        [Fact]
        public void UpdateKeyboardStateShouldStoreTheCurrentKeyboardStateInPreviousKeyboardState()
        {
            Assert.Equal<KeyboardState>(previousKeyboardState, PreviousKeyboardState);
        }
        #endregion

        #region Test updating the Gamepad State
        [Fact]
        public void TestUpdateGamepadStateSetsTheCurrentGamepadStateToThePassedInValue()
        {
            Assert.Equal<GamePadState>(currentGamePadState, CurrentGamePadState);
        }

        [Fact]
        public void TestUpdateGamePadStateSetsThePreviousGamePadStateToTheCurrentGamePadState()
        {
            Assert.Equal<GamePadState>(previousGamePadState, PreviousGamePadState);
        }
        #endregion

        #region Test Keyboard Helpers
        [Fact]
        public void IsKeyDownShouldReturnTrueWhenKeyIsDownInCurrentKeyboardState()
        {
            Assert.True(IsKeyDown(Keys.A));   
        }

        [Fact]
        public void IsKeyHeldDownShouldReturnTrueWhenKeyIsDownInBothCurrentAndPreviousKeyboardState()
        {
            Assert.True(IsKeyHeldDown(Keys.A));
        }

        [Fact]
        public void IsKeyReleasedShouldReturnTrueIfKeyIsDownForPreviousAndUpForCurrent()
        {
            Assert.True(IsKeyReleased(Keys.B));
        }

        [Fact]
        public void IsKeyDownForTriggerShouldReturnOneIfKeyIsDownForCurrent()
        {
            Assert.Equal<float>(1f, IsKeyDownForTrigger(Keys.A));
        }

        [Fact]
        public void IsKeyDownForThumbstickShouldReturnNegativeOneIfNegativeKeyIsDownForCurrent()
        {
            Assert.Equal<float>(-1f, IsKeyDownForThumbstick(Keys.A, Keys.B));
        }

        [Fact]
        public void IsKeyDownForThumbstickShouldReturnPositiveOneIfPositiveKeyIsDownForCurrent()
        {
            Assert.Equal<float>(1f, IsKeyDownForThumbstick(Keys.X, Keys.C));
        }
        #endregion

        #region Test GamePad Button Helpers
        [Fact]
        public void IsButtonDownShouldReturnTrueWhenButtonIsDownInCurrentGamePadState()
        {
            Assert.True(IsButtonDown(Buttons.X));
        }

        [Fact]
        public void IsButtonHeldDownShouldReturnTrueWhenButtonIsDownForBothCurrentAndPrevious()
        {
            Assert.True(IsButtonHeldDown(Buttons.A));
        }

        [Fact]
        public void IsButtonReleasedShouldReturnTrueWhenButtonIsDownForPreviousAndNotCurrent()
        {
            Assert.True(IsButtonReleased(Buttons.B));
        }
        #endregion
    }
}
