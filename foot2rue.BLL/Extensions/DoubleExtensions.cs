namespace foot2rue.BLL.Extensions
{
    internal static class DoubleExtensions
    {
        private const double EPSILON = 1f;

        public static bool EpsilonEquals(this double a, double b)
        {
            return Math.Abs(a - b) < EPSILON;
        }

        public static bool SmallerThan(this double a, double b)
        {
            return b - a > EPSILON;
        }

        public static bool SmallerOrEqual(this double a, double b)
        {
            return a.SmallerThan(b) || a.EpsilonEquals(b);
        }

        public static bool GreaterThan(this double a, double b)
        {
            return a- b > EPSILON;
        }

        public static bool GreaterOrEqual(this double a, double b)
        {
            return a.GreaterThan(b) || a.EpsilonEquals(b);
        }
    }
}
