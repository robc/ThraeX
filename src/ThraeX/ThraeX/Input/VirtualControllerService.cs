using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ThraeX.Input.GameControllers;

namespace ThraeX.Input
{
    public class VirtualControllerService : IVirtualControllerService
    {
        #region Constant Reference Variables
        private readonly IVirtualGameController NULL_CONTROLLER = new NullGameController();
        private static readonly GamePadType[] DEFAULT_GAMEPAD_TYPES = { GamePadType.GamePad };
        #endregion

        private IVirtualGameControllerFactory virtualControllerFactory;
        private bool useDPadAsLeftStick;

        private IVirtualGameController[] attachedControllers;
        private KeyboardAssignment[] keyboardAssignments;
        private GamePadType[] gamePadTypes;

        public VirtualControllerService(IVirtualGameControllerFactory virtualControllerFactory)
            : this(virtualControllerFactory, DEFAULT_GAMEPAD_TYPES)
        { }

        public VirtualControllerService(
            IVirtualGameControllerFactory virtualControllerFactory,
            GamePadType[] gamePadTypes)
        {
            this.gamePadTypes = gamePadTypes;
            this.virtualControllerFactory = virtualControllerFactory;
            useDPadAsLeftStick = false;
            InitialiseAttachedControllersArray();
        }

        private void InitialiseAttachedControllersArray()
        {
            attachedControllers = new IVirtualGameController[(int)PlayerIndex.Four];
            attachedControllers[(int)PlayerIndex.One] = NULL_CONTROLLER;
            attachedControllers[(int)PlayerIndex.Two] = NULL_CONTROLLER;
            attachedControllers[(int)PlayerIndex.Three] = NULL_CONTROLLER;
            attachedControllers[(int)PlayerIndex.Four] = NULL_CONTROLLER;

            keyboardAssignments = new KeyboardAssignment[(int)PlayerIndex.Four];
            keyboardAssignments[(int)PlayerIndex.One] = new KeyboardAssignment();
            keyboardAssignments[(int)PlayerIndex.Two] = new KeyboardAssignment();
            keyboardAssignments[(int)PlayerIndex.Three] = new KeyboardAssignment();
            keyboardAssignments[(int)PlayerIndex.Four] = new KeyboardAssignment();
        }

        #region IVirtualControllerService Members
        public bool IsControllerConnectedFor(PlayerIndex player)
        {
            return attachedControllers[(int)player] != NULL_CONTROLLER;
        }

        public bool IsAnyControllerConnected()
        {
            bool connected = false;

            connected |= IsControllerConnectedFor(PlayerIndex.One);
            connected |= IsControllerConnectedFor(PlayerIndex.Two);
            connected |= IsControllerConnectedFor(PlayerIndex.Three);
            connected |= IsControllerConnectedFor(PlayerIndex.Four);

            return connected;
        }

        public IVirtualGameController ControllerFor(PlayerIndex player)
        {
            return attachedControllers[(int)player];
        }

        public void UpdateKeyboardState(ref KeyboardState keyboardState)
        {
            for (int player = (int)PlayerIndex.One; player < (int)PlayerIndex.Four; player++)
            {
                attachedControllers[player].UpdateKeyboardState(ref keyboardState);
            }
        }

        public void UpdateGamePadState(ref GamePadState gamePadState, PlayerIndex player)
        {
            attachedControllers[(int)player].UpdateGamePadState(ref gamePadState);
        }

        #if !XBOX
        public void UpdateMouseState(ref MouseState mouseState)
        {
            ;
        }
        #endif

        public bool UseDpadAsLeftStick
        {
            get { return this.useDPadAsLeftStick; }
            set { this.useDPadAsLeftStick = value; }
        }

        public void DetachController(PlayerIndex player)
        {
            attachedControllers[(int)player] = NULL_CONTROLLER;
        }

        public void AttachController(PlayerIndex player, GamePadType gamePadType)
        {
            if (IsControllerTypeAllowed(gamePadType))
                attachedControllers[(int)player] = virtualControllerFactory.GetNewGameControllerInstance(gamePadType, keyboardAssignments[(int)player]);
        }

        public void AttachKeyboardOnlyController(PlayerIndex player)
        {
            attachedControllers[(int)player] = virtualControllerFactory.GetNewKeyboardOnlyControllerInstance(keyboardAssignments[(int)player]);
        }
        #endregion

        private bool IsControllerTypeAllowed(GamePadType gamePadType)
        {
            for (int padTypeNumber = 0; padTypeNumber < gamePadTypes.Length; padTypeNumber++)
            {
                if (gamePadTypes[padTypeNumber] == gamePadType)
                {
                    #if DEBUG
                    Console.WriteLine("Got a match on GamePadType {0} at index {1}", gamePadType, padTypeNumber);
                    #endif

                    return true;
                }
            }

            return false;
        }
    }
}
