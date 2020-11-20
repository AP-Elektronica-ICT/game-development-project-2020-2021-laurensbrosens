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
using StickFigureArmy.Utilities;

namespace StickFigureArmy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Camera camera;
        public static int ScreenHeight = 800;
        public static int ScreenWidth = 1500;
        public Hero hero;
        public List<ICollision> HeroCollidableObjects;
        private Map map1;
        private MapGenerator mapGenerator;
        private Texture2D heroTexture;
        private Texture2D BlueBuilding;
        private Texture2D GreenBuilding;
        private Texture2D PinkBuilding;
        private Texture2D RoundBuilding;
        private List<Texture2D> buildingTextures;
        private RandomNumberClass randomNumberGenerator;
        //private Texture2D pixel;
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
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            randomNumberGenerator = new RandomNumberClass();
            mapGenerator = new MapGenerator();
            keyBoard = (IKeyboard)Activator.CreateInstance(Type.GetType($"StickFigureArmy.Input.KeyboardInput"), new Object[] { });
            mouse = new MouseInput();
            //keyBoard = new KeyboardInputQwerty();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera();
            heroTexture = Content.Load<Texture2D>("SoldierAnimations");
            BlueBuilding = Content.Load<Texture2D>("BlueBuilding");
            GreenBuilding = Content.Load<Texture2D>("GreenBuilding");
            PinkBuilding = Content.Load<Texture2D>("PinkBuilding");
            RoundBuilding = Content.Load<Texture2D>("RoundBuilding");
            buildingTextures = new List<Texture2D>();
            buildingTextures.Add(BlueBuilding);
            buildingTextures.Add(GreenBuilding);
            buildingTextures.Add(PinkBuilding);
            buildingTextures.Add(RoundBuilding);
            map1 = mapGenerator.GenerateMap("City", 500, 40, 80, 10000, buildingTextures, new Rectangle(0, 0, 100, 100), new Rectangle(0, 101, 100, 100), 8, 3);
            HeroCollidableObjects = new List<ICollision>();
            foreach (var platform in map1.Platforms)
            {
                HeroCollidableObjects.Add(platform);
            }
            HeroCollidableObjects.Add(map1.Ground);
            hero = new Hero(new Vector2(150,1999), heroTexture, keyBoard, HeroCollidableObjects);
        }

        protected override void Update(GameTime gameTime)
        {
            keyBoard.KeyboardUpdate();
            mouse.MouseUpdate(camera);
            if (keyBoard.KeyClicked(Keys.Escape))
                Exit();
            else if (keyBoard.KeyClicked(Keys.P))
                paused = !paused;
            if (paused)
                return;
            hero.Update(gameTime, camera);
            camera.Update(hero);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(transformMatrix: camera.Transform);
            map1.Draw(_spriteBatch); //Map eerst zodat achtergrond
            hero.Draw(_spriteBatch); //Hero laatst zodat overlappent
            
             //De verschillende points om te zien of iets geraakt wordt
             /*
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
