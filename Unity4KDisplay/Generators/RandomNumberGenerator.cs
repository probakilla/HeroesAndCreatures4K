using System;

namespace Unity4KDisplay.Generators {
    public class RandomNumberGenerator {
        public static readonly int MIN_STAT = 0;
        public static readonly int MIN_HEALTH = 20;
        public static readonly int MAX_STAT = 100;

        private static RandomNumberGenerator Insatnce = null;

        private RandomNumberGenerator() { }

        public static RandomNumberGenerator GetInstance {
            get {
                if (Insatnce == null) {
                    Insatnce = new RandomNumberGenerator();
                }
                return Insatnce;
            }
        }

        public double GetRandomDouble(double min, double max) {
            Random rand = new Random();
            double next = rand.NextDouble();
            return min + (next * (max - min));
        }

        public int GetRandomInt(int min, int max) {
            Random rand = new Random();
            return rand.Next(min, max);
        }
    }
}
