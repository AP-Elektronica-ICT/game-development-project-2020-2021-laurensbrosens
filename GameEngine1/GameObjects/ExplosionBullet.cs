using GameEngine1.Collisions;
using GameEngine1.GameLogic;
using GameEngine1.Interfaces;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.GameObjects
{
    class ExplosionBullet : Bullet
    {
        public override void Update(GameTime gameTime)
        {
            _PhysicsHandler.Move(gameTime, this, null);
            _collision.HanldeCollisions(null, this);
            if (cooldown.CooldownTimer(gameTime, 3)) //Verwijder bullet na 2 seconden
            {
                ((ExplosionBulletCollision)_collision).Explode(((HeroCollision)_collision).collidableObstacles);
                Alive = false;
            }
        }

    }
}
