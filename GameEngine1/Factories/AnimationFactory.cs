using GameEngine1.Animations;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Factories
{
    class AnimationFactory
    {
        public Animation CreateAnimation(int x, int y, int width, int height, int frameAmount, string name, float fps) //Creëert een animatie op dezelfde rij
        {
            Animation animation = new Animation();
            animation.FramesPerSecond = fps;
            animation.Name = name;
            for (int i = 0; i < frameAmount; i++)
            {
                animation.AddFrame(new Frame(new Rectangle(x, y, width, height)));
                x += width;
            }
            return animation;
        }
    }
}
