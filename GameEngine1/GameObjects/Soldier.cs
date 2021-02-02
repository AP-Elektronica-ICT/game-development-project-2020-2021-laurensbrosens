using GameEngine1.AILogic;
using GameEngine1.Animations;
using GameEngine1.Art;
using GameEngine1.GameLogic;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Utilities;
using GameEngine1.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.GameObjects
{
    public class Soldier : Human
    {
        public SoldierAI soldierAI { get; set; }
        public Soldier(Vector2 spawnPosition, Texture2D texture, List<Entity> obstacles, int team) : base(spawnPosition, texture, obstacles, team)
        {
            soldierAI = new SoldierAI();
            AIMouseInput aiMouse = new AIMouseInput();
            HeroAnimationHandler animationHandler;
            soldierAI.Team = team;
            if (soldierAI.Team == 1)
            {
                animationHandler = new HeroAnimationHandler(Textures.heroTexture);
                animationHandler.animations = CreateHeroAnimations();
            }
            else
            {
                animationHandler = new HeroAnimationHandler(Textures.EnemyTexture);
                animationHandler.animations = CreateEnemyAnimations();
            }
            Scale = 1f;
            animationHandler.Mouse = aiMouse;
            _AnimationHandler = animationHandler;
            Health = 10;
            MaxHealth = 10;
            soldierAI.Soldier = this;
            soldierAI.SoldierHealth = this;
            ((AIInput)Input).soldierAI = soldierAI;
            ((AIMouseInput)animationHandler.Mouse).soldierAI = soldierAI;
            Weapon = new Weapon(this, aiMouse);
            Weapon.Mouse = animationHandler.Mouse;
            soldierAI.RandomPlatform();
        }
        public override void Update(GameTime gameTime)
        {
            ((AIMouseInput)Weapon.Mouse).Update();
            base.Update(gameTime);
        }
        
    }
}
