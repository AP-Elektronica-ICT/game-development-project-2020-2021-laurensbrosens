using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using StickFigureArmy.Characters;
using StickFigureArmy.Input;
using StickFigureArmy.Physics;
using StickFigureArmy.View;
using StickFigureArmy.Interfaces;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using StickFigureArmy.MapStuff;

namespace StickFigureArmy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Camera camera;
        public static int ScreenHeight;
        public static int ScreenWidth;
        public Hero hero;
        public Obstacle ground;
        public Obstacle ground2;
        public List<ICollision> Map;
        private Texture2D heroTexture;
        private Texture2D blackSquare;
        private Texture2D pixel;
        private IKeyboard keyBoard;
        private MouseInput mouse;

        private bool paused = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.PreferredBackBufferWidth = 1500;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            keyBoard = (IKeyboard)Activator.CreateInstance(Type.GetType($"StickFigureArmy.Input.KeyboardInput"), new Object[] { });
            mouse = new MouseInput();
            //keyBoard = new KeyboardInputQwerty();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera();
            heroTexture = Content.Load<Texture2D>("SoldierAnimations");
            blackSquare = Content.Load<Texture2D>("black100square");
            pixel = Content.Load<Texture2D>("SinglePixel");
            ground = new Obstacle(new Vector2(-10, 600), blackSquare);
            ground2 = new Obstacle(new Vector2(200, 400), blackSquare);
            Map = new List<ICollision>();
            Map.Add(ground);
            Map.Add(ground2);
            hero = new Hero(new Vector2(30,30), heroTexture, keyBoard, Map);
        }

        protected override void Update(GameTime gameTime)
        {
            keyBoard.KeyboardUpdate();
            mouse.MouseUpdate();
            if (keyBoard.KeyClicked(Keys.Escape))
                Exit();
            else if (keyBoard.KeyClicked(Keys.P))
                paused = !paused;
            if (paused)
                return;
            camera.Update();
            hero.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            ground.Draw(_spriteBatch);
            ground2.Draw(_spriteBatch);
            hero.Draw(_spriteBatch); //Hero laatst zodat overlappent
            /* De verschillende points om te zien of iets geraakt wordt
            _spriteBatch.Draw(pixel, new Rectangle(hero.CollisionBottom, new Point(40,40)), Color.White);
            _spriteBatch.Draw(pixel, new Rectangle(hero.CollisionTop, new Point(40, 40)), Color.White);
            _spriteBatch.Draw(pixel, new Rectangle(hero.CollisionLeft, new Point(40, 40)), Color.White);
            _spriteBatch.Draw(pixel, new Rectangle(hero.CollisionRight, new Point(40, 40)), Color.White);
            */
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
