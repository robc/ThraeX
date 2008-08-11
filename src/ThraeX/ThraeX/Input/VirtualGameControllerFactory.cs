using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ThraeX.Input.GameControllers;

namespace ThraeX.Input
{
    public class VirtualGameControllerFactory : IVirtualGameControllerFactory
    {
        public VirtualGameControllerFactory()
        { }

        #region IVirtualControllerFactory Members
        /// <summary>
        /// Returns a new instance of IVirtualGameController for the specified gamePadType.
        /// 
        /// If client code calls this code for a GamePadType that is not supported, we return
        /// null, which will allow it to implement its own desired behaviours for these cases.
        /// 
        /// Note that this behaviour may not be desired in the long term, but that is something
        /// that can be reviewed when required.
        /// </summary>
        /// <param name="gamePadType">The GamePadType to create a specified instance for</param>
        /// <returns>An instance of IVirtualGameController for the desired type, or null for unsupported types</returns>
        public IVirtualGameController GetNewGameControllerInstance(GamePadType gamePadType, KeyboardAssignment keyboardAssignment)
        {
            IVirtualGameController gameController = GetNewGameControllerInstance(gamePadType);
            gameController.KeyboardAssignment = keyboardAssignment;

            return gameController;
        }

        public IVirtualGameController GetNewGameControllerInstance(GamePadType gamePadType)
        {
            return new GamePadGameController();
        }

        public IVirtualGameController GetNewKeyboardOnlyControllerInstance(KeyboardAssignment keyboardAssignment)
        {
            return new KeyboardOnlyVirtualGameController(keyboardAssignment);
        }
        #endregion
    }
}
