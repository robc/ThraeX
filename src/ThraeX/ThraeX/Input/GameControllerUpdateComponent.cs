using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ThraeX.Input.GameControllers;

namespace ThraeX.Input
{
    /// <summary>
    /// GameControllerUpdateComponent is a GameComponent designed to perform the task of updating
    /// the VirtualGameControllerService with the current Keyboard, Mouse and GamePad readings each frame.
    /// 
    /// This allows us to abstract out the updating stage, which is not easily unit tested from our component.
    /// </summary>
    public class GameControllerUpdateComponent : GameComponent
    {
        private IVirtualControllerService virtualControllerService;

        public GameControllerUpdateComponent(Game game) : base(game)
        { }

        /// <summary>
        /// Component initialisation code.  This configures the VirtualControllerService with the currently attached
        /// controllers.
        /// </summary>
        public override void Initialize()
        {
            virtualControllerService = (IVirtualControllerService)Game.Services.GetService(typeof(IVirtualControllerService));

            virtualControllerService.AttachController(PlayerIndex.One, GamePad.GetCapabilities(PlayerIndex.One).GamePadType);
            virtualControllerService.AttachController(PlayerIndex.Two, GamePad.GetCapabilities(PlayerIndex.Two).GamePadType);
            virtualControllerService.AttachController(PlayerIndex.Three, GamePad.GetCapabilities(PlayerIndex.Three).GamePadType);
            virtualControllerService.AttachController(PlayerIndex.Four, GamePad.GetCapabilities(PlayerIndex.Four).GamePadType);

            // Test to see if there's are no controllers attached, and if so, then we attach a keyboard VirtualGameController
            // onto the service.

            base.Initialize();
        }

        /// <summary>
        /// Updates the current state of the keyboard, mouse and gamepad for each controller.  This also
        /// handles registering/unregistering controllers as they are physically added/removed from the setup.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            virtualControllerService.UpdateKeyboardState(ref keyboardState);

            UpdateAttachedController(PlayerIndex.One);
            UpdateAttachedController(PlayerIndex.Two);
            UpdateAttachedController(PlayerIndex.Three);
            UpdateAttachedController(PlayerIndex.Four);

            GamePadState gamePadState;
            for (int playerIndex = 0; playerIndex < (int)PlayerIndex.Four; playerIndex++)
            {
                gamePadState = GamePad.GetState((PlayerIndex)playerIndex);
                virtualControllerService.UpdateGamePadState(ref gamePadState, (PlayerIndex)playerIndex);
            }

            #if !XBOX
            MouseState mouseState = Mouse.GetState();
            virtualControllerService.UpdateMouseState(ref mouseState);
            #endif

            base.Update(gameTime);
        }

        private void UpdateAttachedController(PlayerIndex playerIndex)
        {
            if (GamePad.GetCapabilities(playerIndex).IsConnected && !virtualControllerService.IsControllerConnectedFor(playerIndex))
                virtualControllerService.AttachController(playerIndex, GamePad.GetCapabilities(playerIndex).GamePadType);
            else if (!GamePad.GetCapabilities(playerIndex).IsConnected && virtualControllerService.IsControllerConnectedFor(playerIndex))
                virtualControllerService.DetachController(playerIndex);
        }
    }
}
