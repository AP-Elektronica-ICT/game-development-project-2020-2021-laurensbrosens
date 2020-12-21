using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StickFigureArmy.Animations
{
    class HeroAnimationHandler : IAnimationHandler
    {
        public int CurrentAnimation { get; set; }
        public int OldAnimation { get; set; }
        /*
        0 idleLeft
        1 idleRight
        2 RunLeft
        3 RunRight
        4 jumpLeft
        5 jumpRight
        */
        public void Update(GameTime gameTime, State state, MovementCommand physics, IAnimate animations, MouseInput mouse, ICollisionRectangle hero, ITransform notNeeded)
        {
            OldAnimation = CurrentAnimation;
            float animationSpeed = 5;
            //If state then animation enz.
            if (state.Grounded && physics.VelocityY == 0)
            {
                int threshold = 30; //Ontdendering
                if (OldAnimation == 2 || OldAnimation == 3)
                {
                    threshold = 20;
                }
                if (physics.VelocityX < threshold && physics.VelocityX > -threshold)
                {
                    if (mouse.Position.X < hero.CollisionRectangle.Center.X)
                    {
                        CurrentAnimation = 0;
                    }
                    else
                    {
                        CurrentAnimation = 1;
                    }
                }
                else
                {
                    animationSpeed = System.Math.Abs(physics.VelocityX) / 20f;
                    if (mouse.Position.X < hero.CollisionRectangle.Center.X)
                    {
                        CurrentAnimation = 2;
                    }
                    else
                    {
                        CurrentAnimation = 3;
                    }
                }
            }
            else
            {
                if (mouse.Position.X < hero.CollisionRectangle.Center.X)
                {
                    CurrentAnimation = 4;
                }
                else
                {
                    CurrentAnimation = 5;
                }
            }
            bool reset = false;
            if (CurrentAnimation != OldAnimation)
            {
                animations.animations[CurrentAnimation].CurrentFrame = animations.animations[CurrentAnimation].frames[0];
                reset = true;
            }
            animations.animations[CurrentAnimation].Update(gameTime, animationSpeed, reset); //Update animaties
        }

        public void Draw(Texture2D texture2D, ITransform Hero, IAnimate animations, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, Hero.Position, animations.animations[CurrentAnimation].CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }
    }
}
