using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.Xna.Framework.Input;
using ThraeX.Input;
using ThraeX.Input.GameControllers;

namespace UnitTests.ThraeX.Input
{
    public class VirtualGameControllerFactoryTest
    {
        [Fact]
        public void ShouldReturnGamePadControllerWhenGetNewGameControllerInstanceIsCalledWithGamePadTypeOfGamePad()
        {
            VirtualGameControllerFactory virtualGameControllerFactory = new VirtualGameControllerFactory();
            Assert.IsType<GamePadGameController>(virtualGameControllerFactory.GetNewGameControllerInstance(GamePadType.GamePad));
        }

        [Fact]
        public void ShouldReturnArcadeStickControllerWhenGetNewGameControllerInstanceIsCalledWithGamePadTypeOfArcadeStick()
        {
            VirtualGameControllerFactory virtualGameControllerFactory = new VirtualGameControllerFactory();
            Assert.IsType<ArcadeStickGameController>(virtualGameControllerFactory.GetNewGameControllerInstance(GamePadType.ArcadeStick));
        }
    }
}
