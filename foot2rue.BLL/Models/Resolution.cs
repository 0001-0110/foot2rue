using foot2rue.BLL.Extensions;

namespace foot2rue.BLL.Models
{
    public class Resolution
    {
        public static readonly Resolution[] AllResolutions = new Resolution[] { new(800, 450), new(1280, 720), new(1920, 1080), };

        public readonly double Width;
        public readonly double Height;

        public static IEnumerable<Resolution> GetAvailableResolutions()
        {
            Resolution screenResolution = GetScreenResolution();
            return AllResolutions.Where(resolution => resolution <= screenResolution);
        }

        public static Resolution GetScreenResolution()
        {
            return new Resolution(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        public Resolution(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{Width} x {Height}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Resolution resolution)
                return Width == resolution.Width && Height == resolution.Height;

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Width.GetHashCode();
                hash = hash * 23 + Height.GetHashCode();
                return hash;
            }
        }

        #region Operators

        public static Resolution operator +(Resolution a, Resolution b)
        {
            return new Resolution(a.Width + b.Width, a.Height + b.Height);
        }

        public static Resolution operator -(Resolution a, Resolution b)
        {
            return new Resolution(a.Width - b.Width, a.Height - b.Height);
        }

        public static Resolution operator *(Resolution resolution, int scalar)
        {
            return new Resolution(resolution.Width * scalar, resolution.Height * scalar);
        }

        public static Resolution operator /(Resolution resolution, int divisor)
        {
            return new Resolution(resolution.Width / divisor, resolution.Height / divisor);
        }

        public static bool operator ==(Resolution a, Resolution b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (a is null || b is null)
                return false;

            return a.Width.EpsilonEquals(b.Width) && a.Height.EpsilonEquals(b.Height);
        }

        public static bool operator !=(Resolution a, Resolution b)
        {
            return !(a == b);
        }

        public static bool operator >(Resolution a, Resolution b)
        {
            return a.Width.GreaterThan(b.Width) && a.Height.GreaterThan(b.Height);
        }

        public static bool operator <(Resolution a, Resolution b)
        {
            return a.Width.SmallerThan(b.Width) && a.Height.SmallerThan(b.Height);
        }

        public static bool operator >=(Resolution a, Resolution b)
        {
            return a.Width.GreaterOrEqual(b.Width) && a.Height.GreaterOrEqual(b.Height);
        }

        public static bool operator <=(Resolution a, Resolution b)
        {
            return a.Width.SmallerOrEqual(b.Width) && a.Height.SmallerOrEqual(b.Height);
        }

        #endregion
    }
}
