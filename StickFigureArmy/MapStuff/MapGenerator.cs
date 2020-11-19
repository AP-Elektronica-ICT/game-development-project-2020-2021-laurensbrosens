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
        public int BuildingMinDistance { get; set; } = 0; //Minimum distance between buildings, default 0
        public MapGenerator()
        {

            MapLength = RandomNumberClass.GenerateRandomNumber(2500, 3500);
            while (MapLength >= 0)
            {

            }

        }
        public Map GenerateMap(string name, int minBuildings, int maxBuildings, int maxMapLength , List<Texture2D> buildingTextures, int maxBuildingSize, int minBuildingSize = 1)
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
            map.Buildings = new Building[buildingsAmount];
            for (int i = 0; i < map.Buildings.Length; i++)
            {

                map.Buildings[i] = new Building();
            }




            return map;
        }
        

    }
}
