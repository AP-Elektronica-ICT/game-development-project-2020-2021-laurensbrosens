using GameEngine1.GameLogic;
using GameEngine1.Interfaces;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.GameObjects
{
    public class Bullet : MovableEntity
    {
        public Level currentLevel;
        private Cooldown cooldown;
        public Bullet()
        {
            cooldown = new Cooldown();
            currentLevel = (Level)Game1.currentLevel;
        }
        public override void Update(GameTime gameTime)
        {
            _PhysicsHandler.Move(gameTime, this, null);
            _collision.HanldeCollisions(null, this);
            if (cooldown.CooldownTimer(gameTime,2)) //Verwijder bullet na 2 seconden
            {
                Alive = false;
            }
        }
    }
}
