using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.MapStuff
{
    class Map
    {
        public Building[] Buildings { get; set; } //1e en laatste Building zijn spawnplaatsen
        public int[] Spacing { get; set; } //Ruimte tussen gebouwen
        public Obstacle[] Platforms { get; set; } //Platform per verdieping
        public Obstacle Ground { get; set; } //Op Y = 2000
        public string Name { get; set; }
        public void Update()
        {

        }
        public void Draw()
        {

        }
    }
}
