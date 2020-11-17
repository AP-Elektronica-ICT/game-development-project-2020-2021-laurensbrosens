using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Interfaces
{
    public interface IAnimationHandler
    {
        public void Update(GameTime gameTime, State state, MovementCommand physics, IAnimate animations, MouseInput mouse, ICollision hero);
        public void Draw(Texture2D texture2D, ITransform Hero, IAnimate animations, SpriteBatch spriteBatch);
    }
}
