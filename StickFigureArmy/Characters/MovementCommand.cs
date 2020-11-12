using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using StickFigureArmy.Characters;
using StickFigureArmy.Input;
using StickFigureArmy.View;
using System;
using System.Xml.Serialization;

namespace StickFigureArmy.Characters
{
    class MovementCommand
    {
        public Vector2 Inputs(IKeyboard keyboard)
        {
            int displacmentX = 0;
            int displacmentY = 0;
            if (keyboard.keyboardState.IsKeyDown(Keys.A))
            {
                displacmentX += -1;
            }
            if (keyboard.keyboardState.IsKeyDown(Keys.D))
            {
                displacmentX += 1;
            }
            if (keyboard.keyboardState.IsKeyDown(Keys.Space))
            {
                displacmentY += 1;
            }
            return new Vector2(displacmentX, displacmentY);
        }
    }
}
