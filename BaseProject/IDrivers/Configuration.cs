using BaseProject.JsonReader;

namespace BaseProject.IDrivers
{
    public static class Configuration
    {
        public static string pageLoadWaitTime = JsonConfig.GetJsonValue("PageLoad");
        public static string elementLoadWaitTime = JsonConfig.GetJsonValue("ElementWaitTime");
        public static string remoteWebDriverWaitTime = JsonConfig.GetJsonValue("RemoteWebdriverWait");
        public static string hubIpAddress = JsonConfig.GetJsonValue("HubIpAddress"); 
        public static string BaseUrl = JsonConfig.GetJsonValue("BaseUrl");
    }
}
