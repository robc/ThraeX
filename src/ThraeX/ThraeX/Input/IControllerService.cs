using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input
{
    public interface IControllerService
    {
        GameInputMapper GetGameInputMapperForPlayer(PlayerIndex player);
        GameInputMapper GetActiveGameInputMapper();
        bool WasGameStartInputActionTriggered();
    }
}
