﻿using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.GameObjects
{
    public class Building : Entity
    {
        public int Height;
        Rectangle sizeMain = new Rectangle(0, 0, 100, 100);
        Rectangle sizeTop = new Rectangle(0, 101, 100, 100);
        public Building(Vector2 position, Texture2D texture, int height = 2)
        {
            Texture = texture;
            Height = height;
            Position = position;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            float y;
            for (int i = 0; i < Height; i++)
            {
                y = Position.Y - i * 100 -100;
                spriteBatch.Draw(Texture, new Vector2(Position.X, y), sizeMain, Color.White);
            }
            y = Position.Y - (Height+1) * 100;
            spriteBatch.Draw(Texture, new Vector2(Position.X, y), sizeTop, Color.White);
        }
    }
}
