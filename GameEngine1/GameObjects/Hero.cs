using System;
using System.Collections.Generic;
using System.Text;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine1.GameObjects
{
    public sealed class Hero : Human
    {
        public override void Update(GameTime gameTime)
        {
            _PhysicsHandler.Move(gameTime, this, Input);
            _collision.HanldeCollisions(_PhysicsHandler, this);
            _AnimationHandler.Update(gameTime, _PhysicsHandler, _collision);
            Weapon.Update(gameTime);
        }
    }
}
