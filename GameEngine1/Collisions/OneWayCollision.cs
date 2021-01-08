using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameEngine1.GameObjects;
using GameEngine1.Interfaces;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;

namespace GameEngine1.Collisions
{
    class OneWayCollision : ICollision
    {

        public Rectangle CollisionRectangle { get; set; }
        public Rectangle CollisionRectangleOld { get; set; }
        public int RectangleOffsetX { get; set; }
        public int RectangleOffsetY { get; set; }
        public int RectangleWidth { get; set; }
        public int RectangleHeight { get; set; }
        public Entity Parent { get; set; }
        public void HanldeCollisions(IPhysicsHandler physics, ITransform transform)
        {
            //Voor bewegende platformen, niet gebruikt
        }
        public void CollisionCheck(Rectangle rectangle, IPhysicsHandler physics)
        {
            if (CollisionRectangle.Intersects(new Rectangle(rectangle.X, rectangle.Bottom + 1, rectangle.Width, 0)) && physics.JumpingDown == false && rectangle.Bottom - 0.1f < CollisionRectangle.Top)
            {
                physics.OnGround = true;
            }
        }
        public Vector2 CollisionFix(IPhysicsHandler physics, ICollision objectA)
        {
            int heroCenterX = objectA.CollisionRectangleOld.Center.X;
            int obstacleLeft = CollisionRectangle.Left;
            int obstacleRight = CollisionRectangle.Right;
            int obstacleTop = CollisionRectangle.Top;
            if (heroCenterX > obstacleLeft && heroCenterX < obstacleRight && objectA.CollisionRectangleOld.Bottom - 1 < obstacleTop && physics.JumpingDown == false)
            {
                physics.VelocityY = 0;
                return new Vector2(0, obstacleTop - objectA.CollisionRectangle.Bottom); //Naar boven
            }
            return new Vector2(0, 0);
        }
        public void UpdateRectangle(Vector2 position)
        {
            CollisionRectangle = new Rectangle((int)Math.Round(position.X + RectangleOffsetX), (int)Math.Round(position.Y + RectangleOffsetY), RectangleWidth, RectangleHeight);
        }
    }
}
