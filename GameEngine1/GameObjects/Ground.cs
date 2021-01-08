using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.GameObjects
{
    class Ground : Entity
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, new Rectangle(0, 0, Length, Height), Color.White, Rotation, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }
        public Ground(int length = 2000, int height = 100)
        {
            Length = length;
            Height = height;
        }
    }
}
