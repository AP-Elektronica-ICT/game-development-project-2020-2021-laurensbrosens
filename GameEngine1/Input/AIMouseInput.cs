using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameEngine1.AILogic;
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
        public SoldierAI soldierAI { get; set; }
        public void Update()
        {
            if (soldierAI.Target == null) //|| soldierAI.Target.Health <= 0) check of target nog leeft, wss niet nodig
            {
                soldierAI.RandomTarget();
            }
            if (soldierAI.Target != null)
            {
                Position = soldierAI.Target.Position;
            }
        }
        public bool LeftKeyClicked()
        {
            if (soldierAI.Target != null)
            {
                if (Vector2.Distance(soldierAI.Soldier.Position, soldierAI.Target.Position) < 400)
                {
                    return true;
                }
            }
            return false;
        }
        public bool RightKeyClicked()
        {
            throw new NotImplementedException();
        }
    }
}
