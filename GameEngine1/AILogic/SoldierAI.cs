using GameEngine1.GameLogic;
using GameEngine1.GameObjects;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.AILogic
{
    public class SoldierAI
    {
        public int Team { get; set; }
        public ITransform Target { get; set; }
        public IHealth TargetHealth { get; set; }
        public ITransform Soldier { get; set; }
        public IHealth SoldierHealth { get; set; }
        public Entity Location { get; set; } //Locatie om naar toe te gaan
        public bool Fleeing { get; set; } = true;
        public bool Hit { get; set; } = false;

        public void RandomTarget()
        {
            Target = null;
            foreach (var human in (Game1.currentLevel).humans)
            {
                if (human.Team != Team) //Zal exception gooien als gemikt wordt op target dat niet human is
                {
                    if (RandomNumberClass.GenerateRandomNumber(1, 100) <= 50)
                    {
                        Target = human;
                        TargetHealth = human;
                    }
                }
            }
        }

        public void ClosestTarget()
        {
            ITransform target = null;
            IHealth targetHealth = null;
            Target = null;
            TargetHealth = null;
            foreach (var human in (Game1.currentLevel).humans)
            {
                if (human.Team != Team) //Zal exception gooien als gemikt wordt op target dat niet human is
                {
                    if (target == null || Vector2.Distance(human.Position, Soldier.Position) < Vector2.Distance(target.Position, Soldier.Position)) //Target is dichtste enemy
                    {
                        target = human;
                        targetHealth = human;
                    }
                }
            }
            Target = target;
            TargetHealth = targetHealth;
            if (target == null)
            {
                Game1.gameOver = true;
            }
        }
        public void ClosestPlatform()
        {
            Entity target = null;
            foreach (var entity in (Game1.currentLevel).obstacles)
            {
                if (entity is Ground)
                    break;
                if (target == null || Vector2.Distance(entity.Position, Soldier.Position) < Vector2.Distance(target.Position, Soldier.Position)) //Target is dichtste platform
                {
                    target = entity;
                }
            }
            Location = target;
        }
        public void RandomPlatform()
        {
            int randomIndex = RandomNumberClass.GenerateRandomNumber(1, (Game1.currentLevel).obstacles.Count);
            Location = (Game1.currentLevel).obstacles[randomIndex];
        }
    }
}
