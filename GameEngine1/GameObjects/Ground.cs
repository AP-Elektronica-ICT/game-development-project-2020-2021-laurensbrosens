using GameEngine1.Art;
using GameEngine1.Collisions;
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
        public Ground(Vector2 position, Texture2D texture, int width = 2000)
        {
            Length = 2000;
            Height = 100;
            RigidBodyCollision collision = new RigidBodyCollision
            {
                RectangleHeight = 100,
                RectangleWidth = 10000
            };
            collision.UpdateRectangle(position);
            _collision = collision;
            Length = collision.RectangleWidth;
            Height = 1000;
            Position = position;
            Texture = texture;
        }
    }
}
