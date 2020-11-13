using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using StickFigureArmy.Characters;
using StickFigureArmy.Input;
using StickFigureArmy.View;
using StickFigureArmy.Interfaces;
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace StickFigureArmy.Physics
{
    class MovementCommand : IGameCommand
    {
        public float groundResistance { get; set; } = 0.15f; //Weerstand op de grond
        public float airResistance { get; set; } = 0.015f; //Weerstand in de lucht
        public float inputAcceleration { get; set; } = 160f; //Acceleratie door input
        public float Gravity { get; set; } = 9.8f; //Acceleratie door zwaartekracht
        public float jumpingSpeed { get; set; } = 3f; //Snelheid bij springen
        public float VelocityX { get; set; } = 0; //Snelheid horizontaal
        public float VelocityY { get; set; } = 0; //Snelheid verticaal

        public float horizontalInput = 0f; //De input van de speler horizontaal
        public float verticalInput = 0f; //De input van de speler verticaal
        public void Execute(GameTime gameTime, State state, ITransform transform, IInput input, ICollisionRectangle rectangle, List<ICollisionRectangle> rectangles)
        {
            //Save old collisionRectangle
            rectangle.UpdateRectangle();
            rectangle.CollisionRectangleOld = rectangle.CollisionRectangle;
            
            //Read inputs
            Vector2 movementInput = input.Inputs();
            horizontalInput = movementInput.X;
            verticalInput = movementInput.Y;

            //Verwijder inputs die niet kunnen in bepaalde state
            if (state.CollisionLeft && horizontalInput > 0)
            {
                horizontalInput = 0;
            }
            else if (state.CollisionRight && horizontalInput < 0)
            {
                horizontalInput = 0;
            }

            //Calculate physics
            float deltaT = (float)gameTime.ElapsedGameTime.TotalSeconds;
            VelocityX += inputAcceleration * horizontalInput - groundResistance * VelocityX; //Berekening van horizontale snelheid, snelheidx = acceleratie * input - grondweerstand * snelheidx
            
            if (verticalInput != 0) //Als op de grond staat en springt, of vliegen zonder && state.Grounded == true
            {
                VelocityY = -jumpingSpeed;
            }
            else
            {
                VelocityY += VelocityY * deltaT + 50f * Gravity * deltaT * deltaT - airResistance * VelocityY; //Berekening van verticale snelheid met zwaartekracht
            }
            Vector2 physicsDisplacment = new Vector2(VelocityX * deltaT, VelocityY);

            //Update collisionRectangle en positie
            transform.Position += physicsDisplacment;
            rectangle.UpdateRectangle();
            
            //Collisions
            Vector2 collisionDisplacment = new Vector2(0,0);
            foreach (var collisionObject in rectangles)
            {
                collisionDisplacment += Collision.CollisionHandler(rectangle, collisionObject);
            }
            //Update state
            state.Update(this, collisionDisplacment);
            
            //Compenseer afwijking door collisions
            transform.Position += Collision.AntiShivering(collisionDisplacment);
        }
    }
}
