using Microsoft.Xna.Framework;
using StickFigureArmy.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StickFigureArmy.Physics
{
    class CharacterCollision //Moet refactored worden, doet momenteel collisions en states updaten
    {
        public void CollisionHandler(ICollisionRectangle objectA, State state, MovementCommand physics, ITransform transform, List<ICollisionRectangle> collidableObjects)
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
            //Save old collisionRectangle
            objectA.CollisionRectangleOld = objectA.CollisionRectangle;
        }
    }
}
