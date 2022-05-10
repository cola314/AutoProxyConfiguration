using ProxyAutoConfiguration;
using System.Net;
using System.Windows.Input;

class Program
{
    [STAThread]
    public static void Main()
    {
        var logger = new DomainLogger();
        var config = new Config();
        var proxyIpRetriever = new ProxyIpRetriever();
        var proxyHelper = new ProxyHelper();

        if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
        {
            logger.ResetProxy();
            proxyHelper.ResetProxy();
        }
        else
        {
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
        }

        // prevent exit
        Console.ReadKey();
    }
}
