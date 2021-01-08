using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameEngine1.Art;
using GameEngine1.GameObjects;
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
        public override void Load()
        {
            base.Load();
            obstacles.Add(Factory.CreateGround(new Vector2(-1000, 2000)));
            List<Texture2D> buildingTextures = new List<Texture2D>();
            buildingTextures.Add(Textures.GreenBuilding);
            buildingTextures.Add(Textures.PinkBuilding);
            buildingTextures.Add(Textures.RoundBuilding);
            buildingTextures.Add(Textures.BlueBuilding);
            IEntity building;
            int height = 2;
            int randomTexture = 0; //Random index in buildingTextures
            int buildingSpacing = 0; //Minimum space between buildings
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
                building = Factory.CreateBuilding(position, buildingTextures[randomTexture], height);
                obstacles.Add(building);
                IEntity platform;
                for (int j = 0; j < height+1; j++)
                {
                    platform = Factory.CreatePlatform(new Vector2(position.X, position.Y - j * 100));
                    obstacles.Add(platform);
                }
                position.X += buildingSpacing;
            }
            hero = (Hero)Factory.CreateHero(new Vector2(150, 1800), obstacles);
            humans.Add(hero);
            Soldier soldier;
            Soldier soldier2;
            for (int i = 0; i < 100; i++)
            {
                soldier = (Soldier)Factory.CreateSoldier(new Vector2(i*14, 1800), obstacles, 1);
                soldier2 = (Soldier)Factory.CreateSoldier(new Vector2(6000+i*14, 1800), obstacles, 2);
                humans.Add(soldier);
                humans.Add(soldier2);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
