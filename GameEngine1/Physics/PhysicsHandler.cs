using System;
using System.Collections.Generic;
using System.Text;
using GameEngine1.GameObjects;
using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;

namespace GameEngine1.Physics
{
    public class PhysicsHandler : IPhysicsHandler
    {
        public float groundResistance { get; set; } = 0.15f; //Weerstand op de grond, default 0.15f, 0.01f is goed voor ijs lol
        public float airResistance { get; set; } = 0.020f; //Weerstand in de lucht, default 0.015f
        public float inputAcceleration { get; set; } = 14f; //Acceleratie door input, default 100
        public float Gravity { get; set; } = 9.8f; //Acceleratie door zwaartekracht, default 9.8f
        public float jumpingSpeed { get; set; } = 5.5f; //Snelheid bij springen, default 8
        public float VelocityX { get; set; } = 0; //Snelheid horizontaal, default 0
        public float VelocityY { get; set; } = 0; //Snelheid verticaal, default 0
        public bool JumpingDown { get; set; }
        public bool Falling { get; set; }
        public bool OnGround { get; set; }
        public bool CollisionLeft { get; set; }
        public bool CollisionRight { get; set; }
        public bool CollisionTop { get; set; }
        public float horizontalInput = 0f;
        public float verticalInput = 0f;
        public virtual void Move(GameTime gameTime, ITransform transform, IInput input)
        {
            Vector2 movementInput = input.Inputs(gameTime);
            horizontalInput = movementInput.X;
            verticalInput = movementInput.Y;
            if (CollisionLeft && horizontalInput < 0) //Kan niet naar links als links botsing
            {
                horizontalInput = 0;
            }

            if (CollisionRight && horizontalInput > 0) //Kan niet naar rechts als rechts botsing
            {
                horizontalInput = 0;
            }
            if (verticalInput < 0) //Spring naar beneden
            {
                JumpingDown = true;
            }
            else
            {
                JumpingDown = false;
            }
            /*
            if (CollisionTop && verticalInput > 0) //Kan niet springen als je hoofd vast zit, uitgecomment want anders bibber wanneer bij vliegen en hoofd botst tegen iets
            {
                verticalInput = 0;
            }*/
            //Calculate physics
            float deltaT = (float)gameTime.ElapsedGameTime.TotalSeconds;
            VelocityX += inputAcceleration * horizontalInput - groundResistance * VelocityX; //Berekening van horizontale snelheid, snelheidx = acceleratie * input - grondweerstand * snelheidx

            if (verticalInput > 0 && OnGround == true) //Als op de grond staat en springt, of vliegen zonder && OnGround == true
            {
                VelocityY = -jumpingSpeed;
            }
            else if (OnGround != true)
            {
                VelocityY += VelocityY * deltaT + 50f * Gravity * deltaT * deltaT - airResistance * VelocityY; //Berekening van verticale snelheid met zwaartekracht
            }
            transform.Position += new Vector2(VelocityX * deltaT, VelocityY);
        }
    }
}
