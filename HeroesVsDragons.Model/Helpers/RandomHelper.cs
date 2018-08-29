using System;

namespace HeroesVsDragons.Model.Helpers
{
    public static class RandomHelper
    {
        /// <summary>
        /// Function to get random number
        /// </summary>
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
    }
}
