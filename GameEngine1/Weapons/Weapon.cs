using GameEngine1.Animations;
using GameEngine1.Art;
using GameEngine1.Factories;
using GameEngine1.GameObjects;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Physics;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameEngine1.Weapons
{
    public class Weapon : MovableEntity, IWeapon, ITeam
    {
        private bool canShoot = true;
        AnimationFactory animationFactory;
        public IMouseInput Mouse { get; set; }
        public int Team { get; set; }

        private Cooldown cooldown;
        private float shootingSpeed; //Max kliksnelheid voor schieten
        public Weapon(Entity anObject, IMouseInput mouse)
        {
            Mouse = mouse;
            animationFactory = new AnimationFactory();
            GunAnimationHandler animationHandler = new GunAnimationHandler();
            animationHandler.Texture = Textures.gunTexture;
            animationHandler.Mouse = mouse;
            animationHandler.animations = CreateGunAnimations();
            animationHandler.ParentTransform = anObject; //Volg object
            _AnimationHandler = animationHandler;
            _collision = anObject._collision;
            Position = anObject.Position; //Startpositie
            Scale = 0.9f;
            Team = ((Human)anObject).Team;
            cooldown = new Cooldown();
            shootingSpeed = 0.05f;
        }
        public void Shoot(GameTime gameTime)
        {
            ((GunAnimationHandler)_AnimationHandler).Shoot = true;
            Vector2 direction = Mouse.Position - new Vector2(_collision.CollisionRectangle.X, _collision.CollisionRectangle.Y);
            Factory.CreateBullet(((GunAnimationHandler)_AnimationHandler).ParentTransform, Team, direction);
        }
        public override void Update(GameTime gameTime)
        {
            _AnimationHandler.Update(gameTime, _PhysicsHandler, _collision, this);
            if (cooldown.CooldownTimer(gameTime, shootingSpeed))
            {
                canShoot = true;
            }
            if (Mouse.LeftKeyDown() && canShoot)
            {
                Shoot(gameTime);
                canShoot = false;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _AnimationHandler.Draw(spriteBatch, this);
        }
        protected List<Animation> CreateGunAnimations()
        {
            int Width = 80;
            int Height = 80;
            List<Animation> animations = new List<Animation>();
            animations.Add(animationFactory.CreateAnimation(0, 0, Width, Height, 9, "ShootLeft", 15f));
            animations.Add(animationFactory.CreateAnimation(0, Height, Width, Height, 9, "ShootRight", 15f));
            animations.Add(animationFactory.CreateAnimation(0, Height * 2, Width, Height, 1, "idleLeft", 1f));
            animations.Add(animationFactory.CreateAnimation(Width, Height * 2, Width, Height, 1, "idleRight", 1f));
            return animations;
        }
    }
}
