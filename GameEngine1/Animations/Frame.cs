using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameEngine1.Animations
{
    public class Frame
    {
        public Rectangle SourceRectangle { get; set; }
        public Frame(Rectangle view)
        {
            SourceRectangle = view;
        }
    }
}
