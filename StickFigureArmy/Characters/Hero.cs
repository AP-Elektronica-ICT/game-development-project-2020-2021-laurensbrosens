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
            animation.AddFrame(new Frame(new Rectangle(0,24,16,24)));
            animation.AddFrame(new Frame(new Rectangle(16, 24, 16, 24)));
            animation.AddFrame(new Frame(new Rectangle(32, 24, 16, 24)));
            animation.AddFrame(new Frame(new Rectangle(48, 24, 16, 24)));
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
            spriteBatch.Draw(heroTexture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }

    }
}
