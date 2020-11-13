using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using StickFigureArmy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Characters
{
    public class Hero : ICollisionRectangle, ITransform
    {
        private Texture2D heroTexture;
        private IKeyboard keyboard;
        private List<Animation> animations;
        private const int Width = 16; //FrameWidth
        private const int Height = 24; //FrameHeight

        public Rectangle CollisionRectangle { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 PositionOld { get; set; }

        public Hero(Vector2 spawnCoordinates, Texture2D texture, IKeyboard keyboardInput) //Constructor met standaard spawnpositie
        {
            keyboard = keyboardInput;
            animations = new List<Animation>();
            animations.Add(Animation.Create(0, 0, Width, Height, 4, "idleLeft"));
            animations.Add(Animation.Create(Width * 4, 0, Width, Height, 4, "idleRight"));
            animations.Add(Animation.Create(0, Height, Width, Height, 4, "RunLeft"));
            animations.Add(Animation.Create(Width * 4, Height, Width, Height, 4, "RunRight"));
            animations.Add(Animation.Create(0, Height * 2, Width, Height, 1, "jumpLeft"));
            animations.Add(Animation.Create(0, Height * 2, Width, Height, 1, "jumpRight"));
            Position = spawnCoordinates;
            CollisionRectangle = new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), 8, 24);
            heroTexture = texture;
            //mouse = new MouseInput; muis moet nog geimplementeerd worden in Input folder!
        }
        public void Update(GameTime gameTime)
        {
            //Read inputs

            //Calculate physics
            //Check collisions
            //Fix collisions
            //Update state
            animations[2].Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Position, animations[2].CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }
    }
}
