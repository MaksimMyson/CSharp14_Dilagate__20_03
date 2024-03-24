namespace CSharp14_Dilagate_D_20_03
{

    public delegate void AccountReplenishmentEventHandler(decimal amount);
    public delegate void MoneySpentEventHandler(decimal amount);
    public delegate void CreditStartedEventHandler();
    public delegate void LimitReachedEventHandler(decimal limitAmount);
    public delegate void PinChangedEventHandler(string oldPin, string newPin);

    public class CreditCard
    {
        public string CardNumber { get; }
        public string CardholderName { get; }
        public DateTime ExpiryDate { get; }
        public string Pin { get; private set; }
        public decimal CreditLimit { get; }
        public decimal Balance { get; private set; }

        
        public event AccountReplenishmentEventHandler AccountReplenishment;
        public event MoneySpentEventHandler MoneySpent;
        public event CreditStartedEventHandler CreditStarted;
        public event LimitReachedEventHandler LimitReached;
        public event PinChangedEventHandler PinChanged;

      
        private CreditCard(string cardNumber, string cardholderName, DateTime expiryDate, string pin, decimal creditLimit, decimal balance)
        {
            CardNumber = cardNumber;
            CardholderName = cardholderName;
            ExpiryDate = expiryDate;
            Pin = pin;
            CreditLimit = creditLimit;
            Balance = balance;
        }

     
        public static CreditCard Create(string cardNumber, string cardholderName, DateTime expiryDate, string pin, decimal creditLimit, decimal balance)
        {
            return new CreditCard(cardNumber, cardholderName, expiryDate, pin, creditLimit, balance);
        }

        
        public void ReplenishAccount(decimal amount)
        {
            Balance += amount;
            OnAccountReplenishment(amount);
        }

        
        public void SpendMoney(decimal amount)
        {
            Balance -= amount;
            OnMoneySpent(amount);
        }

       
        public void StartCreditUsage()
        {
            OnCreditStarted();
        }

        
        public void CheckLimitReached(decimal limitAmount)
        {
            if (Balance >= limitAmount)
            {
                OnLimitReached(limitAmount);
            }
        }

       
        public void ChangePin(string oldPin, string newPin)
        {
            if (Pin == oldPin)
            {
                Pin = newPin;
                OnPinChanged(oldPin, newPin);
            }
        }

        
        protected virtual void OnAccountReplenishment(decimal amount)
        {
            AccountReplenishment?.Invoke(amount);
        }

        protected virtual void OnMoneySpent(decimal amount)
        {
            MoneySpent?.Invoke(amount);
        }

        protected virtual void OnCreditStarted()
        {
            CreditStarted?.Invoke();
        }

        protected virtual void OnLimitReached(decimal limitAmount)
        {
            LimitReached?.Invoke(limitAmount);
        }

        protected virtual void OnPinChanged(string oldPin, string newPin)
        {
            PinChanged?.Invoke(oldPin, newPin);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter card details:");

            
            Console.Write("Card Number: ");
            string cardNumber = Console.ReadLine();

            Console.Write("Cardholder Name: ");
            string cardholderName = Console.ReadLine();

            Console.Write("Expiry Date (YYYY-MM-DD): ");
            DateTime expiryDate = DateTime.Parse(Console.ReadLine());

            Console.Write("PIN: ");
            string pin = Console.ReadLine();

            Console.Write("Credit Limit: ");
            decimal creditLimit = decimal.Parse(Console.ReadLine());

            Console.Write("Balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            
            CreditCard creditCard = CreditCard.Create(cardNumber, cardholderName, expiryDate, pin, creditLimit, balance);

           
            creditCard.AccountReplenishment += (amount) => Console.WriteLine($"Account replenished with {amount:C}. New balance: {creditCard.Balance:C}");
            creditCard.MoneySpent += (amount) => Console.WriteLine($"Money spent: {amount:C}. New balance: {creditCard.Balance:C}");
            creditCard.CreditStarted += () => Console.WriteLine("Credit usage started.");
            creditCard.LimitReached += (limitAmount) => Console.WriteLine($"Credit limit reached: {limitAmount:C}");
            creditCard.PinChanged += (oldPin, newPin) => Console.WriteLine($"PIN changed from {oldPin} to {newPin}");

            
            creditCard.ReplenishAccount(100);
            creditCard.SpendMoney(50);
            creditCard.ChangePin("1234", "4321");
        }
    }
}
