using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Interfaces
{
    public interface IAnimated
    {
        public IAnimationHandler _AnimationHandler { get; set; }
    }
}
