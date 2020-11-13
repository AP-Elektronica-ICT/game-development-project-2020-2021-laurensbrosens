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

namespace StickFigureArmy.Physics
{
    class MovementCommand : IGameCommand
    {
        public float groundResistance { get; set; } = 0.15f; //Weerstand op de grond
        public float airResistance { get; set; } = 0.015f; //Weerstand in de lucht
        public float inputAcceleration { get; set; } = 100f; //Acceleratie door input
        public float Gravity { get; set; } = 9.8f; //Acceleratie door zwaartekracht
        public float jumpingSpeed { get; set; } = 8f; //Snelheid bij springen
        public float VelocityX { get; set; } = 0; //Snelheid horizontaal
        public float VelocityY { get; set; } = 0; //Snelheid verticaal

        public float horizontalInput = 0f; //De input van de speler horizontaal
        public float verticalInput = 0f; //De input van de speler verticaal
        public void Execute(GameTime gameTime, State state, ITransform transform, IInput input, ICollisionRectangle rectangle)
        {
            //Save old transform
            transform.PositionOld = transform.Position;
            //Read inputs
            Vector2 movementInput = input.Inputs();
            //Calculate physics
            float deltaT = (float)gameTime.ElapsedGameTime.TotalSeconds;
            horizontalInput = movementInput.X;
            verticalInput = movementInput.Y;
            //Check states
            VelocityX += inputAcceleration * horizontalInput - groundResistance * VelocityX; //Berekening van horizontale snelheid, snelheidx = acceleratie * input - grondweerstand * snelheidx
            VelocityY += VelocityY * deltaT + 50f * Gravity * deltaT * deltaT - airResistance * VelocityY; //Berekening van verticale snelheid met zwaartekracht
            Vector2 physicsDisplacment = new Vector2(VelocityX * deltaT, VelocityY);
            //Update collisionRectangle
            rectangle.CollisionRectangle = new Rectangle((int)Math.Round(transform.Position.X + physicsDisplacment.X), (int)Math.Round(transform.Position.Y + physicsDisplacment.Y), rectangle.RectangleWidth, rectangle.RectangleHeight);














            //Check collisions
            //Fix collisions
            Vector2 collisionDisplacment = new Vector2(0, 0);
            //Update state
            state.Update(this, collisionDisplacment);
            transform.Position += collisionDisplacment + physicsDisplacment;
        }
    }
}
