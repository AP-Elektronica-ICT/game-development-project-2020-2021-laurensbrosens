using System;
using System.Collections.Generic;
using System.Text;
using GameEngine1.Animations;
using GameEngine1.Art;
using GameEngine1.Factories;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine1.GameObjects
{
    public sealed class Hero : Human
    {
        IWeapon weapon2;
        IWeapon weapon1;
        public Hero(Vector2 spawnPosition, Texture2D texture, List<Entity> obstacles, int team) : base(spawnPosition, texture, obstacles, team)
        {
            HeroAnimationHandler heroAnimationHandler = new HeroAnimationHandler(Texture);
            heroAnimationHandler.animations = CreateHeroAnimations();
            heroAnimationHandler.Mouse = Game1.mouse;
            Input = new PlayerInput(Game1.keyBoard);
            Team = 1;
            Health = 20;
            MaxHealth = 20;
            weapon1 = new Weapon(this, heroAnimationHandler.Mouse);
            weapon2 = new RocketLauncher(this, heroAnimationHandler.Mouse);
            Weapon = weapon1;
            _AnimationHandler = heroAnimationHandler;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (((PlayerInput)Input).keyboard.KeyClicked(Keys.NumPad1))
            {
                if (!(Weapon is Weapon))
                    Weapon = weapon1;
            }
            else if (((PlayerInput)Input).keyboard.KeyClicked(Keys.NumPad2))
            {
                if (!(Weapon is RocketLauncher))
                    Weapon = weapon2;
            }
        }
    }
}
