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
        public Soldier Parent { get; set; }
        public void Update()
        {
            if (Parent.Target == null || Parent.Target.Health <= 0)
            {
                Parent.ClosestTarget();
            }
            Position = Parent.Target.Position;
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
