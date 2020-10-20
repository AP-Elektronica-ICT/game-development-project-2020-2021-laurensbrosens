using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Input
{
    class KeyboardInputAzerty : IInput
    {
        public Vector2 Inputs()
        {
            int displacmentX = 0;
            int displacmentY = 0;
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.Q))
            {
                displacmentX += -1;
            }
            if (stateKey.IsKeyDown(Keys.D))
            {
                displacmentX += 1;
            }
            if (stateKey.IsKeyDown(Keys.Space))
            {
                displacmentY += 1;
            }
            return new Vector2(displacmentX, displacmentY);
        }
    }
}
