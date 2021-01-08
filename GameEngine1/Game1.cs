using GameEngine1.Art;
using GameEngine1.GameLogic;
using GameEngine1.GameObjects;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Utilities;
using GameEngine1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace GameEngine1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static int ScreenHeight = 1000;
        public static int ScreenWidth = 1900;
        public static Level currentLevel;
        private RandomNumberClass randomNumberGenerator;
        private Camera camera;
        public static IKeyboard keyBoard; //Static zodat niet miljoen keer moet doorgegeven worden
        public static MouseInput mouse; //Static zodat niet miljoen keer moet doorgegeven worden
        private bool paused = false;
        public static bool gameOver = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            randomNumberGenerator = new RandomNumberClass();
            Textures.Load(Content);
            camera = new Camera();
            keyBoard = (IKeyboard)Activator.CreateInstance(Type.GetType($"GameEngine1.Input.KeyboardInput"), new object[] { });
            mouse = new MouseInput();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            currentLevel = Factory.CreateLevel("LevelOne");
            currentLevel.Load();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouse.MouseUpdate(camera);
            keyBoard.KeyboardUpdate();
            if (keyBoard.KeyClicked(Keys.Escape))
                Exit();
            else if (keyBoard.KeyClicked(Keys.P))
                paused = !paused;
            if (paused)
                return;
            camera.Update(currentLevel.hero, mouse);
            if (currentLevel.humans.Count <= 1 || !currentLevel.hero.Alive)
            {
                gameOver = true;
            }
            currentLevel.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, transformMatrix: camera.Transform);
            currentLevel.Draw(_spriteBatch);
            if (gameOver)
            {
                if (currentLevel.hero.Health >= 1)
                {
                    _spriteBatch.DrawString(Textures.font, "GG", currentLevel.hero.Position, Color.Black);
                }
                else
                {
                    _spriteBatch.DrawString(Textures.font, "Game Over", currentLevel.hero.Position, Color.Black);
                }
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
