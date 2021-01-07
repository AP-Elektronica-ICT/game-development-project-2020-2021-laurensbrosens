using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Interfaces
{
    public interface IPhysics : ITransform
    {
        public IPhysicsHandler _PhysicsHandler { get; set; }
    }
}
