using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ThraeX.Input
{
    public class GameControllerUpdateComponent : GameComponent, IControllerService
    {
        private const int NO_ACTIVE_GAME_INPUT_MAPPER = -1;
        private const int MAX_NUMBER_OF_CONTROLLERS = ((int)PlayerIndex.Four) + 1;

        private Type controllerTypeClass;
        private GameInputMapper[] mappedControllers;
        private int activeGameInputMapperNumber = NO_ACTIVE_GAME_INPUT_MAPPER;

        public GameControllerUpdateComponent(Game game, Type controllerType) : base(game)
        {
            Debug.Assert(controllerType.BaseType.Equals(typeof(GameInputMapper)),
                "controllerType must be set to a baseclass of GameInputMapper");
            controllerTypeClass = controllerType;
        }

        /// <summary>
        /// Component initialisation code that instantiates our mapper controllers using the supplied
        /// GameInputMapper subclass.
        /// </summary>
        public override void Initialize()
        {
            mappedControllers = new GameInputMapper[MAX_NUMBER_OF_CONTROLLERS];
            for (int i = 0; i < (MAX_NUMBER_OF_CONTROLLERS); i++)
            {
                ConstructorInfo constructorForType = controllerTypeClass.GetConstructor(new Type[] { typeof(PlayerIndex) });
                mappedControllers[i] = (GameInputMapper)constructorForType.Invoke(new Object[] { (PlayerIndex)i });
            }

            base.Initialize();
        }

        /// <summary>
        /// Updates the current state of the keyboard and gamepad for each controller.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            for (int i = 0; i < MAX_NUMBER_OF_CONTROLLERS; i++)
            {
                GamePadState gamePadState = GamePad.GetState((PlayerIndex)i);
                mappedControllers[i].Update(gameTime, ref keyboardState, ref gamePadState);
            }

            base.Update(gameTime);
        }

        #region IControllerService Members
        public GameInputMapper GetGameInputMapperForPlayer(PlayerIndex player)
        {
            return mappedControllers[(int)player];
        }

        public GameInputMapper GetActiveGameInputMapper()
        {
            if (activeGameInputMapperNumber == NO_ACTIVE_GAME_INPUT_MAPPER) return null;
            return mappedControllers[activeGameInputMapperNumber];
        }

        public bool WasGameStartInputActionTriggered()
        {
            for (int i = 0; i < (MAX_NUMBER_OF_CONTROLLERS); i++)
            {
                if (mappedControllers[i].GameStart)
                {
                    activeGameInputMapperNumber = i;
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
