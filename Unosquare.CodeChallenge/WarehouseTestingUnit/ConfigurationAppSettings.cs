using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public  class ConfigurationAppSettings
    {
        public static Configuration Configuration() { 
            ConfigurationAppSettings settings = new ConfigurationAppSettings();
            return settings.getConfiguration();
        }

        public Configuration getConfiguration()
        {
            //cambia la ruta del app config para obtener el query string
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = "../../../App.config";
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            return configuration;
        }
    }
}
