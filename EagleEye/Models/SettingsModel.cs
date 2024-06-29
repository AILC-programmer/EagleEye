using CommunityToolkit.Mvvm.ComponentModel;
using EagleEye.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEye.Models
{
    public class SettingsModel
    {
        public byte NumOfColorsSelectedIndex { get; set; } = 0;
        public GameLevel gameLevel { get; set; }
        public bool RedCheckBox { get; set; }
        public bool GreenCheckBox { get; set; }
        public bool BlueCheckBox { get; set; }
        public bool PinkCheckBox { get; set; }
        public bool WhiteCheckBox { get; set; }
        public bool GrayCheckBox { get; set; }
        public bool YellowCheckBox { get; set; }
        public bool BrownCheckBox { get; set; }
        public bool RandomColorCheckBox { get; set; }
    }
}
