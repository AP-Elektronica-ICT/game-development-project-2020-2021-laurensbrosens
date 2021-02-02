using GameEngine1.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Factories
{
    class MovableEntityFactory
    {
        public MovableEntity CreateMovableEntity(string EntityType, Vector2 position, Texture2D texture = null, List<Entity> entities = null)
        {
            try
            {
                MovableEntity entity = (MovableEntity)Activator.CreateInstance(Type.GetType($"GameEngine1.GameObjects.{EntityType}"), new object[] { position, texture, entities });
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
