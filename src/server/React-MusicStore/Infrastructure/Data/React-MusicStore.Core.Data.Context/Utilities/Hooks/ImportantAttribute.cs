using System;

namespace ReactMusicStore.Core.Data.Context.Utilities.Hooks
{
    /// <summary>
    /// Indicates that a hook instance should run in any case, even if hooking has been turned off.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ImportantAttribute : Attribute
    {
    }
}
