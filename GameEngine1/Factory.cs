using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameEngine1.AILogic;
using GameEngine1.Animations;
using GameEngine1.Art;
using GameEngine1.Collisions;
using GameEngine1.GameLogic;
using GameEngine1.GameObjects;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Physics;
using GameEngine1.Utilities;
using GameEngine1.View;
using GameEngine1.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine1
{
    public static class Factory
    {
        public static void CreateBullet(ITransform transform, int team, Vector2 direction)
        {
            Bullet bullet = new Bullet();
            List<ICollision> targets = new List<ICollision>(); //is nog leeg
            foreach (var human in ((Level)bullet.currentLevel).humans)
            {
                if (human.Team != team)
                {
                    targets.Add(human._collision);
                }
            }
            targets.Add(((Level)bullet.currentLevel).obstacles[0]._collision); //Voeg grond toe, hardcoded voor nu
            bullet.Texture = Textures.BulletTexture;
            BulletPhysicsHandler physicsHandler = new BulletPhysicsHandler();
            physicsHandler.inputAcceleration = 600; //Default 800
            Vector2 accuracyReduction = new Vector2(RandomNumberClass.GenerateRandomFloat(-0.12f,0.12f), RandomNumberClass.GenerateRandomFloat(-0.07f, 0.03f));
            direction = Vector2.Normalize(direction);
            direction += accuracyReduction;
            physicsHandler.Direction = Vector2.Normalize(direction);
            bullet._PhysicsHandler = physicsHandler;
            BulletCollision collision = new BulletCollision(transform.Position, targets);
            collision.RectangleWidth = 5;
            collision.RectangleHeight = 3;
            bullet._collision = collision;
            bullet._collision.Parent = bullet;
            bullet.Scale = 2.5f;
            bullet.Rotation = MathUtilities.VectorToAngle(direction);
            bullet.Position = new Vector2(transform.Position.X + 9, transform.Position.Y + 13);
            (bullet.currentLevel).bullets.Add(bullet);
        }
        public static void CreateExplosionBullet(ITransform transform, int team, Vector2 direction)
        {
            Bullet bullet = new Bullet();
            List<ICollision> targets = new List<ICollision>(); //is nog leeg
            foreach (var human in ((Level)bullet.currentLevel).humans)
            {
                if (human.Team != team)
                {
                    targets.Add(human._collision);
                }
            }
            targets.Add(((Level)bullet.currentLevel).obstacles[0]._collision); //Voeg grond toe, hardcoded voor nu
            bullet.Texture = Textures.ExplosionBulletTexture;
            BulletPhysicsHandler physicsHandler = new BulletPhysicsHandler();
            physicsHandler.inputAcceleration = 500; //Default 800
            Vector2 accuracyReduction = new Vector2(RandomNumberClass.GenerateRandomFloat(-0.12f, 0.12f), RandomNumberClass.GenerateRandomFloat(-0.07f, 0.03f));
            direction = Vector2.Normalize(direction);
            direction += accuracyReduction;
            physicsHandler.Direction = Vector2.Normalize(direction);
            bullet._PhysicsHandler = physicsHandler;
            ExplosionBulletCollision collision = new ExplosionBulletCollision(transform.Position, targets);
            collision.RectangleWidth = 5;
            collision.RectangleHeight = 3;
            //collision.RectangleOffsetX = 13;
            //collision.RectangleOffsetY = 14;
            bullet._collision = collision;
            bullet.Damage = 15;
            bullet._collision.Parent = bullet;
            bullet.Scale = 2.5f;
            bullet.Rotation = MathUtilities.VectorToAngle(direction);
            bullet.Position = new Vector2(transform.Position.X + 9, transform.Position.Y + 13);
            (bullet.currentLevel).bullets.Add(bullet);
        }
    }
}
