namespace Lab5
{
    public class ConfigUpload
    {
        public static string? ClientId;
        public static string? ClientSecret;
        public static void LoadFromEnvironment()
        {
            ClientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID")
                       ?? throw new InvalidOperationException("Environment variable GOOGLE_CLIENT_ID is not set.");

            ClientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET")
                           ?? throw new InvalidOperationException("Environment variable GOOGLE_CLIENT_SECRET is not set.");
        }
    }
}
