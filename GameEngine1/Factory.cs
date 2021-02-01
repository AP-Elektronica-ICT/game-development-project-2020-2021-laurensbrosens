﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameEngine1.AILogic;
using GameEngine1.Animations;
using GameEngine1.Art;
using GameEngine1.Collisions;
using GameEngine1.GameLogic;
using GameEngine1.GameObjects;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Physics;
using GameEngine1.Utilities;
using GameEngine1.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine1
{
    public static class Factory
    {
        public static Level CreateLevel(string EntityType)
        {
            try
            {
                Level level = (Level)Activator.CreateInstance(Type.GetType($"GameEngine1.GameLogic.{EntityType}"), new object[] { });
                return level;
            }
            catch (Exception)
            {
                Debug.Write("Error: Level creation failed in Factory class\n");
                throw;
            }
        }
        public static IEntity CreateEntity(string EntityType)
        {
            try
            {
                Entity entity = (Entity)Activator.CreateInstance(Type.GetType($"GameEngine1.GameObjects.{EntityType}"), new object[] { });
                return entity;
            }
            catch (Exception)
            {
                Debug.Write("Error: Entity creation failed in Factory class\n");
                throw;
            }
        }
        public static IEntity CreateBuilding(Vector2 position, Texture2D texture, int height = 2)
        {
            Building skyScraper = new Building
            {
                Texture = texture,
                Height = height,
                Position = position
            };
            return skyScraper;
        }
        public static IEntity CreateGround(Vector2 position)
        {
            RigidBodyCollision collision = new RigidBodyCollision
            {
                RectangleHeight = 100,
                RectangleWidth = 10000
            };
            collision.UpdateRectangle(position);
            Entity ground = new Ground()
            {
                Length = collision.RectangleWidth,
                Height = 1000,
                Position = position,
                Texture = Textures.GroundTexture,
                _collision = collision
            };
            return ground;
        }
        public static IEntity CreatePlatform(Vector2 position) //Onzichtbaar want geen texture
        {
            OneWayCollision collision = new OneWayCollision
            {
                RectangleHeight = 20,
                RectangleWidth = 100
            };
            collision.UpdateRectangle(position);
            Entity platform = new Entity
            {
                Position = position,
                _collision = collision
            };
            return platform;
        }
        public static List<Animation> CreateHeroAnimations()
        {
            int Width = 16;
            int Height = 24;
            List<Animation> animations = new List<Animation>();
            animations.Add(CreateAnimation(0, 0, Width, Height, 4, "idleLeft", 5f));
            animations.Add(CreateAnimation(Width * 4, 0, Width, Height, 4, "idleRight", 5f));
            animations.Add(CreateAnimation(0, Height, Width, Height, 4, "RunLeft", 5f));
            animations.Add(CreateAnimation(Width * 4, Height, Width, Height, 4, "RunRight", 5f));
            animations.Add(CreateAnimation(0, Height * 2, Width, Height, 1, "jumpLeft", 5f));
            animations.Add(CreateAnimation(Width * 4, Height * 2, Width, Height, 1, "jumpRight", 5f));
            return animations;
        }
        public static List<Animation> CreateEnemyAnimations()
        {
            int Width = 16;
            int Height = 24;
            List<Animation> animations = new List<Animation>();
            animations.Add(CreateAnimation(0, 0, Width, Height, 4, "idleLeft", 5f));
            animations.Add(CreateAnimation(0, Height, Width, Height, 4, "idleRight", 5f));
            animations.Add(CreateAnimation(0, Height * 2, Width, Height, 4, "RunLeft", 5f));
            animations.Add(CreateAnimation(0, Height * 3, Width, Height, 4, "RunRight", 5f));
            animations.Add(CreateAnimation(0, Height * 4, Width, Height, 1, "jumpLeft", 5f));
            animations.Add(CreateAnimation(0, Height * 5, Width, Height, 1, "jumpRight", 5f));
            return animations;
        }
        public static Weapon CreateWeapon(Entity anObject, IMouseInput mouse)
        {
            Weapon weapon = new Weapon();
            weapon.Mouse = mouse;
            GunAnimationHandler animationHandler = new GunAnimationHandler();
            animationHandler.Texture = Textures.gunTexture;
            animationHandler.Mouse = mouse;
            animationHandler.animations = CreateGunAnimations();
            animationHandler.ParentTransform = anObject; //Volg object
            weapon._AnimationHandler = animationHandler;
            weapon._collision = anObject._collision;
            weapon.Position = anObject.Position; //Startpositie
            weapon.Scale = 0.9f;
            weapon.Team = ((Human)anObject).Team;
            return weapon;
        }
        public static void CreateBullet(ITransform transform, int team, Vector2 direction)
        {
            Bullet bullet = new Bullet();
            List<ICollision> targets = new List<ICollision>(); //is nog leeg
            foreach (var human in ((Level)bullet.currentLevel).humans)
            {
                if (human.Team != team)
                {
                    targets.Add(human._collision);
                }
            }
            targets.Add(((Level)bullet.currentLevel).obstacles[0]._collision); //Voeg grond toe, hardcoded voor nu
            bullet.Texture = Textures.bulletTexture;
            BulletPhysicsHandler physicsHandler = new BulletPhysicsHandler();
            physicsHandler.inputAcceleration = 700; //Default 800
            Vector2 accuracyReduction = new Vector2(RandomNumberClass.GenerateRandomFloat(-0.12f,0.12f), RandomNumberClass.GenerateRandomFloat(-0.07f, 0.03f));
            direction = Vector2.Normalize(direction);
            direction += accuracyReduction;
            physicsHandler.Direction = Vector2.Normalize(direction);
            bullet._PhysicsHandler = physicsHandler;
            BulletCollision collision = new BulletCollision(transform.Position, targets);
            collision.RectangleWidth = 5;
            collision.RectangleHeight = 3;
            //collision.RectangleOffsetX = 13;
            //collision.RectangleOffsetY = 14;
            bullet._collision = collision;
            bullet._collision.Parent = bullet;
            bullet.Scale = 2.5f;
            bullet.Rotation = MathUtilities.VectorToAngle(direction);
            bullet.Position = new Vector2(transform.Position.X + 9, transform.Position.Y + 13);
            ((Level)bullet.currentLevel).bullets.Add(bullet);
        }
        public static List<Animation> CreateGunAnimations()
        {
            int Width = 80;
            int Height = 80;
            List<Animation> animations = new List<Animation>();
            animations.Add(CreateAnimation(0, 0, Width, Height, 9, "ShootLeft", 15f));
            animations.Add(CreateAnimation(0, Height, Width, Height, 9, "ShootRight", 15f));
            animations.Add(CreateAnimation(0, Height*2, Width, Height, 1, "idleLeft", 1f));
            animations.Add(CreateAnimation(Width, Height*2, Width, Height, 1, "idleRight", 1f));
            return animations;
        }
        public static IEntity CreateHero(Vector2 spawnPosition, List<IEntity> obstacles)
        {
            PhysicsHandler physics = new PhysicsHandler();
            HeroAnimationHandler animationHandler = new HeroAnimationHandler(Textures.heroTexture);
            animationHandler.animations = CreateHeroAnimations();
            animationHandler.Mouse = Game1.mouse;
            List<ICollision> collidableList = new List<ICollision>();
            foreach (var obstacle in obstacles)
            {
                if (obstacle._collision != null)
                {
                    collidableList.Add(obstacle._collision);
                }
            }
            HeroCollision collision = new HeroCollision(spawnPosition, collidableList);
            
            PlayerInput input = new PlayerInput(Game1.keyBoard);
            Hero hero = new Hero
            {
                Texture = Textures.heroTexture,
                Team = 1,
                Scale = 1f,
                Position = spawnPosition,
                _PhysicsHandler = physics,
                _AnimationHandler = animationHandler,
                _collision = collision,
                Input = input,
                Health = 20
            };
            hero._collision.Parent = hero;
            hero.Weapon = CreateWeapon(hero, animationHandler.Mouse);
            return hero;
        }
        public static IEntity CreateSoldier(Vector2 spawnPosition, List<IEntity> obstacles, int teamNumber)
        {
            PhysicsHandler physics = new PhysicsHandler();
            SoldierAI AI = new SoldierAI();
            HeroAnimationHandler animationHandler;
            AI.Team = teamNumber;
            if (AI.Team == 1)
            {
                animationHandler = new HeroAnimationHandler(Textures.heroTexture);
                animationHandler.animations = CreateHeroAnimations();
            }
            else
            {
                animationHandler = new HeroAnimationHandler(Textures.EnemyTexture);
                animationHandler.animations = CreateEnemyAnimations();
            }
            
            AIMouseInput aiMouse = new AIMouseInput();
            animationHandler.Mouse = aiMouse;
            List<ICollision> collidableList = new List<ICollision>();
            foreach (var obstacle in obstacles)
            {
                if (obstacle._collision != null)
                {
                    collidableList.Add(obstacle._collision);
                }
            }
            HeroCollision collision = new HeroCollision(spawnPosition, collidableList);
            AIInput input = new AIInput();
            Soldier soldier = new Soldier(teamNumber)
            {
                Texture = Textures.heroTexture,
                Scale = 1f,
                Position = spawnPosition,
                _PhysicsHandler = physics,
                _AnimationHandler = animationHandler,
                _collision = collision,
                Input = input,
                Health = 15
            };
            AI.Soldier = soldier;
            soldier.soldierAI = AI;
            aiMouse.soldierAI = AI;
            input.soldierAI = AI;
            soldier._collision.Parent = soldier;
            soldier.Weapon = CreateWeapon(soldier, aiMouse);
            return soldier;
        }
        static public Animation CreateAnimation(int x, int y, int width, int height, int frameAmount, string name, float fps) //Creëert een animatie op dezelfde rij
        {
            Animation animation = new Animation();
            animation.FramesPerSecond = fps;
            animation.Name = name;
            for (int i = 0; i < frameAmount; i++)
            {
                animation.AddFrame(new Frame(new Rectangle(x, y, width, height)));
                x += width;
            }
            return animation;
        }
    }
}
