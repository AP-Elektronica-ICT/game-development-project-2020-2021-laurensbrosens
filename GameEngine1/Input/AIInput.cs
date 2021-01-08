using GameEngine1.GameObjects;
using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Input
{
    public class AIInput : IInput
    {
        public Soldier Parent { get; set; }
        public Vector2 Inputs()
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
            if (Parent.Position.X < Parent.Target.Position.X - 30)
            {
                directionX++;
            }
            if (Parent.Position.X > Parent.Target.Position.X + 30)
            {
                directionX--;
            }
            if (Parent.Position.Y < Parent.Target.Position.Y - 110)
            {
                directionY--;
            }
            if (Parent.Position.Y > Parent.Target.Position.Y + 110)
            {
                directionY++;
            }
            return new Vector2(directionX, directionY);
        }
    }
}
