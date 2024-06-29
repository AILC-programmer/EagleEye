using EagleEye.Enums;

namespace EagleEye.Tools
{
    public class RandomGenerator
    {
        private static Random random = new Random();
        public static byte NumberOfShow(GameLevel gameLeve)
        {
            switch (gameLeve)
            {
                case GameLevel.Easy:
                    return Convert.ToByte(random.Next(4,7));
                case GameLevel.Medium:
                    return Convert.ToByte(random.Next(7, 11));
                case GameLevel.Hard:
                    return Convert.ToByte(random.Next(11, 16));
                default:
                    return 0;
            }
        }
    }
}
