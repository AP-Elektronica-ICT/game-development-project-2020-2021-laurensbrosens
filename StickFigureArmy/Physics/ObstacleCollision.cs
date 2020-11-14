using Microsoft.Xna.Framework;
using StickFigureArmy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using StickFigureArmy.Interfaces;
using System.Diagnostics;

namespace StickFigureArmy.Physics
{
    public class ObstacleCollision : ICollisionFix
    {
        public Vector2 CollisionFix(ICollision objectA, ICollision objectB, MovementCommand physics, ITransform transform)
        {
            //Save old collisionRectangle
            objectA.CollisionRectangleOld = objectA.CollisionRectangle;
            //Update collisionRectangle en positie
            objectA.UpdateRectangle();




            int heroCenterX = objectA.CollisionRectangleOld.Center.X;
            int heroCenterY = objectA.CollisionRectangleOld.Center.Y;
            int obstacleLeft = objectB.CollisionRectangle.Left;
            int obstacleRight = objectB.CollisionRectangle.Right;
            int obstacleBottom = objectB.CollisionRectangle.Bottom;
            int obstacleTop = objectB.CollisionRectangle.Top;
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
                    return new Vector2(obstacleLeft - objectA.CollisionRectangle.Right-1, 0); //Naar links

                }
                else
                {
                    physics.VelocityX = 0;
                    return new Vector2(obstacleRight - objectA.CollisionRectangle.Left+1, 0); //Naar rechts
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





            /*
            //Save old collisionRectangle
            rectangle.CollisionRectangleOld = rectangle.CollisionRectangle;
            //Update collisionRectangle en positie
            transform.Position += physicsDisplacment;
            rectangle.UpdateRectangle();

            //Collisions
            Vector2 collisionDisplacment = new Vector2(0, 0);
            foreach (var collisionObject in collisionObjects)
            {
                collisionDisplacment += collisionObject.CollisionAlgo.CollisionHandler(rectangle, collisionObject);
            }
            rectangle.UpdateRectangle();

            bool head = false;
            bool left = false;
            bool right = false;
            bool bottom = false;
            foreach (var collisionObject in collisionObjects)
            {
                if (CollisionCheck.CheckPointCollision(rectangle.CollisionLeft, collisionObject))
                {
                    left = true;
                }
                if (CollisionCheck.CheckPointCollision(rectangle.CollisionRight, collisionObject))
                {
                    right = true;
                }
                if (CollisionCheck.CheckPointCollision(rectangle.CollisionBottom, collisionObject)) //Naar boven
                {
                    VelocityY = 0;
                    bottom = true;
                }
                if (CollisionCheck.CheckPointCollision(rectangle.CollisionTop, collisionObject))
                {
                    VelocityY = 0;
                    head = true;
                }
            }
            state.CollisionLeft = left;
            state.CollisionRight = right;
            state.Grounded = bottom;
            if (bottom)
            {
                Gravity = 0;
            }
            else
            {
                Gravity = 9.8f;
            }
            state.BumpHead = head;

            if (collisionDisplacment.X != 0)
            {
                VelocityX = 0;
            }

            //Compenseer afwijking door collisions
            transform.Position += collisionDisplacment; //ObstacleCollision.AntiShivering(collisionDisplacment);

            */

















        }

        /*
         static public Vector2 AntiShivering(Vector2 displacment) //Tegen trillingen, duwt het object in de hitbox waarmee hij collision had
        {
            Vector2 betterDisplacment = displacment;
            if (displacment.X < 0)
                betterDisplacment += new Vector2(1f, 0);

            if (displacment.X > 0)
                betterDisplacment += new Vector2(-1f, 0);

            if (displacment.Y < 0)
                betterDisplacment += new Vector2(0, 1f);

            return betterDisplacment;
        }*/
    }
}
