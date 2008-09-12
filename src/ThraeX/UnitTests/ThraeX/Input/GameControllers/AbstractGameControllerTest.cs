using Xunit;
using System;
using System.Collections.Generic;
using ThraeX.Input.GameControllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace UnitTests.ThraeX.Input.GameControllers
{
    public class AbstractGameControllerTest
    {
        private static readonly Object[] KEYS_TO_TEST = { Keys.A };

        // Currently we fail because we aren't cleanly invoking the protected method
        // What's the best way to invoke a protected method in this case?
        [Fact]
        public void IsKeyDownShouldBeFalseIfKeyIsNotDown()
        {
            KeyboardState keyboardState = new KeyboardState();
            AbstractGameController gameController = new AbstractGameController();
            gameController.UpdateKeyboardState(ref keyboardState);

            Type abstractGameControllerType = gameController.GetType();
            Assert.False((bool)(abstractGameControllerType.GetMethod("IsKeyDown", System.Reflection.BindingFlags.NonPublic).Invoke(gameController, KEYS_TO_TEST)));
        }
    }
}
