using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using StickFigureArmy.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.MapStuff
{
    class MapGenerator
    {
        public int MapLength { get; set; } //Buildings are 100px wide
        public Map GenerateMap(string name, int maxBuildingDistance, int minBuildings, int maxBuildings, int maxMapLength , List<Texture2D> buildingTextures, Rectangle buildingMain, Rectangle buildingTop, int maxBuildingSize, int minBuildingSize = 1)
        {
            Map map = new Map();
            map.Name = name;
            if (maxMapLength < 100)
            {
                maxMapLength = 100;
            }
            if (maxBuildings * 100 > maxMapLength)
            {
                maxBuildings = maxMapLength / 100;
                minBuildings = maxBuildings;
            }
            int buildingsAmount = RandomNumberClass.GenerateRandomNumber(minBuildings, maxBuildings);
            int buildingSpacing = 0;
            int height = 0;
            int randomTexture = 0;
            Vector2 position = new Vector2(200,2000); //Eerste 200 nodig voor spawnpositie, Y positie op 2000 zodat geen negatieve Y nodig
            map.Buildings = new Building[buildingsAmount];
            for (int i = 0; i < map.Buildings.Length; i++) //Creëer array met random buildings
            {
                height = RandomNumberClass.GenerateRandomNumber(minBuildingSize, maxBuildingSize);
                randomTexture = RandomNumberClass.GenerateRandomNumber(0, buildingTextures.Count-1);
                buildingSpacing = RandomNumberClass.GenerateRandomNumber(buildingMain.Width, maxBuildingDistance); //minimum is breedte van texture anders overlappingen
                //buildingSpacing = RandomNumberClass.GenerateRandomWeightedNumber(buildingMain.Width, maxBuildingDistance, buildingMain.Width); //Test
                position.X += buildingSpacing;
                Texture2D texture = buildingTextures[randomTexture];
                map.Buildings[i] = new Building(height, texture, texture, buildingMain, buildingTop, position);
                MapLength += buildingMain.Width + buildingSpacing;
            }
            map.Platforms = new List<Obstacle>();
            foreach (var building in map.Buildings) //Creëer array met one-way platforms per floor van een building
            {
                for (int i = 0; i < building.Height; i++)
                {
                    map.Platforms.Add(new Obstacle(new Vector2(building.Position.X, building.Position.Y - i * buildingMain.Height), null, 100, 20, "OneWayCollision")); //Invisible so no texture
                }
            }
            position.X += 200; //Plaats voor 2e spawnpositie
            map.Ground = new Obstacle(new Vector2(-2000, 2000), null, MapLength + 2000, 1000, "ObstacleCollision");//Creëer ground, invisible until texture made
            MapLength = (int)position.X;
            return map;
        }
    }
}
