using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Animations
{
    class HeroAnimationHandler : IAnimationHandler
    {
        public int CurrentAnimation { get; set; }
        /*
        0 idleLeft
        1 idleRight
        2 RunLeft
        3 RunRight
        4 jumpLeft
        5 jumpRight
        */
        public void Update(GameTime gameTime, State state, MovementCommand physics, IAnimate animations, MouseInput mouse, ICollision hero)
        {
            //If state then animation enz.
            if (state.Grounded)
            {
                if (physics.VelocityX < 0.5f || physics.VelocityX > 0.5f)
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
            animations.animations[CurrentAnimation].Update(gameTime); //Update animaties
        }

        public void Draw(Texture2D texture2D, ITransform Hero, IAnimate animations, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, Hero.Position, animations.animations[CurrentAnimation].CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }
    }
}
