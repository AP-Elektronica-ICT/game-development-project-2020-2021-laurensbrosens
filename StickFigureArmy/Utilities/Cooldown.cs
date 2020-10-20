using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Utilities
{
    class Cooldown
    {
        public double elapsedTime { get; set; } = 0;
        public bool CooldownTimer(GameTime gameTime, float seconds)
        {
            if (elapsedTime >= seconds)
            {
                elapsedTime = 0;
                return true;
            }
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            return false;
        }
        public bool CooldownTimerFPS(GameTime gameTime, float aantalFPS)
        {
            if (elapsedTime >= 1f / aantalFPS)
            {
                elapsedTime = 0;
                return true;
            }
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            return false;
        }
    }
}
