using System.Reflection;

namespace ReactMusicStore.Core.IoC
{
    public static class ReferencedAssemblies
    {
        public static Assembly WebApi => Assembly.Load("React-MusicStore.WebApi");
        public static Assembly Framework => Assembly.Load("React-MusicStore.WebApi.Framework");
        public static Assembly Services => Assembly.Load("React-MusicStore.Services");
        public static Assembly Domain => Assembly.Load("React-MusicStore.Core.Domain");
        public static Assembly DataContext => Assembly.Load("React-MusicStore.Core.Data.Context");
        public static Assembly Repositories => Assembly.Load("React-MusicStore.Core.Data.Repository");

    }

}