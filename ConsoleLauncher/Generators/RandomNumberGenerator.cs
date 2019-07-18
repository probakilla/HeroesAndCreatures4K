using System;

namespace ConsoleLauncher.Generators {
    public class RandomNumberGenerator {
        private readonly Random Rand = new Random();

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
            double next = Rand.NextDouble();
            return min + (next * (max - min));
        }

        public float GetRandomFloat(float min, float max) {
            double next = GetRandomDouble(min, max);
            return (float)next;
        }

        public int GetRandomInt(int min, int max) {
            return Rand.Next(min, max);
        }
    }
}
