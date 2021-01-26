using GameEngine1.GameLogic;
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
        public ITransform Soldier { get; set; }
        public void RandomTarget()
        {
            foreach (var human in ((Level)Game1.currentLevel).humans)
            {
                if (human.Team != Team) //Zal exception gooien als gemikt wordt op target dat niet human is
                {
                    if (RandomNumberClass.GenerateRandomNumber(1, 100) <= 50) //Target is dichtste enemy
                    {
                        Target = human;
                    }
                }
            }
        }

        public void ClosestTarget()
        {
            ITransform target = null;
            foreach (var human in ((Level)Game1.currentLevel).humans)
            {
                if (human.Team != Team) //Zal exception gooien als gemikt wordt op target dat niet human is
                {
                    if (target == null || Vector2.Distance(human.Position, Soldier.Position) < Vector2.Distance(target.Position, Soldier.Position)) //Target is dichtste enemy
                    {
                        target = human;
                    }
                }
                Target = target;
            }
            if (target == null)
            {
                Game1.gameOver = true;
            }
        }
    }
}
