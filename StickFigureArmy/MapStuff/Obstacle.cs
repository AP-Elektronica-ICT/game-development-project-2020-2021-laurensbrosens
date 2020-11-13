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
    public class Obstacle : ICollisionRectangle, ITransform, IDraw
    {
        public int RectangleWidth { get; set; }
        public int RectangleHeight { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public Rectangle CollisionRectangleOld { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D texture2D { get; set; }
        public int RectangleOffsetX { get; set; }
        public int RectangleOffsetY { get; set; }
        public Obstacle(Vector2 spawnCoordinates, Texture2D texture) //Constructor met standaard spawnpositie
        {
            Position = spawnCoordinates;
            RectangleWidth = 100;
            RectangleHeight = 500;
            UpdateRectangle();
            CollisionRectangleOld = CollisionRectangle;
            texture2D = texture;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D,Position,Color.White);
        }
        public void UpdateRectangle()
        {
            CollisionRectangle = new Rectangle((int)Math.Round(Position.X), (int)Math.Round(Position.Y), RectangleWidth, RectangleHeight);
        }
    }
}
