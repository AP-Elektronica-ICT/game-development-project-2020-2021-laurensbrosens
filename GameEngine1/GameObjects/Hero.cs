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

namespace GameEngine1.GameObjects
{
    public sealed class Hero : Human
    {
        
        public Hero(Vector2 spawnPosition, Texture2D texture, List<Entity> obstacles, int team) : base(spawnPosition, texture, obstacles, team)
        {
            HeroAnimationHandler heroAnimationHandler = new HeroAnimationHandler(Texture);
            heroAnimationHandler.animations = CreateHeroAnimations();
            heroAnimationHandler.Mouse = Game1.mouse;
            Input = new PlayerInput(Game1.keyBoard);
            Team = 1;
            Health = 20;
            MaxHealth = 20;
            Weapon = new Weapon(this, heroAnimationHandler.Mouse);
            _AnimationHandler = heroAnimationHandler;
        }
    }
}
