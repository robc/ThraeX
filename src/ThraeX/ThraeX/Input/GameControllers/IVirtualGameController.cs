using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input.GameControllers
{
    // TODO: Review the naming of these properties - look at what XNA has defined, and see if I can synch up the names
    // (which in fact might be better for consistency)
    public interface IVirtualGameController
    {
        bool AButton { get; }
        bool BButton { get; }
        bool XButton { get; }
        bool YButton { get; }
        bool StartButton { get; }
        bool BackButton { get; }
        bool LStickClick { get; }
        bool RStickClick { get; }
        bool RBumper { get; }
        bool LBumper { get; }

        float LStickX { get; }
        float LStickY { get; }
        float RStickX { get; }
        float RStickY { get; }

        float LTrigger { get; }
        float RTrigger { get; }

        bool DPadUp { get; }
        bool DPadDown { get; }
        bool DPadLeft { get; }
        bool DPadRight { get; }

        KeyboardAssignment KeyboardAssignment { get; set; }

        void UpdateKeyboardState(KeyboardState keyboardState);
        void UpdateGamePadState(GamePadState gamePadState);
        #if !XBOX
        void UpdateMouseState(MouseState mouseState);
        #endif
    }
}
