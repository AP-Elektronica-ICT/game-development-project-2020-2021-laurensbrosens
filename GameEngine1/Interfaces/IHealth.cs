using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Interfaces
{
    public interface IHealth
    {
        public int Health { get; set; }
        public bool Hit { get; set; }
    }
}
