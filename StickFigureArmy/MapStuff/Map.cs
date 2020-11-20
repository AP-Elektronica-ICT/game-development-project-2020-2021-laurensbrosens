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
    class Map
    {
        public Building[] Buildings { get; set; } //1e en laatste Building zijn spawnplaatsen
        public List<Obstacle> Platforms { get; set; } //Platform per verdieping
        public Obstacle Ground { get; set; } //Op Y = 2000
        public string Name { get; set; }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var building in Buildings)
            {
                building.Draw(spriteBatch);
            }
            //Ground.Draw(spriteBatch); //Ground heeft nog geen texture
        }
    }
}
