using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using StickFigureArmy.Characters;
using StickFigureArmy.Input;
using StickFigureArmy.View;
using System;
using System.Xml.Serialization;
using StickFigureArmy.Interfaces;

namespace StickFigureArmy.Physics
{
    class PlayerInput : IInput
    {
        private IKeyboard keyboard;
        public PlayerInput(IKeyboard keyboardInput)
        {
            keyboard = keyboardInput;
        }
        public Vector2 Inputs()
        {
            int directionX = 0;
            int directionY = 0;
            if (keyboard.keyboardState.IsKeyDown(Keys.A))
            {
                directionX += -1;
            }
            if (keyboard.keyboardState.IsKeyDown(Keys.D))
            {
                directionX += 1;
            }
            if (keyboard.keyboardState.IsKeyDown(Keys.Space))
            {
                directionY += 1;
            }
            if (keyboard.keyboardState.IsKeyDown(Keys.S))
            {
                directionY -= 1;
            }
            if (keyboard.keyboardState.IsKeyDown(Keys.LeftShift))
            {
                directionX *= 10;
            }
            return new Vector2(directionX, directionY);
        }
    }
}
