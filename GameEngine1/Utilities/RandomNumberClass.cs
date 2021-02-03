using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine1.Utilities
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
            return rng.Next(min, max + 1);
        }
        static public float GenerateRandomFloat(float min, float max)
        {
            return (float)rng.NextDouble() * (max - min) + min;
        }
        static public int GenerateRandomWeightedNumber(int min, int max, int location, int center) //Gives a random number that is more likely to be around a certain value
        {
            double x = location;
            double number = min;
            if (60 <= GenerateRandomNumber(0, 100))
            {
                double gaussianCalculation = -Math.Exp(-Math.Pow(x - center, 2) / (4 * Math.Pow(15, 2)));
                number += max * (gaussianCalculation + 1);
                if (number < min)
                {
                    number = GenerateRandomNumber(min, max);
                }
                if (number > max)
                {
                    number = GenerateRandomNumber(min, max);
                }
            }
            else
            {
                number = GenerateRandomNumber(min, max / 2 + min);
            }
            return (int)number;
        }
        static public int GenerateRandomWeightedNumber2(int min, int max, int location, int center) //Gives a random number that is more likely to be around a certain value
        {
            double x = location;
            double number = 0;
            if (30 <= GenerateRandomNumber(0, 100))
            {
                double gaussianCalculation = Math.Exp(-Math.Pow(x - center, 2) / (4 * Math.Pow(10, 2)));
                number += max * gaussianCalculation;
                if (40 <= GenerateRandomNumber(0, 100))
                {
                    number += GenerateRandomNumber(-max, max);
                }
                if (number < min)
                {
                    number = GenerateRandomNumber(min, max);
                }
                if (number > max)
                {
                    number = GenerateRandomNumber(min, max);
                }
            }
            else
            {
                number = GenerateRandomNumber(min, max / 2 + min);
            }
            return (int)number;
        }
    }
}
