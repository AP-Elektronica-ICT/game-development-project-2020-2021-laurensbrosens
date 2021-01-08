using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameEngine1.Collisions;
using GameEngine1.GameLogic;
using GameEngine1.GameObjects;
using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine1.Art
{
    class Textures
    {
        public static Texture2D heroTexture { get; private set; }
        public static Texture2D BlueBuilding { get; private set; }
        public static Texture2D GreenBuilding { get; private set; }
        public static Texture2D PinkBuilding { get; private set; }
        public static Texture2D RoundBuilding { get; private set; }
        public static Texture2D bulletTexture { get; private set; }
        public static Texture2D gunTexture { get; private set; }
        public static Texture2D EnemyTexture { get; private set; }
        public static Texture2D GroundTexture { get; private set; }
        public static SpriteFont font { get; private set; }
        public static void Load(ContentManager Content)
        {
            heroTexture = Content.Load<Texture2D>("SoldierAnimations");
            BlueBuilding = Content.Load<Texture2D>("BlueBuilding");
            GreenBuilding = Content.Load<Texture2D>("GreenBuilding");
            PinkBuilding = Content.Load<Texture2D>("PinkBuilding");
            RoundBuilding = Content.Load<Texture2D>("RoundBuilding");
            bulletTexture = Content.Load<Texture2D>("Bullet_Blue");
            gunTexture = Content.Load<Texture2D>("blueGun");
            EnemyTexture = Content.Load<Texture2D>("Enemies");
            GroundTexture = Content.Load<Texture2D>("GroundTexture");
            font = Content.Load<SpriteFont>("Arial");
        }
    }
}
