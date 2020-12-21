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
    class BulletInput : IInput //Berekent hoek waarop bullet moet geschoten worden
    {
        private MouseInput mouse;
        private ITransform launchPosition;
        public BulletInput(MouseInput mouseInput, ITransform transform)
        {
            mouse = mouseInput;
            launchPosition = transform;
        }
        public Vector2 Inputs()
        {
            //berekening met mouseposition en launcposition
            return new Vector2(1,-1);
        }
    }
}
