﻿using System;
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
        public void ShouldReturnGamePadControllerWithKeyboardAssignmentAssignedWhenGetNewGameControllerInstanceIsCalledAndKeyboardAssignmentIsPassedIn()
        {
            KeyboardAssignment keyboardAssignment = new KeyboardAssignment();
            VirtualGameControllerFactory virtualGameControllerFactory = new VirtualGameControllerFactory();

            IVirtualGameController instantiatedGameController = virtualGameControllerFactory.GetNewGameControllerInstance(GamePadType.GamePad, keyboardAssignment);
            Assert.IsType<GamePadGameController>(instantiatedGameController);
            Assert.Equal<KeyboardAssignment>(keyboardAssignment, instantiatedGameController.KeyboardAssignment);
        }

        [Fact]
        public void ShouldReturnGamePadControllerWhenGetNewGameControllerInstanceIsCalled()
        {
            VirtualGameControllerFactory virtualGameControllerFactory = new VirtualGameControllerFactory();
            Assert.IsType<GamePadGameController>(virtualGameControllerFactory.GetNewGameControllerInstance(GamePadType.GamePad));
        }

        [Fact]
        public void ShouldReturnArcadeStickControllerWithKeyboardAssignmentAssignedWhenGetNewGameControllerInstanceIsCalledForArcadeStickAndKeyboardAssignmentIsPassedIn()
        {
            KeyboardAssignment keyboardAssignment = new KeyboardAssignment();
            VirtualGameControllerFactory virtualGameControllerFactory = new VirtualGameControllerFactory();

            IVirtualGameController instantiatedGameController = virtualGameControllerFactory.GetNewGameControllerInstance(GamePadType.ArcadeStick, keyboardAssignment);
            Assert.IsType<ArcadeStickGameController>(instantiatedGameController);
            Assert.Equal<KeyboardAssignment>(keyboardAssignment, instantiatedGameController.KeyboardAssignment);
        }

        [Fact]
        public void ShouldReturnArcadeStickControllerWithoutKeyboardAssignmentWhenGetNewGameControllerInstanceIsCalledForArcadeStick()
        {
            VirtualGameControllerFactory virtualGameControllerFactory = new VirtualGameControllerFactory();
            Assert.IsType<ArcadeStickGameController>(virtualGameControllerFactory.GetNewGameControllerInstance(GamePadType.ArcadeStick));
        }
    }
}
