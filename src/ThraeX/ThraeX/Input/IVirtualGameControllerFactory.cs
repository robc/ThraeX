using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using ThraeX.Input.GameControllers;

namespace ThraeX.Input
{
    public interface IVirtualGameControllerFactory
    {
        IVirtualGameController GetNewGameControllerInstance(GamePadType gamePadType);
        IVirtualGameController GetNewGameControllerInstance(GamePadType gamePadType, KeyboardAssignment keyboardAssignment);
        IVirtualGameController GetNewKeyboardOnlyControllerInstance(KeyboardAssignment keyboardAssignment);
    }
}
