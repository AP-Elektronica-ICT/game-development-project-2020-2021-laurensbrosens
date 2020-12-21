using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Input;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StickFigureArmy.Animations
{
    class GunAnimationHandler : IAnimationHandler
    {
        public float Angle { get; set; }
        public void Draw(Texture2D texture2D, ITransform Gun, IAnimate animations, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, Gun.Position, animations.animations[0].CurrentFrame.SourceRectangle, Color.White, Angle, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime, State state, MovementCommand physics, IAnimate animations, MouseInput mouse, ICollisionRectangle gun, ITransform position)
        {
            Vector2 lookingVector = new Vector2(position.Position.X);
            //Angle = 
        }
    }
}
