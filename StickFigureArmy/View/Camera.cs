using Microsoft.Xna.Framework;
using StickFigureArmy.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StickFigureArmy.View
{
    public class Camera
    {
        public Matrix Transform { get; set; }
        public void Update(ITransform transform)
        {
            Transform = Matrix.CreateTranslation(-transform.Position.X, -transform.Position.Y, 0);
            Transform *= Matrix.CreateTranslation(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2, 0);
        }

    }
}
