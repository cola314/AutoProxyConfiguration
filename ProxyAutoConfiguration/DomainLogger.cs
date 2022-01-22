namespace ProxyAutoConfiguration;

public class DomainLogger
{
    private void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public void IpNotFound()
    {
        WriteLine("게이트웨이 아이피가 존재하지 않습니다");
    }

    public void SetProxyHost(string ip, int port)
    {
        WriteLine("프록시 호스트를 설정합니다");
        WriteLine($"ip: {ip}");
        WriteLine($"port: {port}\n");
    }

    public void ProxySettingFinished()
    {
        WriteLine("설정이 완료됬습니다");
    }

    public void ExceptionCaused(Exception ex)
    {
        WriteLine(ex.ToString());
    }
}
