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
            /* Andere volg methode die beter kan klimmen, maar minder tof ;)
            if (Parent.Position.X < Parent.Target.Position.X - 40)
            {
                directionX++;
            }
            if (Parent.Position.X > Parent.Target.Position.X + 40)
            {
                directionX--;
            }
            if (Parent.Position.Y < Parent.Target.Position.Y - 110)
            {
                directionY--;
            }
            if (Parent.Position.Y > Parent.Target.Position.Y + 330)
            {
                if (Parent.Position.X < Parent.Target.Position.X)
                {
                    directionX++;
                }
                if (Parent.Position.X > Parent.Target.Position.X)
                {
                    directionX--;
                }
                directionY++;
            }
            else if (Parent.Position.Y > Parent.Target.Position.Y + 230)
            {
                if (Parent.Position.X < Parent.Target.Position.X + 4)
                {
                    directionX++;
                }
                if (Parent.Position.X > Parent.Target.Position.X - 4)
                {
                    directionX--;
                }
                directionY++;
            }
            else if (Parent.Position.Y > Parent.Target.Position.Y + 130)
            {
                directionY++;
            }*/
            if (soldierAI.Target != null)
            {
                if (soldierAI.Soldier.Position.X < soldierAI.Target.Position.X - 30)
                {
                    directionX++;
                }
                if (soldierAI.Soldier.Position.X > soldierAI.Target.Position.X + 30)
                {
                    directionX--;
                }
                if (soldierAI.Soldier.Position.Y < soldierAI.Target.Position.Y - 110)
                {
                    directionY--;
                }
                if (soldierAI.Soldier.Position.Y > soldierAI.Target.Position.Y + 130)
                {
                    directionY++;
                }
            }
            if (cooldown.CooldownTimer(gameTime, JumpChance) && soldierAI.TargetAlive.Health > 0)
            {
                directionY++;
            }
            return new Vector2(directionX, directionY);
        }
    }
}
