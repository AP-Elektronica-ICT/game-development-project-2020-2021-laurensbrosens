using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using StickFigureArmy.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Weapons
{
    class Bullet : ITransform, IDraw, ICollisionPoint, IDamageable
    {
        public BulletCollision CollisionHandler { get; set; }
        public ICollisionFix CollisionFix { get; set; }
        public ICollisionCheck CollisionCheck { get; set; }
        public Vector2 Position { get; set; }
        public IInput Direction { get; set; }
        public Texture2D texture2D { get; set; }
        public Point CollisionPoint { get; set; }
        public int HP { get; set; } = 1;
        private bool alive = true;
        public bool Alive {
            get
            {
                if (alive == false)
                {
                    return false;
                }
                if (HP <= 0)
                {
                    return false;
                }
                return true;
            }
            set
            {
                alive = value;
            }
        }

        private BulletMovement move;
        private Utilities.Cooldown lifeSpan;
        private List<ICollisionRectangle> collidableObjects;
        public Bullet(List<ICollisionRectangle> collisionRectangles, Vector2 spawnCoordinates, Texture2D texture, IInput direction)
        {
            texture2D = texture;
            Direction = direction;
            Position = spawnCoordinates;
            CollisionHandler = new BulletCollision();
            collidableObjects = collisionRectangles;
            move = new BulletMovement();
            lifeSpan = new Utilities.Cooldown();
            alive = true;
        }
        public void Update(GameTime gameTime)
        {
            move.Execute(gameTime, null, this, Direction); //Beweeg bullet
            CollisionHandler.CollisionHandler(this, move, this, collidableObjects); //Check op collisions
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, Position, null, Color.White, 2, new Vector2(0, 0), 2f, SpriteEffects.None, 0);
        }

        public void UpdateCollisionPoint()
        {
            CollisionPoint = new Point((int)Position.X,(int)Position.Y);
        }
    }
}
