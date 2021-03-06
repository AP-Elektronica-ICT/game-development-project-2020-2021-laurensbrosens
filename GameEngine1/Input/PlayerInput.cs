﻿using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Input
{
    class PlayerInput : IInput
    {
        public IKeyboard keyboard;
        public PlayerInput(IKeyboard keyboardInput)
        {
            keyboard = keyboardInput;
        }
        public Vector2 Inputs(GameTime gameTime)
        {
            int directionX = 0;
            int directionY = 0;
            if (keyboard.keyboardState.IsKeyDown(Keys.A))
            {
                directionX--;
            }
            if (keyboard.keyboardState.IsKeyDown(Keys.D))
            {
                directionX++;
            }
            if (keyboard.keyboardState.IsKeyDown(Keys.Space))
            {
                directionY++;
            }
            if (keyboard.keyboardState.IsKeyDown(Keys.S))
            {
                directionY--;
            }
            if (keyboard.keyboardState.IsKeyDown(Keys.LeftShift)) //Sprint
            {
                directionX *= 4;
            }
            return new Vector2(directionX, directionY);
        }
    }
}
