
using Microsoft.Xna.Framework;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Interfaces
{
    public interface ICollisionCheck
    {
        public void CollisionCheck(ICollision objectA, ICollision objectB, State state);
    }
}
