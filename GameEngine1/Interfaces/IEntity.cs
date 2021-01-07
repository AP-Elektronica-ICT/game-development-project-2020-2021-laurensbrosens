using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine1.Interfaces
{
    public interface IEntity
    {
        public ICollision _collision { get; set; }
        public void Draw(SpriteBatch spriteBatch);
        public void Update(GameTime gameTime);
    }
}
