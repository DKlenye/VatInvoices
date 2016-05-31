using System;
using System.Collections;
using System.Linq;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Mnsati;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.Converters
{
    public class ConvertersTests:BaseTest
    {

        private bool IsSimpleType(Type t)
        {
            Console.WriteLine(" TYPE:{0}, ISSIMPLE: {1}", t.Name, !t.IsClass || t == typeof(String) || t.IsEnum);
            return !t.IsClass || t == typeof (String) || t.IsEnum;
        }

        private void AssertAreEqualAllPropertiesAndFields<T>(T obj, T converted)
        {
            var type = obj.GetType();
            type.GetProperties().ToList().ForEach(p =>
            {

                Console.Write(p.Name);

                if (IsSimpleType(p.PropertyType))
                {
                    Assert.AreEqual(
                       p.GetValue(obj, null),
                       p.GetValue(converted, null),String.Format(" property {0}",p.Name));
                }
                else if (typeof(ICollection).IsAssignableFrom(p.PropertyType))
                {
                    var len1 = ((ICollection)p.GetValue(obj,null)).Count;
                    var len2 = ((ICollection)p.GetValue(converted,null)).Count;

                    Assert.AreEqual(len1, len2);
                }
                else
                {
                    AssertAreEqualAllPropertiesAndFields(
                        p.GetValue(obj,null),
                        p.GetValue(converted,null));;
                }
            });

            type.GetFields().ToList().ForEach(f =>
            {
                Console.Write(f.Name);

                if (IsSimpleType(f.FieldType))
                {
                    Assert.AreEqual(
                       f.GetValue(obj),
                       f.GetValue(converted), String.Format(" field {0}", f.Name));
                }
                else if (typeof(ICollection).IsAssignableFrom(f.FieldType))
                {
                    var len1 = ((ICollection) f.GetValue(obj)).Count;
                    var len2 = ((ICollection) f.GetValue(converted)).Count;

                    Assert.AreEqual(len1, len2);
                }
                else
                {
                    AssertAreEqualAllPropertiesAndFields(
                        f.GetValue(obj),
                        f.GetValue(converted)); ;
                }
            });

        }


        [Test]
        public void ConsigneeConvertTest()
        {
            var ce = consignee;

            var convert = ce
                .ConvertTo<Consignee>()
                .ConvertTo<consignee>();
            
            AssertAreEqualAllPropertiesAndFields(ce,convert);

           }

        [Test]
        public void ConsignorConvertTest()
        {
            var cr = consignor;
            
            var convert = cr
                .ConvertTo<Consignor>()
                .ConvertTo<consignor>();

            AssertAreEqualAllPropertiesAndFields(cr,convert);
            
        }

        [Test]
        public void DocumentConverteTest()
        {
            var doc = document;

            var _ = doc
                .ConvertTo<Document>()
                .ConvertTo<document>();

            AssertAreEqualAllPropertiesAndFields(doc,_);
            
        }

        [Test]
        public void ProviderConvertTest()
        {
            var p = provider;

            var _ = p
                .ConvertTo<Provider>()
                .ConvertTo<provider>();

            AssertAreEqualAllPropertiesAndFields(p,_);
            
        }

        [Test]
        public void RecipientConvertTest()
        {
            var r = recipient;

            var _ = r
                .ConvertTo<Recipient>()
                .ConvertTo<recipient>();

            AssertAreEqualAllPropertiesAndFields(r,_);
        }

        [Test]
        public void RosterConvertTest()
        {
            var r = roster;

            var _ = r
                .ConvertTo<Roster>()
                .ConvertTo<rosterItem>();

            AssertAreEqualAllPropertiesAndFields(r,_);

        }
        
    }
}
