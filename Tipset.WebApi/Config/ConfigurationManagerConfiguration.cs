using System.Collections.Specialized;
using System.Configuration;
using Tipset.Common;

namespace RavenDb.Config
{
    public class ConfigurationManagerConfiguration : IConfiguration
    {
        public NameValueCollection AppSettings
        {
            get { return ConfigurationManager.AppSettings; }
        }


        public int GetInt(string key)
        {
            var configValue = ConfigurationManager.AppSettings[key];
            Guard.IsNotNull(configValue, "No configuration value found for key: " + key);
            Guard.IsParsableInt(configValue, string.Format("The configuration value '{0}' for key '{1}' is not parsable to an int", key, configValue));
            return int.Parse(configValue);
        }
    }
}
