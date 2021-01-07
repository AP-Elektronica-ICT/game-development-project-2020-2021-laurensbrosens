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
        private int CurrentAnimation;
        private int OldAnimation;
        private Texture2D texture;
        public GunAnimationHandler(Texture2D texture2D)
        {
            texture = texture2D;
        }
        public void Update(GameTime gameTime, IPhysicsHandler physics, ICollision hero)
        {
            OldAnimation = CurrentAnimation;
            bool reset = false;
            if (CurrentAnimation != OldAnimation)
            {
                animations[CurrentAnimation].CurrentFrame = animations[CurrentAnimation].frames[0];
                reset = true;
            }
            if (((WeaponPhysicsHandler)physics).Shoot)
            {
                CurrentAnimation = 0; //Schieten nog aanpassen of links of rechts
                reset = true;
            }
            if (animations[CurrentAnimation].FrameNumber >= animations[CurrentAnimation].frames.Count)
            {
                CurrentAnimation = 3; //Idle nog aanpassen juiste animatie
            }
            animations[CurrentAnimation].Update(gameTime, reset); //Update animaties
        }
        public void Draw(SpriteBatch spriteBatch, ITransform weapon)
        {
            spriteBatch.Draw(texture, weapon.Position, animations[CurrentAnimation].CurrentFrame.SourceRectangle, Color.White, weapon.Rotation, new Vector2(0, 0), weapon.Scale, SpriteEffects.None, 0);
        }
    }
}
