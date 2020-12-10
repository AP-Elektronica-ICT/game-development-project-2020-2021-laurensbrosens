using Microsoft.Xna.Framework;
using StickFigureArmy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Interfaces
{
    public interface ICollisionPoint
    {
        public void UpdateCollisionPoint();
        public ICollisionFix CollisionFix { get; set; }
        public ICollisionCheck CollisionCheck { get; set; }
        public Point CollisionPoint { get; set; }
    }
}
