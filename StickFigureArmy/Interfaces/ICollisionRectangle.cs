using Microsoft.Xna.Framework;
using StickFigureArmy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Interfaces
{
    public interface ICollisionRectangle
    {
        public int RectangleWidth { get; set; }
        public int RectangleHeight { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public Rectangle CollisionRectangleOld { get; set; }
        public int RectangleOffsetX { get; set; }
        public int RectangleOffsetY { get; set; }
        public void UpdateRectangle();
    }
}
