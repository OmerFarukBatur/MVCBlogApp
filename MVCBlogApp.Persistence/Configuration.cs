using Microsoft.Extensions.Configuration;

namespace MVCBlogApp.Persistence
{
    static class Configuration
    {
        static public string ConfigurationString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");

                //return configurationManager.GetConnectionString("MSSQL");
                return configurationManager.GetConnectionString("SqlServer");
            }
        }
    }
}
