using Microsoft.Xna.Framework;
using StickFigureArmy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Interfaces
{
    interface ICollisionRectangle
    {
        public Rectangle CollisionRectangle { get; set; }
    }
}
