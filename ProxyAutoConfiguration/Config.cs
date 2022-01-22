namespace ProxyAutoConfiguration;

public class Config
{
    private const string PORT_KEY = "proxy_port";

    // 8128 is default port of ProxyDroid 
    public int DefaultPort => 8128;

    public int Port 
        => int.TryParse(Environment.GetEnvironmentVariable(PORT_KEY), out int port) ? port : DefaultPort;
}
