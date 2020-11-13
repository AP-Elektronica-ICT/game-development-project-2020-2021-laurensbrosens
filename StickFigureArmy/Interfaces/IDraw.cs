using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Interfaces
{
    interface IDraw
    {
        public Texture2D texture2D { get; set; }
        public void Draw(SpriteBatch spriteBatch);
    }
}
