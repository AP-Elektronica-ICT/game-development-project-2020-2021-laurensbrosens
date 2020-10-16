using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.View
{
    class Camera
    {
        public Matrix Transform { get; set; }
        /*
        public void Update(Hero hero)
        {
            Transform = Matrix.CreateTranslation(-hero.Position.X - (hero.CollisionRectangle.Width / 2), -hero.Position.Y - (hero.CollisionRectangle.Height / 2), 0);
            Transform *= Matrix.CreateTranslation(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2, 0);
        }*/
        public void Update()
        {
            Transform = Matrix.CreateTranslation(20, 20, 0);
            Transform *= Matrix.CreateTranslation(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2, 0);
        }

    }
}
