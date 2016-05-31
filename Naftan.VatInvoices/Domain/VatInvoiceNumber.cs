using System;
using System.Text.RegularExpressions;

namespace Naftan.VatInvoices.Domain
{
    public class VatInvoiceNumber
    {
        public VatInvoiceNumber()
        {
        }

        public VatInvoiceNumber(string numberString)
        {
            NumberString = numberString;
        }

        private bool CheckFormat(string numberString)
        {
            var regex = new Regex(@"^\d{9}-\d{4}-\d{10}$");
            return regex.IsMatch(numberString);
        }

        public VatInvoiceNumber(string unp, int year, int number)
        {
            Number = number;
            Year = year;
            Unp = unp;
        }

        public string Unp { get; private set; }
        public int Year { get; private set; }
        public int Number { get; private set; }

        public string NumberString
        {
            get
            {
                return String.Format("{0}-{1}-{2}",Unp,Year,Number.ToString("D10"));
            }
            set
            {
                if (!CheckFormat(value))
                {
                    throw new FormatException(value + " -  number string bad format");
                }
                var props = value.Split('-');

                Unp = props[0];
                Year = int.Parse(props[1]);
                Number = int.Parse(props[2]);
            }
        }
    }
}
