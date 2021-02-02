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
    public class Bullet : MovableEntity
    {
        public Level currentLevel;
        internal Cooldown cooldown;
        public int Damage { get; set; } = 1;
        public Bullet()
        {
            cooldown = new Cooldown();
            currentLevel = Game1.currentLevel;
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
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, new Rectangle(0,0,32,32), Color.White, Rotation, new Vector2(15, 15), Scale, SpriteEffects.None, 0);
        }
    }
}
