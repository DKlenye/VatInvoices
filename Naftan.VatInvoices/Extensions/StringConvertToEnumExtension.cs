using System;

namespace Naftan.VatInvoices.Extensions
{
    public static class StringConvertToEnumExtension
    {
        public static T ConvertToEnum<T>(this string value) where T : new()
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException("T must be an Enum");
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch
            {
                throw new NotSupportedException(String.Format("value {0} is not found",value));
            }
        }
    }
}

