using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameEngine1.Animations
{
    class GunAnimationHandler : IAnimationHandler
    {
        public List<Animation> animations { get; set; }
        public MouseInput Mouse { get; set; }
        private int CurrentAnimation = 3;
        private int OldAnimation;
        public Texture2D Texture { get; set; }
        public void Update(GameTime gameTime, IPhysicsHandler physics, ICollision hero)
        {
            OldAnimation = CurrentAnimation;
            bool reset = false;
            if (CurrentAnimation == 0 || CurrentAnimation == 1)
            {
                if (animations[CurrentAnimation].FrameNumber >= animations[CurrentAnimation].frames.Count-1)
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

            if (((WeaponPhysicsHandler)physics).Shoot)
            {
                reset = true;
                CurrentAnimation = Mouse.Position.X < hero.CollisionRectangle.Center.X ? 0 : 1;
                animations[CurrentAnimation].FrameNumber = 0;
            }
            animations[CurrentAnimation].Update(gameTime, reset); //Update animaties
        }
        public void Draw(SpriteBatch spriteBatch, ITransform weapon)
        {
            Vector2 position = weapon.Position;
            position.X -= 33;
            position.Y -= 24;
            spriteBatch.Draw(Texture, position, animations[CurrentAnimation].CurrentFrame.SourceRectangle, Color.White, weapon.Rotation, new Vector2(0, 0), weapon.Scale, SpriteEffects.None, 0);
        }
    }
}
