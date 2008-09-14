using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input.GameControllers
{
    public interface IVirtualGameController
    {
        #region Face Buttons
        bool A { get; }
        bool B { get; }
        bool X { get; }
        bool Y { get; }
        bool Start { get; }
        bool Back { get; }
        #endregion

        #region Thumb Sticks
        float LeftStickX { get; }
        float LeftStickY { get; }
        bool LeftThumbstickUp { get; }
        bool LeftThumbstickDown { get; }
        bool LeftThumbstickLeft { get; }
        bool LeftThumbstickRight { get; }
        bool LeftStick { get; }

        float RightStickX { get; }
        float RightStickY { get; }
        bool RightThumbstickUp { get; }
        bool RightThumbstickDown { get; }
        bool RightThumbstickLeft { get; }
        bool RightThumbstickRight { get; }
        bool RightStick { get; }
        #endregion

        #region Triggers & Shoulder Buttons
        float LeftTrigger { get; }
        float RightTrigger { get; }
        bool RightShoulder { get; }
        bool LeftShoulder { get; }
        #endregion

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
