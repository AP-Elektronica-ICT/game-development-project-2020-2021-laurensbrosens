using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            obstacles.RemoveAll(x => x.Alive == false);
            humans.RemoveAll(x => x.Alive == false);
            bullets.RemoveAll(x => x.Alive == false);
            foreach (IEntity entity in obstacles)
            {
                entity.Update(gameTime);
            }
            foreach (Human human in humans)
            {
                if (human.Team == 2)
                {
                    Debug.Write(human.Health);
                }
                human.Update(gameTime);
            }
            foreach (Bullet bullet in bullets)
            {
                bullet.Update(gameTime);
            }
        }
        public List<Bullet> bullets { get; set; }
        public List<Human> humans { get; set; }
        public List<IEntity> obstacles { get; set; }
        public Hero hero { get; set; }
    }
}
