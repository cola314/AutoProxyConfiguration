using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace ProxyAutoConfiguration;

/// <summary>
/// Helper to set proxy settings in the registry
/// https://stackoverflow.com/questions/197725/programmatically-set-browser-proxy-settings-in-c-sharp
/// </summary>
public class ProxyHelper
{
    [DllImport("wininet.dll")]
    private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
    private const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
    private const int INTERNET_OPTION_REFRESH = 37;

    private const string REGISTRY_KEY = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
    private const string PROXY_SERVER_KEY = "ProxyServer";
    private const string PROXY_ENABLE_KEY = "ProxyEnable";

    private static void SetProxySettingToRegistry(string? proxyhost, bool? proxyEnabled)
    {
        if (proxyhost != null)
            Registry.SetValue(REGISTRY_KEY, PROXY_SERVER_KEY, proxyhost);
        if (proxyEnabled != null)
            Registry.SetValue(REGISTRY_KEY, PROXY_ENABLE_KEY, proxyEnabled.Value ? 1 : 0);
    }

    public void SetProxy(string ip, int port)
    {
        SetProxySettingToRegistry($"{ip}:{port}", true);
    }

    public void ResetProxy()
    {
        SetProxySettingToRegistry(null, false);
    }
}
