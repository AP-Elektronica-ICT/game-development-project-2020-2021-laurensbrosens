using Microsoft.Xna.Framework;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Interfaces
{
    public interface ICollisionFix
    {
        public Vector2 CollisionFix(ICollision objectA, ICollision objectB, MovementCommand physics, ITransform transform, State state);
    }
}
