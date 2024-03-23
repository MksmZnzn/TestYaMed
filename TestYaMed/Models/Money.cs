using TestYaMed.Enums;

namespace TestYaMed.Models
{
    /// <summary>
    /// Представление денег.
    /// </summary>
    internal class Money
    {
        /// <summary>
        /// Сумма.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        public Currency Currency { get; set; }

        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
