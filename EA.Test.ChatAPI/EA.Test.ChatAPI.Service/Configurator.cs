using System.Configuration;
using EA.Challenge.ChatAPI.Contracts;

namespace EA.Challenge.ChatAPI.Service
{
    public class Configurator : IConfigurator
    {
        public string ReadFromConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
