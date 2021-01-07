using GameEngine1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.GameObjects
{
    abstract public class Bullet : MovableEntity, ITeam
    {
        public bool Team1 { get; set; }
        public bool Team2 { get; set; }
    }
}
