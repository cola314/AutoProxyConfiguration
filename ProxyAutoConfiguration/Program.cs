using ProxyAutoConfiguration;
using System.Net;

var logger = new DomainLogger();
var config = new Config();
var proxyIpRetriever = new ProxyIpRetriever();
var proxyHelper = new ProxyHelper();

try
{
    var ip = proxyIpRetriever.GetFirstGatewayIpv4IpAsProxyIpOrNull();
    if (ip == null)
    {
        logger.IpNotFound();
    }
    else
    {
        logger.SetProxyHost(ip, config.Port);
        proxyHelper.SetProxy(ip, config.Port);
        logger.ProxySettingFinished();
    }
}
catch (Exception ex)
{
    logger.ExceptionCaused(ex);
}

// prevent exit
Console.ReadLine();