﻿using GameEngine1.Interfaces;
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
            _PhysicsHandler.Move(gameTime, this, Input);
            _collision.HanldeCollisions(_PhysicsHandler, this);
            _AnimationHandler.Update(gameTime, _PhysicsHandler, _collision, this);
            Weapon.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Weapon.Draw(spriteBatch);
        }
    }
}
