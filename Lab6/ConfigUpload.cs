namespace Lab6;

public class ConfigUpload
{
    public static string? ClientId;
    public static string? DbType;
    public static void Load(IConfiguration configuration)
    {
        ClientId = configuration.GetSection("google").GetSection("id").Get<string>();
        DbType = configuration.GetSection("DbType").Get<string>();
    }
}