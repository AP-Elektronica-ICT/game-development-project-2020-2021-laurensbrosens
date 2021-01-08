using System;
using System.Collections.Generic;
using System.Text;
using GameEngine1.GameObjects;
using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;

namespace GameEngine1.Physics
{
    class BulletPhysicsHandler : IPhysicsHandler
    {
        public float inputAcceleration { get; set; }
        public Vector2 Direction { get; set; }
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public bool JumpingDown { get; set; }
        public bool Falling { get; set; }
        public bool OnGround { get; set; }
        public bool CollisionLeft { get; set; }
        public bool CollisionRight { get; set; }
        public bool CollisionTop { get; set; }

        public void Move(GameTime gameTime, ITransform transform, IInput input)
        {
            float deltaT = (float)gameTime.ElapsedGameTime.TotalSeconds;
            transform.Position += Direction * deltaT * inputAcceleration;
        }
    }
}
