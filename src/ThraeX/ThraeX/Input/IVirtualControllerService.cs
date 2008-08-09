using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ThraeX.Input.GameControllers;

namespace ThraeX.Input
{
    public interface IVirtualControllerService
    {
        bool IsControllerConnectedFor(PlayerIndex player);
        bool IsAnyControllerConnected();
        IVirtualGameController ControllerFor(PlayerIndex player);

        void UpdateKeyboardState(ref KeyboardState keyboardState);
        void UpdateGamePadState(ref GamePadState gamePadState, PlayerIndex player);

        #if !XBOX
        void UpdateMouseState(ref MouseState mouseState);
        #endif

        bool UseDpadAsLeftStick { get; set; }

        void DetachController(PlayerIndex player);
        void AttachController(PlayerIndex player, GamePadType gamePadType);
    }
}
