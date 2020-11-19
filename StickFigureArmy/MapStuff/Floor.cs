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
    class Floor : IDraw, ITransform
    {
        public Texture2D texture2D { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public Vector2 Position { get; set; }
        public Floor(Rectangle view, Texture2D texture, Vector2 position)
        {
            texture2D = texture;
            SourceRectangle = view;
            Position = position;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, Position, SourceRectangle, Color.White);
        }
    }
}
