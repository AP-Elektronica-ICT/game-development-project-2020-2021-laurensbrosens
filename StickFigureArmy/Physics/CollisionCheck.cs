using Microsoft.Xna.Framework;
using StickFigureArmy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using StickFigureArmy.Interfaces;
using System.Diagnostics;

namespace StickFigureArmy.Physics
{
    static class CollisionCheck
    {
        static public bool CheckRectangleCollision(ICollisionRectangle objectA, ICollisionRectangle objectB)
        {
            if (objectA.CollisionRectangle.Intersects(objectB.CollisionRectangle))
            {
                return true;
            }
            return false;
        }
        static public bool CheckPointCollision(ICollisionPoint objectA, ICollisionRectangle objectB)
        {
            if (objectB.CollisionRectangle.Contains(objectA.CollisionPoint))
            {
                return true;
            }
            return false;
        }
    }
}
