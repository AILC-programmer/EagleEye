using EagleEye.Models.Enums;

namespace EagleEye.Tools
{
    public class RandomGenerator
    {
        object entryTask = new object();

        private static Random random = new Random();
        public static int NumberOfShow(GameLevel gameLeve)
        {
            switch (gameLeve)
            {
                case GameLevel.ColorExplorer:
                    return random.Next(4, 6);
                case GameLevel.ShadeSeeker:
                    return random.Next(6, 9);
                case GameLevel.HueHunter:
                    return random.Next(9, 13);
                case GameLevel.TintTracker:
                    return random.Next(13, 16);
                case GameLevel.ChromaticMaster:
                    return random.Next(14, 19);
                default:
                    return 0;
            }
        }

        /*    public static List<Brush> RandomColor(byte count, SettingsModel settingsModel)
            {
                byte counter = 0;
                int colorsNumber;
                List<Brush> colors = new List<Brush>();
                GameColor gameColors = new GameColor();

                while(counter < count)
                {
                    colorsNumber = random.Next(1, 9);

                    switch (colorsNumber)
                    {
                        case 1:
                            {
                                if (settingsModel.RandomColorCheckBox || settingsModel.RedCheckBox)
                                {
                                    colors.Add(gameColors.Red);
                                    counter++;
                                }
                            }
                            break;
                        case 2:
                            {
                                if (settingsModel.RandomColorCheckBox || settingsModel.BlueCheckBox)
                                {
                                    colors.Add(gameColors.Blue);
                                    counter++;
                                }
                            }
                            break;
                        case 3:
                            {
                                if (settingsModel.RandomColorCheckBox || settingsModel.GreenCheckBox)
                                {
                                    colors.Add(gameColors.Green);
                                    counter++;
                                }
                            }
                            break;
                        case 4:
                            {
                                if (settingsModel.RandomColorCheckBox || settingsModel.YellowCheckBox)
                                {
                                    colors.Add(gameColors.Yellow);
                                    counter++;
                                }
                            }
                            break;
                        case 5:
                            {
                                if (settingsModel.RandomColorCheckBox || settingsModel.PinkCheckBox)
                                {
                                    colors.Add(gameColors.Pink);
                                    counter++;
                                }
                            }
                            break;
                        case 6:
                            {
                                if (settingsModel.RandomColorCheckBox || settingsModel.BrownCheckBox)
                                {
                                    colors.Add(gameColors.Brown);
                                    counter++;
                                }
                            }
                            break;
                        case 7:
                            {
                                if (settingsModel.RandomColorCheckBox || settingsModel.WhiteCheckBox)
                                {
                                    colors.Add(gameColors.White);
                                    counter++;
                                }
                            }
                            break;
                        case 8:
                            {
                                if (settingsModel.RandomColorCheckBox || settingsModel.GrayCheckBox)
                                {
                                    colors.Add(gameColors.Gray);
                                    counter++;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }

                return colors;
            }
        */
    }
}
