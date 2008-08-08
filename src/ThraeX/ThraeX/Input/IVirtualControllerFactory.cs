using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using ThraeX.Input.GameControllers;

namespace ThraeX.Input
{
    public interface IVirtualControllerFactory
    {
        IVirtualGameController GetNewGameControllerInstance(GamePadType gamePadType);
    }
}
