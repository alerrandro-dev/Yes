namespace Yes.Shared.Settings;

public class JwtSettings
{
    public string Key { get; set; } = string.Empty;
    public int ExpiresInMinutes { get; set; }
}
