using System.Security.Cryptography.X509Certificates;

namespace EagleEye.Models
{
    public class GamePlayModel
    {
        private int rCEScore;
        private int rCMScore;
        private int rCHScore;

        public int TotalScore { get; private set; }

        // Remember color Game model

        public int RCEScore
        {
            get => rCEScore;
            set
            {
                rCEScore = value;
                if (value <= 0) return;
                TotalScore += value;
                RCEGPlay++;
            }
        }
        public int RCEGPlay { get; private set; } = 0;
        
        public int RCMScore
        {
            get => rCMScore;
            set
            {
                rCMScore = value;
                if (value <= 0) return;
                TotalScore += value;
                RCMGPlay++;
            }
        }
        public int RCMGPlay { get; private set; } = 0;

        public int RCHScore
        {
            get => rCHScore;
            set
            {
                rCHScore = value;
                if (value <= 0) return;
                TotalScore += value;
                RCHGPlay++;
            }
        }
        public int RCHGPlay { get; private set; } = 0;

    }
}
