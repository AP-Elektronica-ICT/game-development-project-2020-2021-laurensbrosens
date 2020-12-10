using Microsoft.Xna.Framework;
using StickFigureArmy.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StickFigureArmy.Physics
{
    public class BulletMovement : IGameCommand
    {
        public void Execute(GameTime gameTime, State state, ITransform transform, IInput input)
        {
            Vector2 direction = input.Inputs();
            //Calculate physics
            float deltaT = (float)gameTime.ElapsedGameTime.TotalSeconds;
            transform.Position += Vector2.Multiply(direction,deltaT);
        }
    }
}
