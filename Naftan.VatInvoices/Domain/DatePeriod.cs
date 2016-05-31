using System;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// Временной период. Месяц Год.
    /// </summary>
    public class DatePeriod
    {
        public DatePeriod(int period)
        {
            Period = period;
        }
        public DatePeriod(int month, int year) : this(year * 100 + month) { }
        public DatePeriod(DateTime date) : this(date.Month, date.Year){ }

        public int Period { get; private set; }

        /// <summary>
        /// Месяц
        /// </summary>
        public int Month
        {
            get { return Period % 100; }
        }

        /// <summary>
        /// Год
        /// </summary>
        public int Year
        {
            get { return Period / 100; }
        }

        /// <summary>
        /// Начало действия периода. Первое число месяца
        /// </summary>
        public DateTime From
        {
            get { return new DateTime(Year, Month, 1); }
        }

        /// <summary>
        /// Окончание действия периода. Последнее число месяца время 22:59
        /// </summary>
        public DateTime To
        {
            get { return From.AddMonths(1).AddMinutes(-1); }
        }

        /// <summary>
        /// Текущий период
        /// </summary>
        public static DatePeriod Now
        {
            get { return new DatePeriod(DateTime.Now); }
        }
    }
}
