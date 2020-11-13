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
    public class Hero : ICollisionRectangle, ITransform, IDraw
    {
        private List<Animation> animations;
        private const int Width = 16; //FrameWidth
        private const int Height = 24; //FrameHeight
        private IGameCommand move;
        private State state;
        private PlayerInput playerInput;
        public Rectangle CollisionRectangle { get; set; }
        public Rectangle CollisionRectangleOld { get; set; }
        public int RectangleOffsetX { get; set; }
        public int RectangleOffsetY { get; set; }
        public Vector2 Position { get; set; }
        public int RectangleWidth { get; set; }
        public int RectangleHeight { get; set; }
        public Texture2D texture2D { get; set; }

        private List<ICollisionRectangle> collidableObjects;

        public Hero(Vector2 spawnCoordinates, Texture2D texture, IKeyboard keyboardInput, List<ICollisionRectangle> collisionRectangles) //Constructor met standaard spawnpositie
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
            collidableObjects = collisionRectangles;
            RectangleWidth = 8; //8 en 24
            RectangleHeight = 24;
            RectangleOffsetX = 4;
            RectangleOffsetY = 0;
            UpdateRectangle();
            CollisionRectangleOld = CollisionRectangle;
            texture2D = texture;
            playerInput = new PlayerInput(keyboardInput);
            //mouse = new MouseInput; muis moet nog geimplementeerd worden in Input folder!
        }
        public void Update(GameTime gameTime)
        {
            animations[2].Update(gameTime);
            move.Execute(gameTime, state, this, playerInput, this, collidableObjects);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, Position, animations[2].CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }

        public void UpdateRectangle()
        {
            CollisionRectangle = new Rectangle((int)Math.Round(Position.X + RectangleOffsetX), (int)Math.Round(Position.Y + RectangleOffsetY), RectangleWidth, RectangleHeight);
        }
    }
}
