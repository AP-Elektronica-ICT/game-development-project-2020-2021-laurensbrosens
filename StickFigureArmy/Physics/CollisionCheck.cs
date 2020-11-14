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
        static public bool CheckRectangleCollision(ICollision objectA, ICollision objectB)
        {
            if (objectA.CollisionRectangle.Intersects(objectB.CollisionRectangle))
            {
                return true;
            }
            return false;
        }
        static public bool CheckPointCollision(Point point, ICollision rectangle)
        {
            if (rectangle.CollisionRectangle.Contains(point))
            {
                return true;
            }
            return false;
        }
    }
}
