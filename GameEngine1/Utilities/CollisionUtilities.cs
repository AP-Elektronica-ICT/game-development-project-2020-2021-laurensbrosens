using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Utilities
{
    static class CollisionUtilities
    {
        static public bool CheckRectangleCollision(Rectangle objectA, Rectangle objectB)
        {
            if (objectA.Intersects(objectB))
            {
                return true;
            }
            return false;
        }
        static public bool CheckPointCollision(Point objectA, Rectangle objectB)
        {
            if (objectB.Contains(objectA))
            {
                return true;
            }
            return false;
        }
    }
}
