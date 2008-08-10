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
        bool A { get; }
        bool B { get; }
        bool X { get; }
        bool Y { get; }
        bool Start { get; }
        bool Back { get; }
        bool LeftStick { get; }
        bool RightStick { get; }
        bool RightShoulder { get; }
        bool LeftShoulder { get; }

        float LeftStickX { get; }
        float LeftStickY { get; }
        float RightStickX { get; }
        float RightStickY { get; }

        float LeftTrigger { get; }
        float RightTrigger { get; }

        bool DPadUp { get; }
        bool DPadDown { get; }
        bool DPadLeft { get; }
        bool DPadRight { get; }

        KeyboardAssignment KeyboardAssignment { get; set; }

        void UpdateKeyboardState(ref KeyboardState keyboardState);
        void UpdateGamePadState(ref GamePadState gamePadState);
        #if !XBOX
        void UpdateMouseState(ref MouseState mouseState);
        #endif
    }
}
