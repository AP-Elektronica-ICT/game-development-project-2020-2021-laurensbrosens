using GameEngine1.GameLogic;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.GameObjects
{
    public class Soldier : Human
    {
        public Human Target { get; set; }
        public Soldier() //Start met random target te kiezen
        {
            RandomTarget();
        }
        public override void Update(GameTime gameTime)
        {
            ((AIMouseInput)Weapon.Mouse).Update();
            base.Update(gameTime);
        }
        public void RandomTarget()
        {
            Human target = null;
            foreach (var human in ((Level)Game1.currentLevel).humans)
            {
                if (human.Team != Team) //Zal exception gooien als gemikt wordt op target dat niet human is
                {
                    if (RandomNumberClass.GenerateRandomNumber(1,100) <= 50) //Target is dichtste enemy
                    {
                        target = human;
                    }
                }
                Target = target;
            }
        }

        public void ClosestTarget()
        {
            Human target = null;
            foreach (var human in ((Level)Game1.currentLevel).humans)
            {
                if (human.Team != Team) //Zal exception gooien als gemikt wordt op target dat niet human is
                {
                    if (target == null || Vector2.Distance(human.Position, Position) < Vector2.Distance(target.Position, Position)) //Target is dichtste enemy
                    {
                        target = human;
                    }
                }
                Target = target;
            }
        }
    }
}
