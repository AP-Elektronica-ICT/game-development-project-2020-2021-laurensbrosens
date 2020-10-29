using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Characters
{
    public class Hero
    {
        private Texture2D heroTexture;
        public Vector2 Position { get; set; }
        public Point PositionOld { get; set; } //Oude positie van collisionrectangle
        public Rectangle CollisionRectangle { get; set; }
        private IInput keyboard;
        private IInput mouse;
        private List<Animation> animations;
        public Hero(Vector2 spawnCoordinates, Texture2D texture, IInput keyboardType) //Constructor met standaard spawnpositie
        {
            animations = new List<Animation>();
            animations.Add(Animation.Create(0,24,16,24,4,"idleLeft"));

            Position = spawnCoordinates;
            CollisionRectangle = new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), 8, 24);
            heroTexture = texture;
            keyboard = keyboardType;
            //mouse = new MouseInput; muis moet nog geimplementeerd worden in Input folder!
        }
        public void Update(GameTime gameTime)
        {
            //Read inputs
            //Calculate physics
            //Check collisions
            //Fix collisions
            //Update state
            animations[0].Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Position, animations[0].CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }

    }
}
