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
    public class Obstacle : ICollision, ITransform, IDraw
    {
        public int RectangleWidth { get; set; }
        public int RectangleHeight { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public Rectangle CollisionRectangleOld { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D texture2D { get; set; }
        public int RectangleOffsetX { get; set; }
        public int RectangleOffsetY { get; set; }
        public ICollisionFix CollisionFix { get; set; }
        public ICollisionCheck CollisionCheck { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public Point CollisionTop { get; set; }
        public Point CollisionBottom { get; set; }
        public Point CollisionLeft { get; set; }
        public Point CollisionRight { get; set; }

        public Obstacle(Vector2 spawnCoordinates, Texture2D texture, string collisionAlgo) //Constructor met standaard spawnpositie
        {
            CollisionFix = (ICollisionFix)Activator.CreateInstance(Type.GetType($"StickFigureArmy.Physics.{collisionAlgo}"), new Object[] { });
            CollisionCheck = (ICollisionCheck)Activator.CreateInstance(Type.GetType($"StickFigureArmy.Physics.{collisionAlgo}"), new Object[] { });
            Position = spawnCoordinates;
            RectangleWidth = 100;
            RectangleHeight = 300;
            UpdateRectangle();
            CollisionRectangleOld = CollisionRectangle;
            texture2D = texture;
        }
        public Obstacle(Vector2 spawnCoordinates, Texture2D texture, int width, int height, string collisionAlgo) //Constructor met standaard spawnpositie en variabele breedte en hoogte
        {
            CollisionFix = (ICollisionFix)Activator.CreateInstance(Type.GetType($"StickFigureArmy.Physics.{collisionAlgo}"), new Object[] { });
            CollisionCheck = (ICollisionCheck)Activator.CreateInstance(Type.GetType($"StickFigureArmy.Physics.{collisionAlgo}"), new Object[] { });
            Position = spawnCoordinates;
            RectangleWidth = width;
            RectangleHeight = height;
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

        public void UpdateCollisionPoints() //Obstacle heeft geen collisionPoints voor nu
        {
            throw new NotImplementedException();
        }
    }
}
