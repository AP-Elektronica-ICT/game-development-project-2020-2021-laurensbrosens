using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using StickFigureArmy.Characters;
using StickFigureArmy.Input;
using StickFigureArmy.View;
using System;
using System.Xml.Serialization;
using StickFigureArmy.Interfaces;

namespace StickFigureArmy.Physics
{
    class BulletInput : IInput
    {
        private Vector2 direction;
        public BulletInput(Vector2 angle)
        {
            direction = angle;
        }
        public Vector2 Inputs()
        {
            return direction;
        }
    }
}
