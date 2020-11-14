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
    public class State
    {
        public bool JumpDown { get; set; }
        public bool Falling { get; set; }
        public bool Grounded { get; set; }
        public bool CollisionLeft { get; set; }
        public bool CollisionRight { get; set; }
        public bool BumpHead { get; set; } //CollisionTop
        //public void Update
        /*
        public void Update(ICollision objectA, ICollision objectB, MovementCommand physics) 
        {
            if (Grounded)
            {

            }
            /*
            if (CollisionCheck.CheckPointCollision(objectA.CollisionLeft, objectB))
            {
                CollisionLeft = true;
                physics.VelocityX = 0;
            }
            else
            {
                CollisionLeft = false;
            }
            if (CollisionCheck.CheckPointCollision(objectA.CollisionRight, objectB))
            {
                CollisionRight = true;
                physics.VelocityX = 0;
            }
            else
            {
                CollisionRight = false;
            }
            if (CollisionCheck.CheckPointCollision(objectA.CollisionBottom, objectB)) //Naar boven
            {
                physics.VelocityY = 0;
                Grounded = true;
                physics.Gravity = 0;
            }
            else
            {
                Grounded = false;
                physics.Gravity = 9.8f;
            }
            if (CollisionCheck.CheckPointCollision(objectA.CollisionTop, objectB))
            {
                physics.VelocityY = 0;
                BumpHead = true;
            }
            else
            {
                BumpHead = false;
            }
            
        }
        */
    }
}
