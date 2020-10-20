using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Animations
{
    class Frame
    {
        public Rectangle SourceRectangle { get; set; }
        public Frame(Rectangle view)
        {
            SourceRectangle = view;
        }
    }
}
