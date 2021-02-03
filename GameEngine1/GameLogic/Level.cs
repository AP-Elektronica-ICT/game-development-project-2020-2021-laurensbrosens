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
            obstacles = new List<Entity>();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Entity entity in obstacles)
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
            foreach (Entity entity in obstacles)
            {
                entity.Update(gameTime);
            }
            int countHeroes = 0;
            int countEnemies = 0;
            foreach (Human human in humans)
            {
                if (human.Team == 1)
                {
                    countHeroes++;
                }
                else
                {
                    countEnemies++;
                }
                human.Update(gameTime);
            }
            if (countEnemies == 0)
            {
                Game1.gameOver = true;
            }
            foreach (Bullet bullet in bullets)
            {
                bullet.Update(gameTime);
            }
        }
        public List<Bullet> bullets { get; set; }
        public List<Human> humans { get; set; }
        public List<Entity> obstacles { get; set; }
        public Hero hero { get; set; }
    }
}
