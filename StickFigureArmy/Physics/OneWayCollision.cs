using Microsoft.Xna.Framework;
using StickFigureArmy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using StickFigureArmy.Interfaces;
using System.Diagnostics;

namespace StickFigureArmy.Physics
{
    class OneWayCollision : ICollisionFix, ICollisionCheck
    {

        public void CollisionCheck(ICollision objectA, ICollision objectB, State state)
        {
            //Het is enkel mogelijk om op een one way platform te staan als je niet naar beneden springt en de collisionpoint werkt en je niet in het platform bent
            if (objectB.CollisionRectangle.Contains(objectA.CollisionBottom) && state.JumpDown == false && objectA.CollisionRectangle.Center.Y < objectB.CollisionRectangle.Top)
            {
                state.Grounded = true;
            }
        }

        public Vector2 CollisionFix(ICollision objectA, ICollision objectB, MovementCommand physics, ITransform transform, State state)
        {
            int heroCenterX = objectA.CollisionRectangleOld.Center.X;
            int heroCenterY = objectA.CollisionRectangleOld.Center.Y;
            int obstacleLeft = objectB.CollisionRectangle.Left;
            int obstacleRight = objectB.CollisionRectangle.Right;
            int obstacleTop = objectB.CollisionRectangle.Top;
            if (heroCenterX > obstacleLeft && heroCenterX < obstacleRight && heroCenterY < obstacleTop && state.JumpDown == false)
            {
                physics.VelocityY = 0;
                return new Vector2(0, obstacleTop - objectA.CollisionRectangle.Bottom); //Naar boven
            }
            return new Vector2(0, 0);
        }

    }
}
