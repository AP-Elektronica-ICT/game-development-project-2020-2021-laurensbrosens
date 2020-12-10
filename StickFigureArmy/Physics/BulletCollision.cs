using Microsoft.Xna.Framework;
using StickFigureArmy.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StickFigureArmy.Physics
{
    class BulletCollision
    {
        public void CollisionHandler(ICollisionPoint objectA, BulletMovement physics, IDamageable bullet, List<ICollisionRectangle> collidableObjects)
        {
            //Update collisionRectangle
            objectA.UpdateCollisionPoint();

            //Vector2 collisionDisplacment = new Vector2(0, 0);
            foreach (var collidableObject in collidableObjects)
            {
                if (CollisionCheck.CheckPointCollision(objectA, collidableObject)) //Check of er een collision is
                {
                    bullet.Alive = false;
                }
            }
        }
    }
}
