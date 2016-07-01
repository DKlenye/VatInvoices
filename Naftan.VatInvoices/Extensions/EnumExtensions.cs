using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Naftan.VatInvoices.Extensions
{
   public static class EnumExtensions
    {

        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        public static string ToDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static IEnumerable<string> ToDescriptions(this Type type)
        {
            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return type.GetEnumNames().Select(value => Enum.Parse(type, value)).Select(e => (e as Enum).ToDescription()).ToList();

        }

    }
}
