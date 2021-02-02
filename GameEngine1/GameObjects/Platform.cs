using GameEngine1.Collisions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.GameObjects
{
    class Platform : Entity
    {
        public Platform(Vector2 position, Texture2D texture = null, int Width = 100)
        {
            OneWayCollision collision = new OneWayCollision
            {
                RectangleHeight = 20,
                RectangleWidth = 100
            };
            collision.UpdateRectangle(position);
            Position = position;
            _collision = collision;
        }
    }
}
