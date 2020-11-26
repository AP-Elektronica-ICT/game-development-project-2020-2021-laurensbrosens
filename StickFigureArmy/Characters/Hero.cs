using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using StickFigureArmy.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Characters
{
    public class Hero : ICollision, ITransform, IDraw, IAnimate, IDamageable
    {
        public List<Animation> animations { get; set; }
        private const int Width = 16; //FrameWidth
        private const int Height = 24; //FrameHeight
        private MovementCommand move;
        private State state;
        private PlayerInput playerInput;
        private MouseInput mouse;
        public Rectangle CollisionRectangle { get; set; }
        public Rectangle CollisionRectangleOld { get; set; }
        public int RectangleOffsetX { get; set; }
        public int RectangleOffsetY { get; set; }
        public Vector2 Position { get; set; }
        public int RectangleWidth { get; set; }
        public int RectangleHeight { get; set; }
        public Texture2D texture2D { get; set; }
        public IAnimationHandler animationHandler {get; set;}
        public ICollisionHandler CollisionHandler { get; set; }
        public ICollisionFix CollisionFix { get; set; } //Null voor nu want niets kan met character botsen
        public Point CollisionTop { get; set; }
        public Point CollisionBottom { get; set; }
        public Point CollisionLeft { get; set; }
        public Point CollisionRight { get; set; }
        public ICollisionCheck CollisionCheck { get; set; } //Null voor nu want niets kan met character botsen
        public int HP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Alive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private List<ICollision> collidableObjects;

        public Hero(Vector2 spawnCoordinates, Texture2D texture, IKeyboard keyboardInput, List<ICollision> collisionRectangles) //Constructor met standaard spawnpositie
        {
            animations = new List<Animation>();
            animations.Add(Animation.Create(0, 0, Width, Height, 4, "idleLeft", 5f));
            animations.Add(Animation.Create(Width * 4, 0, Width, Height, 4, "idleRight", 5f));
            animations.Add(Animation.Create(0, Height, Width, Height, 4, "RunLeft", 5f));
            animations.Add(Animation.Create(Width * 4, Height, Width, Height, 4, "RunRight", 5f));
            animations.Add(Animation.Create(0, Height * 2, Width, Height, 1, "jumpLeft", 5f));
            animations.Add(Animation.Create(Width * 4, Height * 2, Width, Height, 1, "jumpRight", 5f));
            animationHandler = new HeroAnimationHandler();
            Position = spawnCoordinates;
            CollisionHandler = new CharacterCollision();
            move = new MovementCommand();
            state = new State();
            collidableObjects = collisionRectangles;
            RectangleWidth = 8; //8 en 24
            RectangleHeight = 24;
            RectangleOffsetX = 4;
            RectangleOffsetY = 0;
            UpdateRectangle();
            UpdateCollisionPoints();
            CollisionRectangleOld = CollisionRectangle;
            texture2D = texture;
            playerInput = new PlayerInput(keyboardInput);
            mouse = new MouseInput();
        }
        public void Update(GameTime gameTime, Camera camera)
        {
            mouse.MouseUpdate(camera);
            move.Execute(gameTime, state, this, playerInput); //Beweeg hero
            CollisionHandler.CollisionHandler(this, state, move, this, collidableObjects); //Check op collisions
            animationHandler.Update(gameTime, state, move, this, mouse, this); //Update animatie en kiest juiste animatie om af te spelen obv. huidige state
        }
        public void Draw(SpriteBatch spriteBatch) //Deze nog aanpassen
        {
            animationHandler.Draw(texture2D, this, this, spriteBatch);
        }

        public void UpdateRectangle()
        {
            CollisionRectangle = new Rectangle((int)Math.Round(Position.X + RectangleOffsetX), (int)Math.Round(Position.Y + RectangleOffsetY), RectangleWidth, RectangleHeight);
        }

        public void UpdateCollisionPoints()
        {
            CollisionTop = new Point(CollisionRectangle.Center.X, CollisionRectangle.Top - 1);
            CollisionBottom = new Point(CollisionRectangle.Center.X, CollisionRectangle.Bottom + 1);
            CollisionLeft = new Point(CollisionRectangle.Left - 1, CollisionRectangle.Center.Y);
            CollisionRight = new Point(CollisionRectangle.Right + 1, CollisionRectangle.Center.Y);
        }
    }
}
