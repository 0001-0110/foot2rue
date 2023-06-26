namespace foot2rue.BLL.Models
{
    public class Resolution
    {
        public static readonly Resolution[] AllResolutions = new Resolution[] { new(800, 450) };

        public readonly int Width;
        public readonly int Height;

        public static IEnumerable<Resolution> GetAvailableResolutions()
        {
            return AllResolutions.Where(resolution => resolution.IsAvailable());
        }

        public Resolution(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Check if this resolution is smaller or equal than the current screen resolution
        /// </summary>
        /// <param name="screenResolution"></param>
        /// <returns></returns>
        public bool IsAvailable()
        {
            return Width <= Screen.PrimaryScreen.Bounds.Width && Height <= Screen.PrimaryScreen.Bounds.Height;
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
    }
}
