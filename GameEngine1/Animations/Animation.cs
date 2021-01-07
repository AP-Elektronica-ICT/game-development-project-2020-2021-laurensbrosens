using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameEngine1.Interfaces;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;

namespace GameEngine1.Animations
{
    public class Animation
    {
        public Frame CurrentFrame { get; set; }
        public List<Frame> frames;
        private Cooldown cooldown;
        public float FramesPerSecond { get; set; }
        public int FrameNumber = 0; //Huidige frame
        public string Name { get; set; }
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
        public void Update(GameTime gameTime, bool reset)
        {
            if (cooldown.CooldownTimerFPS(gameTime, FramesPerSecond, reset))
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
