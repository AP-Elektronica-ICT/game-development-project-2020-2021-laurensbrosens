using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Input
{
    public interface IMouseInput
    {
        public bool LeftKeyClicked();
        public bool RightKeyClicked();
        public Vector2 Position { get; set; }
    }
}
