using Microsoft.Xna.Framework;
using StickFigureArmy.Utilities;
using StickFigureArmy.Physics;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Interfaces
{
    public interface ICollisionHandler
    {
        public void CollisionHandler(ICollision objectA, State state, MovementCommand physics, ITransform transform, List<ICollision> collidableObjects);
    }
}
