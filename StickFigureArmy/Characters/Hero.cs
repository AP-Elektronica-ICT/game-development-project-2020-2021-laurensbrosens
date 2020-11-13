using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Characters
{
    public class Hero : ICollisionRectangle, ITransform
    {
        private Texture2D heroTexture;
        private List<Animation> animations;
        private const int Width = 16; //FrameWidth
        private const int Height = 24; //FrameHeight
        private IGameCommand move;
        private State state;
        private PlayerInput playerInput;
        public Rectangle CollisionRectangle { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 PositionOld { get; set; }
        public int RectangleWidth { get; set; }
        public int RectangleHeight { get; set; }

        public Hero(Vector2 spawnCoordinates, Texture2D texture, IKeyboard keyboardInput) //Constructor met standaard spawnpositie
        {
            animations = new List<Animation>();
            animations.Add(Animation.Create(0, 0, Width, Height, 4, "idleLeft"));
            animations.Add(Animation.Create(Width * 4, 0, Width, Height, 4, "idleRight"));
            animations.Add(Animation.Create(0, Height, Width, Height, 4, "RunLeft"));
            animations.Add(Animation.Create(Width * 4, Height, Width, Height, 4, "RunRight"));
            animations.Add(Animation.Create(0, Height * 2, Width, Height, 1, "jumpLeft"));
            animations.Add(Animation.Create(0, Height * 2, Width, Height, 1, "jumpRight"));
            Position = spawnCoordinates;
            move = new MovementCommand();
            state = new State();
            CollisionRectangle = new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), 8, 24);
            heroTexture = texture;
            playerInput = new PlayerInput(keyboardInput);
            //mouse = new MouseInput; muis moet nog geimplementeerd worden in Input folder!
        }
        public void Update(GameTime gameTime)
        {
            animations[2].Update(gameTime);
            move.Execute(gameTime, state, this, playerInput, this);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Position, animations[2].CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }
    }
}
