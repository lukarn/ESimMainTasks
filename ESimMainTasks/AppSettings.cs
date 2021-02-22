using System;
using System.Collections.Generic;
using System.Text;

namespace ESimMainTasks
{
    public class AppSettings : IAppSettings
    {
        public string BasePageUrl { get; set; }
        public string TestUserName { get; set; }
    }
}
