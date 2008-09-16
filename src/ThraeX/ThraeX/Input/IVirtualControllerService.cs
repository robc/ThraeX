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

        bool WasButtonPressed(Buttons button);
        PlayerIndex? TriggeringPlayer { get; }

        void DetachController(PlayerIndex player);
        void AttachController(PlayerIndex player, GamePadType gamePadType);
        void AttachKeyboardOnlyController(PlayerIndex player);

        void SetKeyboardAssignment(PlayerIndex player, KeyboardAssignment keyboardAssignment);
    }
}
