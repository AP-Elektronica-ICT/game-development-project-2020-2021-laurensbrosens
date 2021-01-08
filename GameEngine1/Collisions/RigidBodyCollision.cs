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
    class RigidBodyCollision : ICollision
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
            //
        }
        public void CollisionCheck(Rectangle rectangle, IPhysicsHandler physics)
        {
            //Point CollisionTop = new Point(rectangle.Center.X, rectangle.Top - 1);
            //Point CollisionBottom = new Point(rectangle.Center.X, rectangle.Bottom + 1);
            Point CollisionLeft = new Point(rectangle.Left - 1, rectangle.Center.Y);
            Point CollisionRight = new Point(rectangle.Right + 1, rectangle.Center.Y);

            if (CollisionRectangle.Contains(CollisionLeft))
            {
                physics.CollisionLeft = true;
            }
            if (CollisionRectangle.Contains(CollisionRight))
            {
                physics.CollisionRight = true;
            }
            if (CollisionRectangle.Intersects(new Rectangle(rectangle.X,rectangle.Bottom+1,rectangle.Width,0)))
            {
                physics.OnGround = true;
            }
            if (CollisionRectangle.Intersects(new Rectangle(rectangle.X, rectangle.Top - 1, rectangle.Width, 0)))
            {
                physics.CollisionTop = true;
            }
        }
        public Vector2 CollisionFix(IPhysicsHandler physics, ICollision objectA)
        {
            int heroCenterX = objectA.CollisionRectangleOld.Center.X;
            int heroCenterY = objectA.CollisionRectangleOld.Center.Y;
            int obstacleLeft = CollisionRectangle.Left;
            int obstacleRight = CollisionRectangle.Right;
            int obstacleBottom = CollisionRectangle.Bottom;
            int obstacleTop = CollisionRectangle.Top;
            if (obstacleLeft < heroCenterX && heroCenterX < obstacleRight) //ObjectA is boven of onder ObjectB
            {
                if (heroCenterY < obstacleBottom)
                {
                    physics.VelocityY = 0;
                    return new Vector2(0, obstacleTop - objectA.CollisionRectangle.Bottom); //Naar boven
                }
                else
                {
                    physics.VelocityY = 0;
                    return new Vector2(0, obstacleBottom - objectA.CollisionRectangle.Top); //Naar beneden
                }
            }
            else if (obstacleTop < heroCenterY && heroCenterY < obstacleBottom) //ObjectA is links of rechts van ObjectB
            {
                if (heroCenterX < obstacleLeft)
                {
                    physics.VelocityX = 0;
                    return new Vector2(obstacleLeft - objectA.CollisionRectangle.Right, 0); //Naar links

                }
                else
                {
                    physics.VelocityX = 0;
                    return new Vector2(obstacleRight - objectA.CollisionRectangle.Left, 0); //Naar rechts
                }
            }
            else if (obstacleTop > heroCenterY) //ObjectA is linksboven of rechtsboven ObjectB
            {
                if (heroCenterX < obstacleLeft)
                {
                    int left = objectA.CollisionRectangle.Right - obstacleLeft;
                    int top = objectA.CollisionRectangle.Bottom - obstacleTop;
                    if (left > top)
                    {
                        physics.VelocityY = 0;
                        return new Vector2(0, -top); //Naar boven
                    }
                    else
                    {
                        physics.VelocityX = 0;
                        return new Vector2(0, -left); //Naar links
                    }
                }
                else
                {
                    int right = obstacleRight - objectA.CollisionRectangle.Left;
                    int top = objectA.CollisionRectangle.Bottom - obstacleTop;
                    if (right > top)
                    {
                        physics.VelocityY = 0;
                        return new Vector2(0, -top); //Naar boven
                    }
                    else
                    {
                        physics.VelocityX = 0;
                        return new Vector2(right, 0); //Naar rechts
                    }
                }
            }
            else //ObjectA is linksonder of rechtsonder ObjectB
            {
                if (heroCenterX < obstacleLeft)
                {
                    int left = objectA.CollisionRectangle.Right - obstacleLeft;
                    int bottom = obstacleBottom - objectA.CollisionRectangle.Top;
                    if (left > bottom)
                    {
                        physics.VelocityY = 0;
                        return new Vector2(0, -bottom); //Naar beneden
                    }
                    else
                    {
                        physics.VelocityX = 0;
                        return new Vector2(-left, 0); //Naar links
                    }

                }
                else
                {
                    int right = obstacleRight - objectA.CollisionRectangle.Left;
                    int bottom = obstacleBottom - objectA.CollisionRectangle.Top;
                    if (right > bottom)
                    {
                        physics.VelocityY = 0;
                        return new Vector2(0, bottom); //Naar beneden
                    }
                    else
                    {
                        physics.VelocityX = 0;
                        return new Vector2(right, 0); //Naar rechts
                    }
                }
            }
        }
        public void UpdateRectangle(Vector2 position)
        {
            CollisionRectangle = new Rectangle((int)Math.Round(position.X + RectangleOffsetX), (int)Math.Round(position.Y + RectangleOffsetY), RectangleWidth, RectangleHeight);
        }
    }
}
