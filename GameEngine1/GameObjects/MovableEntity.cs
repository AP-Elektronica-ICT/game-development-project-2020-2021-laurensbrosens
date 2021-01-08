using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.GameObjects
{
    public class MovableEntity : Entity, IPhysics, IAnimated
    {
        public IPhysicsHandler _PhysicsHandler { get; set; }
        public IAnimationHandler _AnimationHandler { get; set; }
        public override void Update(GameTime gameTime)
        {
            _PhysicsHandler.Move(gameTime, this, null);
            _collision.HanldeCollisions(null, this);
            _AnimationHandler.Update(gameTime, _PhysicsHandler, _collision, this);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _AnimationHandler.Draw(spriteBatch, this);
        }
    }
}
