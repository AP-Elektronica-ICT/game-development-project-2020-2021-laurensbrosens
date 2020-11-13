using Microsoft.Xna.Framework;
using StickFigureArmy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Interfaces
{
    interface ICollisionRectangle
    {
        public int RectangleWidth { get; set; }
        public int RectangleHeight { get; set; }
        public Rectangle CollisionRectangle { get; set; }
    }
}
