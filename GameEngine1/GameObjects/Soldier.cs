using GameEngine1.AILogic;
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
        public SoldierAI soldierAI { get; set; }
        public Soldier(int team) //Start met random target te kiezen
        {
            Team = team;
        }
        public override void Update(GameTime gameTime)
        {
            ((AIMouseInput)Weapon.Mouse).Update();
            base.Update(gameTime);
        }
        
    }
}
