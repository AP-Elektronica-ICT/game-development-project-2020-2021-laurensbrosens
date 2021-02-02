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
    public class HeroCollision : ICollision
    {
        public Rectangle CollisionRectangle { get; set; }
        public Rectangle CollisionRectangleOld { get; set; }
        public int RectangleOffsetX { get; set; } = 4;
        public int RectangleOffsetY { get; set; }
        public int RectangleWidth { get; set; } = 8;
        public int RectangleHeight { get; set; } = 24;
        public List<ICollision> collidableObstacles;
        public Entity Parent { get; set; }
        public virtual void HanldeCollisions(IPhysicsHandler physics, ITransform transform)
        {
            UpdateRectangle(transform.Position);
            Vector2 collisionDisplacment = new Vector2(0, 0);
            foreach (var collidableObject in collidableObstacles)
            {
                if (CollisionUtilities.CheckRectangleCollision(CollisionRectangle, collidableObject.CollisionRectangle)) //Check of er een collision is
                {
                    collisionDisplacment = collidableObject.CollisionFix(physics, this); //Los collision op met collisionfix van object waartegen gebotst werd
                }
            }
            transform.Position += collisionDisplacment;
            UpdateRectangle(transform.Position);
            physics.CollisionLeft = false;
            physics.CollisionRight = false;
            physics.OnGround = false;
            physics.CollisionTop = false;
            foreach (var objectB in collidableObstacles) //Check of je ergens opstaat of niet
            {
                objectB.CollisionCheck(CollisionRectangle, physics);
            }
            UpdateRectangle(transform.Position); //Opnieuw update want nieuwe positie
            CollisionRectangleOld = CollisionRectangle;
        }
        protected void UpdateRectangle(Vector2 position)
        {
            CollisionRectangle = new Rectangle((int)Math.Round(position.X + RectangleOffsetX), (int)Math.Round(position.Y + RectangleOffsetY), RectangleWidth, RectangleHeight);
        }
        public HeroCollision(Vector2 position, List<ICollision> obstacles)
        {
            UpdateRectangle(position);
            collidableObstacles = obstacles;
        }/*
        private void UpdateCollisionPoints()
        {
            CollisionTop = new Point(CollisionRectangle.Center.X, CollisionRectangle.Top - 1);
            CollisionBottom = new Point(CollisionRectangle.Center.X, CollisionRectangle.Bottom + 1);
            CollisionLeft = new Point(CollisionRectangle.Left - 1, CollisionRectangle.Center.Y);
            CollisionRight = new Point(CollisionRectangle.Right + 1, CollisionRectangle.Center.Y);
        }*/

        public virtual Vector2 CollisionFix(IPhysicsHandler physics, ICollision objectA)
        {
            if (objectA is BulletCollision)
            {

            }
            return new Vector2(0,0);
        }

        public virtual void CollisionCheck(Rectangle rectangle, IPhysicsHandler physics)
        {
            //throw new NotImplementedException(); nog niet nodig
        }
    }
}
