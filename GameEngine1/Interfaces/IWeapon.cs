using System;
using GameEngine1.GameObjects;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Physics;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine1.Interfaces
{
    public interface IWeapon
    {
        public void Shoot(GameTime gameTime);
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
        public IMouseInput Mouse { get; set; }
    }
}
