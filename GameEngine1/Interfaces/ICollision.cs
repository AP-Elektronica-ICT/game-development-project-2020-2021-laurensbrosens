using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Interfaces
{
    public interface ICollision
    {
        public Rectangle CollisionRectangle { get; set; }
        public Rectangle CollisionRectangleOld { get; set; }
        public int RectangleOffsetX { get; set; }
        public int RectangleOffsetY { get; set; }
        public int RectangleWidth { get; set; }
        public int RectangleHeight { get; set; }
        public void HanldeCollisions(IPhysicsHandler physics, ITransform transform);
        public Vector2 CollisionFix(IPhysicsHandler physics, ICollision objectA);
        public void CollisionCheck(Rectangle rectangle, IPhysicsHandler physics);
    }
}
