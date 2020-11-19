using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Utilities
{
    public class RandomNumberClass
    {
        static public Random rng { get; set; }
        public RandomNumberClass()
        {
            rng = new Random();
        }
        static public int GenerateRandomNumber(int min, int max)
        {
            return rng.Next(min, max+1);
        }
        static public int GenerateRandomWeightedNumber(int min, int max, int tendency) //Gives a random number that is more likely to be around a certain value
        {
            int number = 0;
            
            for (int i = 0; i < 20; i++)
            {
                number += rng.Next(min, (max + 1)/20);
            }
            return number;
        }
    }
}
