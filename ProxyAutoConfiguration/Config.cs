namespace ProxyAutoConfiguration;

public class Config
{
    private const string PORT_KEY = "proxy_port";

    private const string USE_SOCKS = "use_socks";

    // 8128 is default port of Android Proxy Server App 
    public int DefaultPort => 8128;

    public int Port 
        => int.TryParse(Environment.GetEnvironmentVariable(PORT_KEY), out int port) ? port : DefaultPort;

    public bool UseSocks
        => int.TryParse(Environment.GetEnvironmentVariable(USE_SOCKS), out int use) && use == 1;
}
