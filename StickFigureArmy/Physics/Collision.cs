using Microsoft.Xna.Framework;
using StickFigureArmy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using StickFigureArmy.Interfaces;
using System.Diagnostics;

namespace StickFigureArmy.Physics
{
    static class Collision
    {
        static public Vector2 CollisionHandler(ICollisionRectangle objectA, ICollisionRectangle objectB)
        {
            if (Check(objectA, objectB))
            {
                return CollisionFix(objectA, objectB);
            }
            return new Vector2(0, 0);
        }
        static public bool Check(ICollisionRectangle objectA, ICollisionRectangle objectB)
        {
            if (objectA.CollisionRectangle.Intersects(objectB.CollisionRectangle))
            {
                return true;
            }
            return false;
        }
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
        }
        private static Vector2 CollisionFix(ICollisionRectangle objectA, ICollisionRectangle objectB)
        {
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
                    return new Vector2(0, obstacleTop - objectA.CollisionRectangle.Bottom); //Naar boven
                }
                else
                {
                    return new Vector2(0, obstacleBottom - objectA.CollisionRectangle.Top); //Naar beneden
                }
            }
            else if (obstacleTop < heroCenterY && heroCenterY < obstacleBottom) //ObjectA is links of rechts van ObjectB
            {
                if (heroCenterX < obstacleLeft)
                {
                    return new Vector2(obstacleLeft - objectA.CollisionRectangle.Right, 0); //Naar links

                }
                else
                {
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
                        return new Vector2(0, -top); //Naar boven
                    }
                    else
                    {
                        return new Vector2(0, -left); //Naar links
                    }
                }
                else
                {
                    int right = obstacleRight - objectA.CollisionRectangle.Left;
                    int top = objectA.CollisionRectangle.Bottom - obstacleTop;
                    if (right > top)
                    {
                        return new Vector2(0, -top); //Naar boven
                    }
                    else
                    {
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
                        return new Vector2(0, -bottom); //Naar beneden
                    }
                    else
                    {
                        return new Vector2(-left, 0); //Naar links
                    }

                }
                else
                {
                    int right = obstacleRight - objectA.CollisionRectangle.Left;
                    int bottom = obstacleBottom - objectA.CollisionRectangle.Top;
                    if (right > bottom)
                    {
                        return new Vector2(0, bottom); //Naar beneden
                    }
                    else
                    {
                        return new Vector2(right, 0); //Naar rechts
                    }
                }
            }
        }
    }
}
