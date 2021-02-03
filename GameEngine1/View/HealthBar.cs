using GameEngine1.Animations;
using GameEngine1.Art;
using GameEngine1.GameObjects;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Physics;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameEngine1.View
{
    public class HealthBar : Entity
    {
        public IHealth Health { get; set; }
        private int healthBarLength;
        public ITransform ParentTransform { get; set; } //Nodig om parent te volgen
        public override void Update(GameTime gameTime)
        {
            double relativeHealth = ((double)Health.Health / (double)Health.MaxHealth) * 10;
            healthBarLength = (int)Math.Round(relativeHealth) + 1;
            Position = new Vector2(ParentTransform.Position.X, ParentTransform.Position.Y - 10);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Textures.HealthBar, Position, new Rectangle(0, 0, 16, 16), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
            spriteBatch.Draw(Textures.HealthBar, Position, new Rectangle(0, 16, healthBarLength, 16), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }
    }
}
