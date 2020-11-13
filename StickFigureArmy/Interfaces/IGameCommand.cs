using Microsoft.Xna.Framework;
using StickFigureArmy.Physics;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Interfaces
{
    interface IGameCommand
    {
        void Execute(GameTime gameTime, State state, ITransform transform, IInput input, ICollisionRectangle rectangle);
    }
}
