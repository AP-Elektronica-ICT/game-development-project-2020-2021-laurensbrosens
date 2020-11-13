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
    class State
    {
        public bool Grounded { get; set; }
        public bool CollisionLeft { get; set; }
        public bool CollisionRight { get; set; }
        public bool BumpHead { get; set; } //CollisionTop
        public void Update(MovementCommand physics, Vector2 displacment)
        {
            if (displacment.X < 0)
            {
                CollisionLeft = true;
                physics.VelocityX = 0;
                //hero.displacment += new Vector2(1f, 0); //Tegen trilling
            }
            else
            {
                CollisionLeft = false;
            }
            if (displacment.X > 0)
            {
                CollisionRight = true;
                physics.VelocityX = 0;
                //hero.displacment += new Vector2(-1f, 0); //Tegen trilling
            }
            else
            {
                CollisionRight = false;
            }
            if (displacment.Y < 0) //Naar boven
            {
                physics.VelocityY = 0;
                Grounded = true;
                physics.Gravity = 0;
                //hero.displacment += new Vector2(0, 1f); //Tegen trilling
            }
            else
            {
                Grounded = false;
                physics.Gravity = 9.8f;
            }
            if (displacment.Y > 0)
            {
                physics.VelocityY = 0;
                BumpHead = true;
            }
            else
            {
                BumpHead = false;
            }
        }
    }
}
