using GameEngine1.Animations;
using GameEngine1.Collisions;
using GameEngine1.Factories;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Physics;
using GameEngine1.View;
using GameEngine1.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameEngine1.GameObjects
{
    public abstract class Human : MovableEntity, IHealth, ITeam
    {
        public IInput Input { protected get; set; }
        AnimationFactory animationFactory;
        public int Team { get; set; }
        public IWeapon Weapon {get; set;}
        public HealthBar healthBar { get; set; }
        public float Health { get; set; } = 10;
        public int MaxHealth { get; set; } = 10;
        public bool Hit { get; set; } = false;
        public Human(Vector2 spawnPosition, Texture2D texture, List<Entity> obstacles, int team)
        {
            animationFactory = new AnimationFactory();
            Position = spawnPosition;
            Texture = texture;
            Team = team;
            Scale = 1f;
            Input = new AIInput();
            _PhysicsHandler = new PhysicsHandler();
            List<ICollision> collidableList = new List<ICollision>();
            foreach (var obstacle in obstacles)
            {
                if (obstacle._collision != null)
                {
                    collidableList.Add(obstacle._collision);
                }
            }
            _collision = new HumanCollision(spawnPosition, collidableList);
            _collision.Parent = this;
            healthBar = new HealthBar();
            healthBar.ParentTransform = this;
            healthBar.Health = this;
        }
        public override void Update(GameTime gameTime)
        {
            if (Health <= 0)
            {
                Alive = false;
            }
            _PhysicsHandler.Move(gameTime, this, Input);
            _collision.HanldeCollisions(_PhysicsHandler, this);
            _AnimationHandler.Update(gameTime, _PhysicsHandler, _collision, this);
            Weapon.Update(gameTime);
            healthBar.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Weapon.Draw(spriteBatch);
            healthBar.Draw(spriteBatch);
        }
        protected List<Animation> CreateHeroAnimations()
        {
            int Width = 16;
            int Height = 24;
            List<Animation> animations = new List<Animation>();
            animations.Add(animationFactory.CreateAnimation(0, 0, Width, Height, 4, "idleLeft", 5f));
            animations.Add(animationFactory.CreateAnimation(Width * 4, 0, Width, Height, 4, "idleRight", 5f));
            animations.Add(animationFactory.CreateAnimation(0, Height, Width, Height, 4, "RunLeft", 5f));
            animations.Add(animationFactory.CreateAnimation(Width * 4, Height, Width, Height, 4, "RunRight", 5f));
            animations.Add(animationFactory.CreateAnimation(0, Height * 2, Width, Height, 1, "jumpLeft", 5f));
            animations.Add(animationFactory.CreateAnimation(Width * 4, Height * 2, Width, Height, 1, "jumpRight", 5f));
            return animations;
        }
        protected List<Animation> CreateEnemyAnimations()
        {
            int Width = 16;
            int Height = 24;
            List<Animation> animations = new List<Animation>();
            animations.Add(animationFactory.CreateAnimation(0, 0, Width, Height, 4, "idleLeft", 5f));
            animations.Add(animationFactory.CreateAnimation(0, Height, Width, Height, 4, "idleRight", 5f));
            animations.Add(animationFactory.CreateAnimation(0, Height * 2, Width, Height, 4, "RunLeft", 5f));
            animations.Add(animationFactory.CreateAnimation(0, Height * 3, Width, Height, 4, "RunRight", 5f));
            animations.Add(animationFactory.CreateAnimation(0, Height * 4, Width, Height, 1, "jumpLeft", 5f));
            animations.Add(animationFactory.CreateAnimation(0, Height * 5, Width, Height, 1, "jumpRight", 5f));
            return animations;
        }
    }
}
