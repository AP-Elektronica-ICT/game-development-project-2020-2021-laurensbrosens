using GameEngine1.GameObjects;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Weapons
{
    public class Weapon : MovableEntity, IWeapon
    {
        public ITransform Parent { get; set; }
        public void Shoot()
        {
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {
            _PhysicsHandler.Move(gameTime, this, null);
            _AnimationHandler.Update(gameTime, _PhysicsHandler, _collision);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _AnimationHandler.Draw(spriteBatch, Parent);
        }
    }
}
