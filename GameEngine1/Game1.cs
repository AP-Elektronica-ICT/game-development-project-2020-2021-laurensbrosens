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
        public static int ScreenHeight = 800;
        public static int ScreenWidth = 1500;
        private ILevel currentLevel;
        private RandomNumberClass randomNumberGenerator;
        private Camera camera;
        public static IKeyboard keyBoard;
        public static MouseInput mouse;
        private bool paused = false;

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
            Art.Textures.Load(Content);
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
            //Debug.Write($"zoom = {currentLevel.hero.Position.Y}\n");
            camera.Update(currentLevel.hero, mouse);
            currentLevel.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, transformMatrix: camera.Transform);
            currentLevel.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
