using GameEngine1.GameLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Factories
{
    class LevelFactory
    {
        public Level CreateLevel(string EntityType)
        {
            try
            {
                Level level = (Level)Activator.CreateInstance(Type.GetType($"GameEngine1.GameLogic.{EntityType}"), new object[] { });
                return level;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
