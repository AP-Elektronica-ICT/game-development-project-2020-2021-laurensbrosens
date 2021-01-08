using GameEngine1.Input;
using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameEngine1.Physics
{
    class WeaponPhysicsHandler : PhysicsHandler
    {
        public bool Shoot { get; set; } = false;
        public MouseInput Mouse { get; set; }
        public override void Move(GameTime gameTime, ITransform transform, IInput input)
        {
            if (Mouse.LeftKeyClicked())
            {
                Debug.Write("   asdfsaf    ");
                Shoot = true;
            }
            else
            {
                Shoot = false;
            }
        }
    }
}
