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
    class ExplosionBulletCollision : HeroCollision
    {
        public ExplosionBulletCollision(Vector2 position, List<ICollision> obstacles) : base(position, obstacles) { }
        public override void HanldeCollisions(IPhysicsHandler physics, ITransform transform)
        {
            UpdateRectangle(transform.Position);
            foreach (var collidableObject in collidableObstacles)
            {
                if (CollisionUtilities.CheckRectangleCollision(CollisionRectangle, collidableObject.CollisionRectangle)) //Check of er een collision is
                {
                    Explode(collidableObstacles);
                }
            }
            CollisionRectangleOld = CollisionRectangle;
        }
        public void Explode(List<ICollision> collidableObstacles)
        {
            foreach (var collidableObject in collidableObstacles)
            {
                if (collidableObject.Parent == null) //Er kan geen damage worden gedaan als het geraakt object geen health heeft
                    break;
                float distance = Vector2.Distance(collidableObject.Parent.Position, Parent.Position);
                if (distance < 50)
                {
                    float damage = (float)((Bullet)Parent).Damage - 0.18f * distance;
                    if (collidableObject.Parent is Human)
                        ((Human)collidableObject.Parent).Health -= (int)Math.Round(damage); //Als het mens is verminder HP met 1
                    ((Human)collidableObject.Parent).Hit = true;
                }
            }
            Parent.Alive = false; //Bullet destroys itself when hit
            //Speel explosie animatie
            //Duw andere objecten weg
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
