using GameEngine1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.GameObjects
{
    public class Human : MovableEntity, IHealth, ITeam
    {
        public IInput Input { protected get; set; }
        public bool Team1 { get; set; }
        public bool Team2 { get; set; }
    }
}
