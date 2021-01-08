﻿using System;
using System.Collections.Generic;
using System.Text;
using GameEngine1.GameObjects;
using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine1.GameLogic
{
    public abstract class Level : ILevel
    {
        public virtual void Load()
        {
            bullets = new List<Bullet>();
            humans = new List<Human>();
            obstacles = new List<IEntity>();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEntity entity in obstacles)
            {
                entity.Draw(spriteBatch);
            }
            foreach (Human human in humans)
            {
                human.Draw(spriteBatch);
            }
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }
        public virtual void Update(GameTime gameTime)
        {
            foreach (IEntity entity in obstacles)
            {
                entity.Update(gameTime);
            }
            foreach (Human human in humans)
            {
                human.Update(gameTime);
            }
            foreach (Bullet bullet in bullets)
            {
                bullet.Update(gameTime);
            }
        }

        protected List<Bullet> bullets;
        protected List<Human> humans;
        protected List<IEntity> obstacles;
        public Hero hero { get; set; }
    }
}