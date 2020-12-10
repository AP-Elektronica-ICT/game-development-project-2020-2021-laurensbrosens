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
        public Point CollisionTop { get; set; }
        public Point CollisionBottom { get; set; }
        public Point CollisionLeft { get; set; }
        public Point CollisionRight { get; set; }
        public int RectangleOffsetX { get; set; }
        public int RectangleOffsetY { get; set; }
        public void UpdateRectangle();
        public void UpdateCollisionPoints();
        public ICollisionFix CollisionFix { get; set; }
        public ICollisionCheck CollisionCheck { get; set; }
    }
}
