using GameEngine1.Animations;
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
        public MouseInput Mouse { get; set; }
        public int Team { get; set; }

        private Cooldown cooldown;
        private float shootingSpeed; //Max kliksnelheid voor schieten
        public Weapon()
        {
            cooldown = new Cooldown();
            shootingSpeed = 0.5f;
        }
        public void Shoot(GameTime gameTime)
        {
            ((GunAnimationHandler)_AnimationHandler).Shoot = true; //Default is niet auto-fire
            Vector2 direction = Mouse.Position - new Vector2(_collision.CollisionRectangle.X, _collision.CollisionRectangle.Y);
            Factory.CreateBullet(this, Team, direction);
        }
        public override void Update(GameTime gameTime)
        {
            _AnimationHandler.Update(gameTime, _PhysicsHandler, _collision, this);
            if (cooldown.CooldownTimer(gameTime, shootingSpeed))
            {
                canShoot = true;
            }
            if (Mouse.LeftKeyClicked() && canShoot)
            {
                Shoot(gameTime);
                canShoot = false;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _AnimationHandler.Draw(spriteBatch, this);
        }
    }
}
