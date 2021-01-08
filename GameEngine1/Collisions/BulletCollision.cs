using System;
using System.Collections.Generic;
using System.Text;
using GameEngine1.GameObjects;
using GameEngine1.Interfaces;
using GameEngine1.Physics;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;

namespace GameEngine1.Collisions
{
    public class BulletCollision : HeroCollision
    {
        public BulletCollision(Vector2 position, List<ICollision> obstacles) : base(position, obstacles) { }
        public override void HanldeCollisions(IPhysicsHandler physics, ITransform transform)
        {
            UpdateRectangle(transform.Position);
            foreach (var collidableObject in collidableObstacles)
            {
                if (CollisionUtilities.CheckRectangleCollision(CollisionRectangle, collidableObject.CollisionRectangle)) //Check of er een collision is
                {
                    if (collidableObject.Parent is Human)
                    {
                        ((Human)collidableObject.Parent).Health -= ((Bullet)Parent).Damage; //Als het mens is verminder HP met 1
                    }
                    Parent.Alive = false; //Bullet destroys itself when hit
                }
            }
            CollisionRectangleOld = CollisionRectangle;
        }
        public override void CollisionCheck(Rectangle rectangle, IPhysicsHandler physics)
        {
            //throw new NotImplementedException();
        }

        public override Vector2 CollisionFix(IPhysicsHandler physics, ICollision objectA)
        {
            return ((BulletPhysicsHandler)physics).Direction * 0.2f; //Duw object weg waartegen gebotst wordt
        }
    }
}
