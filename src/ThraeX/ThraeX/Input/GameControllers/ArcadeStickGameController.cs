using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input.GameControllers
{
    /// <summary>
    /// An implementation of the IVirtualGameController which handles the Hori
    /// Arcade Stick.  This controller differs from the Xbox 360 Game Pad as
    /// follows:
    /// 
    /// 1. No Right Stick
    /// 2. Left Stick is Digital
    /// 3. DPad is either not present, or mapped to left stick (confirm)
    /// 4. Triggers are Digital
    /// 5. No Left or Right stick clicking (ie. Pressing the stick in)
    /// </summary>
    public class ArcadeStickGameController : GamePadGameController
    {
        public ArcadeStickGameController() : base()
        { }

        public float LTrigger
        {
            get { return (ButtonPressed(Buttons.LeftTrigger) ? 1.0f : 0.0f) ; }
        }

        public float RTrigger
        {
            get { return (ButtonPressed(Buttons.RightTrigger) ? 1.0f : 0.0f); }
        }

        public float RStickX
        {
            get { return 0.0f; }
        }

        public float RStickY
        {
            get { return 0.0f; }
        }

        public bool LStickClick
        {
            get { return false; }
        }

        public bool RStickClick
        {
            get { return false; }
        }

        // TODO: Confirm whether or not the DPad is present on the Arcade Stick
        // If so, fix up how these methods handle the controller, otherwise
        // we should be satisfactory.
        public bool DPadUp
        {
            get { return false; }
        }

        public bool DPadDown
        {
            get { return false; }
        }

        public bool DPadLeft
        {
            get { return false; }
        }

        public bool DPadRight
        {
            get { return false; }
        }
    }
}
