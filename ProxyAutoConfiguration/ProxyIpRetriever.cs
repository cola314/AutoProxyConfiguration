using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ProxyAutoConfiguration;

public class ProxyIpRetriever
{
    public string? GetProxyAddress(Config config)
    {
        var ip = GetFirstGatewayIpv4IpAsProxyIpOrNull();
        if (ip == null) return null;

        return config.UseSocks ? $"socks://{ip}" : ip;
    }

    private string? GetFirstGatewayIpv4IpAsProxyIpOrNull()
    {
        return NetworkInterface.GetAllNetworkInterfaces()
            .SelectMany(adapter => adapter.GetIPProperties().GatewayAddresses)
            .Where(address => address.Address.AddressFamily == AddressFamily.InterNetwork)
            .Select(address => address.Address.ToString())
            .FirstOrDefault();
    }
}
