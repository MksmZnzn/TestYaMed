using TestYaMed.Enums;

namespace TestYaMed.Models
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    internal class Person
    {
        /// <summary>
        /// Имя.
        /// </summary>
        private string Name { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        private int Age { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        private Gender Gender { get; set; }

        /// <summary>
        /// Кошелек.
        /// </summary>
        private List<Money> Wallet { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="initBalance">Кошелек(начальный баланс).</param>
        public Person(string name, int age, Gender gender, decimal initBalance = 0)
        {

            Wallet = new List<Money>();
            Name = name;
            Age = age;
            Gender = gender;

            foreach (Currency currency in Enum.GetValues(typeof(Currency)))
            {
                Wallet.Add(new Money(initBalance, currency));
            }
        }

        /// <summary>
        /// Добавление Д/C.
        /// </summary>
        /// <param name="money">Деньги.</param>
        /// <exception cref="InvalidOperationException">Исключение о неправильной операции.</exception>
        public void AddMoney(Money money)
        {
            var currentMoney = Wallet.Where(n => n.Currency == money.Currency).FirstOrDefault();

            if (currentMoney != null)
            {
                currentMoney.Amount += money.Amount;
            }
            else
            {
                throw new InvalidOperationException("Невозможно добавить деньги, отсутсвует счет в кошельке");
            }
        }
        
        /// <summary>
        /// Трата Д/С.
        /// </summary>
        /// <param name="money">Деньги.</param>
        /// <exception cref="InvalidOperationException">Исключение о неправильной операции.</exception>
        public void SpendMoney(Money money)
        {
            var currentMoney = Wallet.Where(n => n.Currency == money.Currency).FirstOrDefault();

            if (currentMoney != null)
            {
                if (currentMoney.Amount < money.Amount)
                    throw new InvalidOperationException("Недостаточно денег");

                currentMoney.Amount -= money.Amount;
            }
            else
            {
                throw new InvalidOperationException("Невозможно потратить деньги, отсутсвует кошелек");
            }
        }

        /// <summary>
        /// Вывод информации о пользователе.
        /// </summary>
        public void PrintInfo()

        {
            Console.WriteLine($"\nИмя: {Name}, Возраст: {Age}, Пол: {Gender}");
            Console.WriteLine("\nБаланс кошелька: ");

            foreach (var money in Wallet)
            {
                Console.WriteLine($"Валюта: {money.Currency} Баланс: {money.Amount}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Перевод Д/С.
        /// </summary>
        /// <param name="recipient">Получатель.</param>
        /// <param name="money">Деньги.</param>
        public void TransferMoneyTo(Person recipient, Money money)
        {
            SpendMoney(money);

            try
            {
                recipient.AddMoney(money);
            }
            catch (Exception)
            {
                AddMoney(money);
                throw;
            }
        }
    }
}
