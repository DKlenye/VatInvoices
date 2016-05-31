using System;
using System.Linq;
using System.Reflection;
using Naftan.VatInvoices.Converters;

namespace Naftan.VatInvoices.Extensions
{
    public static class TypeConverterExtension
    {

        public static T ConvertTo<T>(this object value) where T : new()
        {
            var objectType = value.GetType();
            var convertType = typeof (T);
            var converter = FindConverter(objectType,convertType);

            var method = converter.GetMethods().FirstOrDefault(x => x.ReturnType == convertType);

            return (T)method.Invoke(Activator.CreateInstance(converter), new []{value});

        }

        private static Type FindConverter(Type type1,Type type2)
        {

            var converters = typeof(IConverter<,>)
                .Assembly
                .GetTypes()
                .Where(x => x.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConverter<,>)) && x.IsClass).ToList();

            return converters.FirstOrDefault(x =>
            {
                var args =
                    x.GetInterfaces()
                        .FirstOrDefault((i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof (IConverter<,>)))
                        .GetGenericArguments();

                var t1 = args[0];
                var t2 = args[1];

                return (t1 == type1 || t1 == type2) && (t2 == type1 || t2 == type2);

            });


           
            
        }

    }
}
