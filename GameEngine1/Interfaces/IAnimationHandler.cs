using GameEngine1.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Interfaces
{
    public interface IAnimationHandler
    {
        public void Update(GameTime gameTime, IPhysicsHandler physics, ICollision hero);
        public void Draw(SpriteBatch spriteBatch, ITransform hero);
    }
}
