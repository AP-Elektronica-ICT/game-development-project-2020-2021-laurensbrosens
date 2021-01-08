using GameEngine1.Input;
using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Animations
{
    class HeroAnimationHandler : IAnimationHandler
    {
        public List<Animation> animations { get; set; }
        public MouseInput Mouse { get; set; }
        private int CurrentAnimation;
        private int OldAnimation;
        private Texture2D texture;
        public HeroAnimationHandler(Texture2D texture2D)
        {
            texture = texture2D;
        }
        public void Update(GameTime gameTime, IPhysicsHandler physics, ICollision hero, ITransform transform)
        {
            OldAnimation = CurrentAnimation;
            float animationSpeed = 5; //Reset snelheid
            //If state then animation enz.
            if (physics.OnGround)
            {
                int threshold = 30; //Ontdendering
                if (OldAnimation == 2 || OldAnimation == 3)
                {
                    threshold = 20;
                }
                if (physics.VelocityX < threshold && physics.VelocityX > -threshold)
                {
                    CurrentAnimation = Mouse.Position.X < hero.CollisionRectangle.Center.X ? 0 : 1;
                }
                else
                {
                    animationSpeed = Math.Abs(physics.VelocityX) / 20f;
                    CurrentAnimation = Mouse.Position.X < hero.CollisionRectangle.Center.X ? 2 : 3;
                }
            }
            else
            {
                CurrentAnimation = Mouse.Position.X < hero.CollisionRectangle.Center.X ? 4 : 5;
            }
            bool reset = false;
            if (CurrentAnimation != OldAnimation)
            {
                animations[CurrentAnimation].CurrentFrame = animations[CurrentAnimation].frames[0];
                reset = true;
            }
            animations[CurrentAnimation].FramesPerSecond = animationSpeed;
            animations[CurrentAnimation].Update(gameTime, reset); //Update animaties
        }
        public void Draw(SpriteBatch spriteBatch, ITransform hero)
        {
            spriteBatch.Draw(texture, hero.Position, animations[CurrentAnimation].CurrentFrame.SourceRectangle, Color.White, hero.Rotation, new Vector2(0, 0), hero.Scale, SpriteEffects.None, 0);
        }
    }
}