﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameEngine1.Art;
using GameEngine1.Factories;
using GameEngine1.GameObjects;
using GameEngine1.Input;
using GameEngine1.Interfaces;
using GameEngine1.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine1.GameLogic
{
    public class LevelOne : Level
    {
        EntityFactory entityFactory;
        MovableEntityFactory movableEntityFactory;
        public override void Load()
        {
            base.Load();
            entityFactory = new EntityFactory();
            movableEntityFactory = new MovableEntityFactory();
            obstacles.Add(entityFactory.CreateEntity("Ground", new Vector2(-1000, 2000), Textures.GroundTexture));
            List<Texture2D> buildingTextures = new List<Texture2D>();
            buildingTextures.Add(Textures.GreenBuilding);
            buildingTextures.Add(Textures.PinkBuilding);
            buildingTextures.Add(Textures.RoundBuilding);
            buildingTextures.Add(Textures.BlueBuilding);
            Entity building;
            int height;
            int randomTexture; //Random index in buildingTextures
            int buildingSpacing; //Minimum space between buildings
            int maxBuildingSpacing = 400; //Minimum space between buildings
            int buildingAmount = 40;
            int minBuildingSize = 2;
            int maxBuildingSize = 7;
            int textureWidth = buildingTextures[0].Width;
            Vector2 position = new Vector2(200, 2000); //Positie eerste gebouw
            for (int i = 0; i < buildingAmount; i++) //Generating buildings and platforms
            {
                height = RandomNumberClass.GenerateRandomWeightedNumber2(minBuildingSize, maxBuildingSize, i, buildingAmount / 2);
                randomTexture = RandomNumberClass.GenerateRandomNumber(0, buildingTextures.Count - 1);
                buildingSpacing = RandomNumberClass.GenerateRandomWeightedNumber(textureWidth, maxBuildingSpacing, i, buildingAmount / 2);
                building = entityFactory.CreateEntity("Building", position, buildingTextures[randomTexture], height);
                obstacles.Add(building);
                Entity platform;
                for (int j = 0; j < height+1; j++)
                {
                    platform = entityFactory.CreateEntity("Platform", new Vector2(position.X, position.Y - j * 100));
                    obstacles.Add(platform);
                }
                position.X += buildingSpacing;
            }
            hero = (Hero)movableEntityFactory.CreateMovableEntity("Hero", new Vector2(-320, 1800), Textures.heroTexture, obstacles, 1);
            humans.Add(hero);
            Soldier soldier;
            Soldier soldier2;
            int randomSpacing;
            for (int i = 0; i < 25; i++)
            {
                randomSpacing = RandomNumberClass.GenerateRandomNumber(-10,40);
                soldier = (Soldier)movableEntityFactory.CreateMovableEntity("Soldier", new Vector2(i * randomSpacing - 300, 1800), Textures.heroTexture, obstacles, 1);
                humans.Add(soldier);
            }
            for (int i = 0; i < 20; i++)
            {
                randomSpacing = RandomNumberClass.GenerateRandomNumber(-10, 40);
                soldier2 = (Soldier)movableEntityFactory.CreateMovableEntity("Soldier", new Vector2(6000 + i * randomSpacing, 1800), Textures.heroTexture, obstacles, 2);
                humans.Add(soldier2);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
