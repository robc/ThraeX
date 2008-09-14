using Xunit;
using ThraeX.Input.GameControllers;
using Microsoft.Xna.Framework.Input;

namespace UnitTests.ThraeX.Input.GameControllers
{
    public class AbstractGameControllerTest : AbstractGameController
    {
        readonly Keys[] currentKeysList = { Keys.A, Keys.C };
        readonly Keys[] previousKeysList = { Keys.A, Keys.B };

        public AbstractGameControllerTest()
        {
            currentKeyboardState = new KeyboardState(currentKeysList);
            previousKeyboardState = new KeyboardState(previousKeysList);
        }

        [Fact]
        public void IsKeyDownShouldBeFalseIfKeyIsNotDown()
        {
            Assert.False(IsKeyDown(Keys.B));
        }

        [Fact]
        public void IsKeyDownShouldBeTrueIfKeyIsDown()
        {
            Assert.True(IsKeyDown(Keys.A));
        }

        [Fact]
        public void IsKeyHeldDownShouldBeTrueIfKeyIsDownForBothTheCurrentAndPreviousStates()
        {
            Assert.True(IsKeyHeldDown(Keys.A));
        }

        [Fact]
        public void IsKeyHeldDownShouldBeFalseIfKeyIsNotDownForEitherState()
        {
            Assert.False(IsKeyHeldDown(Keys.B));
            Assert.False(IsKeyHeldDown(Keys.C));
        }

        [Fact]
        public void IsKeyReleasedShouldBeTrueIfKeyIsDownOnPreviousAndNotOnCurrent()
        {
            Assert.True(IsKeyReleased(Keys.B));
        }

        [Fact]
        public void IsKeyReleasedShouldBeFalseIfKeyIsNotDownOnPreviousAndNotOnCurrent()
        {
            Assert.False(IsKeyReleased(Keys.C));
            Assert.False(IsKeyReleased(Keys.A));
        }
    }
}
