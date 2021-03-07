namespace ESimMainTasks
{
    public class AppSettings : IAppSettings
    {
        public string BasePageUrl { get; set; }
        public string TestUserName { get; set; }
        public string TestUserPassword { get; set; }
        public string Browser { get; set; }
    }
}
