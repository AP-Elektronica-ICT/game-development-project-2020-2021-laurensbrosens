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
    public class MovementCommand : IGameCommand
    {
        public float groundResistance { get; set; } = 0.10f; //Weerstand op de grond, default 0.15f, 0.01f is goed voor ijs lol
        public float airResistance { get; set; } = 0.015f; //Weerstand in de lucht, default 0.015f
        public float inputAcceleration { get; set; } = 20f; //Acceleratie door input, default 100
        public float Gravity { get; set; } = 9.8f; //Acceleratie door zwaartekracht, default 9.8f
        public float jumpingSpeed { get; set; } = 4f; //Snelheid bij springen, default 8
        public float VelocityX { get; set; } = 0; //Snelheid horizontaal, default 0
        public float VelocityY { get; set; } = 0; //Snelheid verticaal, default 0

        public float horizontalInput = 0f; //De input van de speler horizontaal
        public float verticalInput = 0f; //De input van de speler verticaal
        public void Execute(GameTime gameTime, State state, ITransform transform, IInput input)
        {
            //Get inputs
            Vector2 movementInput = input.Inputs();
            horizontalInput = movementInput.X;
            verticalInput = movementInput.Y;

            //Verwijder inputs die niet kunnen in bepaalde state
            if (state.CollisionLeft && horizontalInput < 0) //Kan niet naar links als links botsing
            {
                horizontalInput = 0;
            }

            if (state.CollisionRight && horizontalInput > 0) //Kan niet naar rechts als rechts botsing
            {
                horizontalInput = 0;
            }

            if (state.BumpHead && verticalInput > 0) //Kan niet springen als je hoofd vast zit
            {
                verticalInput = 0;
            }

            if (verticalInput < 0) //Spring naar beneden
            {
                state.JumpDown = true;
            }
            else
            {
                state.JumpDown = false;
            }

            //Calculate physics
            float deltaT = (float)gameTime.ElapsedGameTime.TotalSeconds;
            VelocityX += inputAcceleration * horizontalInput - groundResistance * VelocityX; //Berekening van horizontale snelheid, snelheidx = acceleratie * input - grondweerstand * snelheidx

            if (verticalInput > 0) //Als op de grond staat en springt, of vliegen zonder && state.Grounded == true
            {
                VelocityY = -jumpingSpeed;
            }
            else if (state.Grounded != true)
            {
                VelocityY += VelocityY * deltaT + 50f * Gravity * deltaT * deltaT - airResistance * VelocityY; //Berekening van verticale snelheid met zwaartekracht
            }
            transform.Position += new Vector2(VelocityX * deltaT, VelocityY);
        }
    }
}
