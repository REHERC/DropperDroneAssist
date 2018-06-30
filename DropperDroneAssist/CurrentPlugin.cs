﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.API.Configuration;

namespace DropperDroneAssist
{
    public static class CurrentPlugin
    {
        public static void Initialize()
        {
            Config = new Settings("Config");
        }

        public static string TryGetValue(string Value,string Default = "")
        {
            string result = "";
            try
            {
                result = Config.GetItem<string>(Value);
            }
            catch (Exception VirusSpirit)
            {
                result = Default;
            }
            return result;
        }

        public static Settings Config;
    }
    
}
