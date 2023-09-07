using System;

namespace Helper
{
    public static class Utility
    {
        public static float RandomFloatInRange(Random random, float min, float max)
        {
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }
    }
}
