using GameEngine1.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Factories
{
    class EntityFactory
    {
        public Entity CreateEntity(string EntityType, Vector2 position, Texture2D texture = null, int extra = 0)
        {
            try
            {
                Entity entity = (Entity)Activator.CreateInstance(Type.GetType($"GameEngine1.GameObjects.{EntityType}"), new object[] { position, texture, extra });
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
