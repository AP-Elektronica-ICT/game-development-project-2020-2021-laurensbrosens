using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameEngine1.GameObjects
{
    public class Entity : IEntity, ITransform
    {
        public bool Alive { get; set; } = true;
        virtual public ICollision _collision { get; set; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; }
        public Texture2D Texture { get; set; }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null) //Entities zonder texture moeten niet getekend worden
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}
