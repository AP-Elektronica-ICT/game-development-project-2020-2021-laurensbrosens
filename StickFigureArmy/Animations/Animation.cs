using Microsoft.Xna.Framework;
using StickFigureArmy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Animations
{
    class Animation
    {
        public Frame CurrentFrame { get; set; }
        private List<Frame> frames;
        private Cooldown cooldown;
        private int FrameNumber = 0; //Huidige frame
        public Animation()
        {
            cooldown = new Cooldown();
            frames = new List<Frame>();
        }
        public void AddFrame(Frame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }
        public void Update(GameTime gameTime)
        {
            if (cooldown.CooldownTimerFPS(gameTime, 20))
            {
                FrameNumber++;
            }
            if (FrameNumber >= frames.Count)
            {
                FrameNumber = 0;
            }
            CurrentFrame = frames[FrameNumber];
        }
    }
}
