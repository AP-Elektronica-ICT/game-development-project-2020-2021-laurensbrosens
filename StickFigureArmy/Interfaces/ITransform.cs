using Microsoft.Xna.Framework;
using StickFigureArmy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Interfaces
{
    interface ITransform
    {
        public Vector2 Position { get; set; }
        public Vector2 PositionOld { get; set; }
    }
}
