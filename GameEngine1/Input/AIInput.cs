using GameEngine1.AILogic;
using GameEngine1.GameObjects;
using GameEngine1.Interfaces;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Input
{
    public class AIInput : IInput
    {
        public SoldierAI soldierAI { get; set; }
        public int JumpChance { get; set; }
        private Cooldown cooldown { get; set; }
        public AIInput()
        {
            cooldown = new Cooldown();
            JumpChance = RandomNumberClass.GenerateRandomNumber(1, 10);
        }
        public Vector2 Inputs(GameTime gameTime)
        {
            int directionX = 0;
            int directionY = 0;
            Vector2 soldier = soldierAI.Soldier.Position;
            if (soldierAI.SoldierHealth.Hit)
            {
                soldierAI.SoldierHealth.Hit = false;
                if (RandomNumberClass.GenerateRandomNumber(1,100)<=10) //10% kans dat soldier vlucht als hij geraakt wordt
                {
                    soldierAI.Fleeing = true;
                    soldierAI.RandomPlatform();
                }
            }

            if (soldierAI.Fleeing)
            {
                Vector2 location = soldierAI.Location.Position;
                if (soldier.X > location.X && soldier.X <= location.X + 99 && soldier.Y <= location.Y + 10) //Als je op destinatie staat
                {
                    soldierAI.ClosestTarget();
                    soldierAI.Location = null;
                    soldierAI.Fleeing = false;
                }
                if (location != null)
                {
                    if (soldier.X < location.X + 45)
                    {
                        directionX++;
                    }
                    if (soldier.X > location.X + 55)
                    {
                        directionX--;
                    }
                    if (soldier.Y < location.Y)
                    {
                        directionY--;
                    }
                    if (soldier.Y > location.Y && soldier.X > location.X - 200 || soldier.X < location.X + 200)
                    {
                        directionY++;
                    }
                }
            }
            else
            {
                if (soldierAI.Target != null)
                {
                    Vector2 target = soldierAI.Target.Position;
                    if (soldier.X < target.X - 30)
                    {
                        directionX++;
                    }
                    if (soldier.X > target.X + 30)
                    {
                        directionX--;
                    }
                    if (soldier.Y < target.Y - 110)
                    {
                        directionY--;
                    }
                    if (soldier.Y > target.Y + 130)
                    {
                        directionY++;
                    }
                }
                if (cooldown.CooldownTimer(gameTime, JumpChance) && soldierAI.TargetHealth.Health > 0)
                {
                    directionY++;
                }
            }
            return new Vector2(directionX, directionY);
        }
    }
}
