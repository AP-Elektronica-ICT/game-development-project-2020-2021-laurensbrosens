using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Interfaces
{
    public interface IHealth
    {
        public float Health { get; set; }
        public int MaxHealth { get; set; }
        public bool Hit { get; set; }
    }
}
