using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Interfaces
{
    public interface IPhysicsHandler
    {
        public float inputAcceleration { get; set; }
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public bool JumpingDown { get; set; } //Nodig bij platforms
        public bool Falling { get; set; }
        public bool OnGround { get; set; }
        public bool CollisionLeft { get; set; }
        public bool CollisionRight { get; set; }
        public bool CollisionTop { get; set; }
        public void Move(GameTime gameTime, ITransform transform, IInput input);
    }
}
