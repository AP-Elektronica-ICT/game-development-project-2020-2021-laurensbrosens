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
        public static Texture2D BulletTexture { get; private set; }
        public static Texture2D ExplosionBulletTexture { get; private set; }
        public static Texture2D gunTexture { get; private set; } //Bron: https://community.playstarbound.com/threads/weapon-sprite-megathread.15841/
        public static Texture2D EnemyTexture { get; private set; }
        public static Texture2D GroundTexture { get; private set; }
        public static Texture2D IntroTexture { get; private set; }
        public static Texture2D HealthBar { get; private set; }
        public static Texture2D Explosion { get; private set; }
        public static SpriteFont font1 { get; private set; }
        public static SpriteFont font2 { get; private set; }
        public static SpriteFont font3 { get; private set; }
        public static void Load(ContentManager Content)
        {
            heroTexture = Content.Load<Texture2D>("SoldierAnimations");
            BlueBuilding = Content.Load<Texture2D>("BlueBuilding");
            GreenBuilding = Content.Load<Texture2D>("GreenBuilding");
            PinkBuilding = Content.Load<Texture2D>("PinkBuilding");
            RoundBuilding = Content.Load<Texture2D>("RoundBuilding");
            BulletTexture = Content.Load<Texture2D>("Bullet_Blue");
            ExplosionBulletTexture = Content.Load<Texture2D>("Bullet_Red");
            gunTexture = Content.Load<Texture2D>("blueGun");
            EnemyTexture = Content.Load<Texture2D>("Enemies");
            GroundTexture = Content.Load<Texture2D>("GroundTexture");
            IntroTexture = Content.Load<Texture2D>("IntroBackground");
            HealthBar = Content.Load<Texture2D>("HealthBarTexture");
            Explosion = Content.Load<Texture2D>("ExplosionAnimation");
            font1 = Content.Load<SpriteFont>("Arial");
            font2 = Content.Load<SpriteFont>("Arial2");
            font3 = Content.Load<SpriteFont>("Arial3");
        }
    }
}