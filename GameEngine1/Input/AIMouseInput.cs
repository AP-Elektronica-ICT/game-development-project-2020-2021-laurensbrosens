using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameEngine1.Art;
using GameEngine1.Collisions;
using GameEngine1.GameLogic;
using GameEngine1.GameObjects;
using GameEngine1.Interfaces;
using GameEngine1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine1.Input
{
    class AIMouseInput : IMouseInput
    {
        public Vector2 Position { get; set; }
        public Human Target { get; set; }
        public Entity Parent { get; set; }
        public void Update()
        {
            if (Target == null || Target.Health <= 0)
            {
                NewTarget();
            }
            Position = Target.Position;
        }
        public void NewTarget()
        {
            Human target = null;
            foreach (var human in ((Level)Game1.currentLevel).humans)
            {
                if (human.Team != ((Human)Parent).Team) //Zal exception gooien als gemikt wordt op target dat niet human is
                {
                    if (target == null || Vector2.Distance(human.Position, Parent.Position) < Vector2.Distance(target.Position, Parent.Position)) //Target is dichtste enemy
                    {
                        target = human;
                    }
                }
                Target = target;
            }
        }
        public bool LeftKeyClicked()
        {
            //throw new NotImplementedException();
            return false;
        }
        public bool RightKeyClicked()
        {
            throw new NotImplementedException();
        }
    }
}
