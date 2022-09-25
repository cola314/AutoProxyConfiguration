using System.Windows.Input;

namespace ProxyAutoConfiguration;

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
                var address = proxyIpRetriever.GetProxyAddress(config);
                if (address == null)
                {
                    logger.IpNotFound();
                }
                else
                {
                    logger.SetProxyHost(address, config.Port);
                    proxyHelper.SetProxy(address, config.Port);
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