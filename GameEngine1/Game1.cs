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
        private bool intro = true;
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
            camera.Update(currentLevel.hero, mouse);
            if (keyBoard.KeyClicked(Keys.Escape))
                Exit();

            if (intro) {
                if (mouse.LeftKeyClicked())
                {
                    intro = false;
                }
                return;
            }
            if (keyBoard.KeyClicked(Keys.P))
                paused = !paused;
            if (paused)
                return;
            
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
            if (intro)
            {
                _spriteBatch.Draw(Textures.IntroTexture, new Vector2(currentLevel.hero.Position.X-2000, currentLevel.hero.Position.Y-500), new Rectangle(0, 0, 3000, 3000), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                _spriteBatch.DrawString(Textures.font1, "Stick figure army", new Vector2(currentLevel.hero.Position.X -200, currentLevel.hero.Position.Y-80), Color.Black);
                _spriteBatch.DrawString(Textures.font2, "Klik met je muis om te starten", new Vector2(currentLevel.hero.Position.X -200, currentLevel.hero.Position.Y-20), Color.Black);
            }
            else if (gameOver)
            {
                if (currentLevel.hero.Health >= 1)
                {
                    _spriteBatch.Draw(Textures.IntroTexture, new Vector2(currentLevel.hero.Position.X - 2000, currentLevel.hero.Position.Y - 500), new Rectangle(0, 0, 3000, 3000), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                    _spriteBatch.DrawString(Textures.font1, "You won!", new Vector2(currentLevel.hero.Position.X - 200, currentLevel.hero.Position.Y - 80), Color.Black);
                }
                else
                {
                    _spriteBatch.Draw(Textures.IntroTexture, new Vector2(currentLevel.hero.Position.X - 2000, currentLevel.hero.Position.Y - 500), new Rectangle(0, 0, 3000, 3000), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
                    _spriteBatch.DrawString(Textures.font1, "Game Over", new Vector2(currentLevel.hero.Position.X - 200, currentLevel.hero.Position.Y - 80), Color.Black);
                }
            }
            else
            {
                currentLevel.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
