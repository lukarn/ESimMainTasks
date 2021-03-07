namespace ESimMainTasks
{
    public interface IAppSettings
    {
        string BasePageUrl { get; set; }

        string TestUserName { get; set; }

        string TestUserPassword { get; set; }

        string Browser { get; set; }

    }
}