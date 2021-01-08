using GameEngine1.Input;
using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.GameObjects
{
    class Soldier : Human
    {
        public override void Update(GameTime gameTime)
        {
            ((AIMouseInput)Weapon.Mouse).Update();
            base.Update(gameTime);
        }
    }
}
