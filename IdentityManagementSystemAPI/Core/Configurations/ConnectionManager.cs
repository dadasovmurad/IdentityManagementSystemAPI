public static class ConnectionManager
{
    static public string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();

            try
            {
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()));
                configurationManager.AddJsonFile("appsettings.json");
            }
            catch
            {
                configurationManager.AddJsonFile("appsettings.Production.json");
            }

            return configurationManager.GetConnectionString("PostgreSQL");
        }
    }
}