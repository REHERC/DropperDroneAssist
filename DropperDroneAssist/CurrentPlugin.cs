using System;
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
            catch (Exception)
            {
                result = Default;
            }
            return result;
        }

        public static Settings Config;
    }
}
