using Microsoft.Xna.Framework;
using StickFigureArmy.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StickFigureArmy.Physics
{
    class CharacterCollision : ICollisionHandler //Moet refactored worden, doet momenteel collisions en states updaten
    {
        public void CollisionHandler(ICollision objectA, State state, MovementCommand physics, ITransform transform, List<ICollision> collidableObjects)
        {
            //Update collisionRectangle
            objectA.UpdateRectangle();

            Vector2 collisionDisplacment = new Vector2(0, 0);
            foreach (var collidableObject in collidableObjects)
            {
                if (CollisionCheck.CheckRectangleCollision(objectA, collidableObject)) //Check of er een collision is
                {
                    collisionDisplacment = collidableObject.CollisionFix.CollisionFix(objectA, collidableObject, physics, transform, state); //Los collision op met collisionfix van object waartegen gebotst werd
                }
            }
            //Compenseer afwijking door collisions
            transform.Position += collisionDisplacment;
            objectA.UpdateRectangle(); //Nog eens updaten want van positie veranderd
            objectA.UpdateCollisionPoints();
            //Update states

            //Reset states
            state.CollisionLeft = false;
            state.CollisionRight = false;
            state.Grounded = false;
            state.BumpHead = false;
            foreach (var objectB in collidableObjects) //Check of je ergens opstaat of niet
            {
                objectB.CollisionCheck.CollisionCheck(objectA, objectB, state);
            }

            /*
            if (state.Grounded) //Kan in de setter van state.grounded worden gezet
            {
                physics.Gravity = 0;
                state.Falling = false;
            }
            else
            {
                physics.Gravity = 9.8f;
                if (physics.VelocityY > 0)
                {
                    state.Falling = true;
                }
            }*/
            //Save old collisionRectangle
            objectA.CollisionRectangleOld = objectA.CollisionRectangle;
        }
        /*
        public Vector2 CollisionFix(ICollision objectA, ICollision objectB)
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
                    return new Vector2(obstacleLeft - objectA.CollisionRectangle.Right - 1, 0); //Naar links

                }
                else
                {
                    return new Vector2(obstacleRight - objectA.CollisionRectangle.Left + 1, 0); //Naar rechts
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
        }*/

    }
}
