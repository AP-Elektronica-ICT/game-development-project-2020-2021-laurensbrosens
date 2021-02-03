using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Physics;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameEngine1.Animations
{
    class AnimationHandler : IAnimationHandler
    {
        public List<Animation> animations { get; set; }
        public ITransform ParentTransform { get; set; } //Nodig om parent te volgen
        public IMouseInput Mouse { get; set; }
        private int CurrentAnimation = 3;
        private int OldAnimation;
        public Texture2D Texture { get; set; }
        public bool Shoot { get; set; } = false;
        public void Update(GameTime gameTime, IPhysicsHandler physics, ICollision hero, ITransform transform)
        {
            OldAnimation = CurrentAnimation;
            bool reset = false;
            if (CurrentAnimation == 0 || CurrentAnimation == 1)
            {
                if (animations[CurrentAnimation].FrameNumber >= animations[CurrentAnimation].frames.Count - 1)
                {
                    CurrentAnimation = Mouse.Position.X < hero.CollisionRectangle.Center.X ? 2 : 3;
                }
                else
                {
                    CurrentAnimation = Mouse.Position.X < hero.CollisionRectangle.Center.X ? 0 : 1;
                }
            }
            else
            {
                CurrentAnimation = Mouse.Position.X < hero.CollisionRectangle.Center.X ? 2 : 3;
            }

            if (Shoot)
            {
                reset = true;
                Shoot = false;
                CurrentAnimation = Mouse.Position.X < hero.CollisionRectangle.Center.X ? 0 : 1;
                animations[CurrentAnimation].FrameNumber = 0;
            }
            animations[CurrentAnimation].Update(gameTime, reset); //Update animaties
            Vector2 direction = Mouse.Position - new Vector2(hero.CollisionRectangle.X, hero.CollisionRectangle.Y);
            transform.Rotation = MathUtilities.VectorToAngle(direction);
            if (Mouse.Position.X < hero.CollisionRectangle.Center.X)
            {
                transform.Rotation += (float)Math.PI;
            }
        }
        public void Draw(SpriteBatch spriteBatch, ITransform weapon)
        {
            Vector2 position = ParentTransform.Position;
            position.X += 9;
            position.Y += 13;
            spriteBatch.Draw(Texture, position, animations[CurrentAnimation].CurrentFrame.SourceRectangle, Color.White, weapon.Rotation, new Vector2(40, 40), weapon.Scale, SpriteEffects.None, 0);
        }
    }
}
