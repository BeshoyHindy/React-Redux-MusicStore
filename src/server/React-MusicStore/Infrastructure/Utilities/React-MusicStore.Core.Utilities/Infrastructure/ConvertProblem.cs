using System;
using System.Reflection;
using ReactMusicStore.Core.Utilities.Extensions;

namespace ReactMusicStore.Core.Utilities.Infrastructure
{
    [Serializable]
    public class ConvertProblem
    {
        public object Item { get; set; }
        public PropertyInfo Property { get; set; }
        public object AttemptedValue { get; set; }
        public Exception Exception { get; set; }

        public override string ToString()
        {
            return
                @"Item type:     {0}
                Property:        {1}
                Property Type:   {2}
                Attempted Value: {3}
                Exception:
                {4}."
                    .FormatCurrent(
                        ((Item != null) ? Item.GetType().FullName : "(null)"),
                        Property.Name,
                        Property.PropertyType,
                        AttemptedValue,
                        Exception);
        }
    }
}