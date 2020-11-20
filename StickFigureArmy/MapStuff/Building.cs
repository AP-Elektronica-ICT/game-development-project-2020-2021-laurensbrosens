using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.MapStuff
{
    class Building
    {
        public int Height { get; set; }
        public List<Floor> Floors { get; set; }
        public Vector2 Position { get; set; }
        public Building(int height, Texture2D main, Texture2D top, Rectangle viewMain, Rectangle viewTop, Vector2 position)
        {
            Position = position;
            Height = height;
            Floors = new List<Floor>();
            position.Y -= viewMain.Height; //Anders is 1e floor onder de grond
            if (height <= 2)
            {
                Floors.Add(new Floor(viewMain, main, position));
            }
            else
            {
                for (int i = 0; i < height - 1; i++)
                {
                    Floors.Add(new Floor(viewMain, main, position));
                    position.Y -= viewMain.Height;
                }
                Floors.Add(new Floor(viewTop, top, position));
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var floor in Floors)
            {
                floor.Draw(spriteBatch);
            }
        }
    }
}
