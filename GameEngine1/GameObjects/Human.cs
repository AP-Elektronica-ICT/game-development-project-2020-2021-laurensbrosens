using GameEngine1.Interfaces;
using GameEngine1.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameEngine1.GameObjects
{
    public class Human : MovableEntity, IHealth, ITeam
    {
        public IInput Input { protected get; set; }
        public int Team { get; set; }
        public Weapon Weapon {get; set;}
        public int Health { get; set; }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Weapon.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Weapon.Draw(spriteBatch);
        }
    }
}
