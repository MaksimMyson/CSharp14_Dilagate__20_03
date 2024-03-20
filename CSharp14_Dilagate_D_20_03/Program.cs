namespace CSharp14_Dilagate_D_20_03
{
    public class Program
    {
       
        public static Predicate<int> CreateChecker(string operation)
        {
            switch (operation.ToLower())
            {
                case "парне":
                    return IsEven;
                case "непарне":
                    return IsOdd;
                case "просте":
                    return IsPrime;
                case "фібоначчі":
                    return IsFibonacci;
                default:
                    throw new ArgumentException($"Невідома операція: {operation}");
            }
        }

        
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        
        public static bool IsOdd(int number)
        {
            return !IsEven(number);
        }

        
        public static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        
        public static bool IsFibonacci(int number)
        {
            return IsPerfectSquare(5 * number * number + 4) || IsPerfectSquare(5 * number * number - 4);
        }

      
        public static bool IsPerfectSquare(int number)
        {
            int squareRoot = (int)Math.Sqrt(number);
            return squareRoot * squareRoot == number;
        }

        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.Unicode;
           
            Predicate<int> isEven = CreateChecker("парне");
            Predicate<int> isOdd = CreateChecker("непарне");
            Predicate<int> isPrime = CreateChecker("просте");
            Predicate<int> isFibonacci = CreateChecker("фібоначчі");

           Console.WriteLine("Введіть число: ");
            int number = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"{number} - парне: {isEven(number)}");
            Console.WriteLine($"{number} - непарне: {isOdd(number)}");
            Console.WriteLine($"{number} - просте: {isPrime(number)}");
            Console.WriteLine($"{number} - Фібоначчі: {isFibonacci(number)}");
        }
    }

}
