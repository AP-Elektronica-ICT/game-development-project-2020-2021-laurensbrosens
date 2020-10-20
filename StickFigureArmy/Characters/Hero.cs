using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Characters
{
    class Hero
    {
        private Texture2D heroTexture;
        private Animation animation;
        public Vector2 Position { get; set; }
        public Point PositionOld { get; set; } //Oude positie van collisionrectangle
        public Rectangle CollisionRectangle { get; set; }
        private IInput keyboard;
        private IInput mouse;
        public Hero(Vector2 spawnCoordinates, Texture2D texture, IInput keyboardType) //Constructor met standaard spawnpositie
        {
            animation = new Animation();
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
            animation.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(heroTexture, Position, animatie.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }

    }
}
