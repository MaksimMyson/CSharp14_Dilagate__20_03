namespace CSharp14_Dilagate_D_20_03
{
    
    public static class ArrayUtility
    {
        
        public static IEnumerable<int> GetEvenNumbers(int[] array)
        {
            foreach (int num in array)
            {
                if (IsEven(num))
                    yield return num;
            }
        }

       
        public static IEnumerable<int> GetOddNumbers(int[] array)
        {
            foreach (int num in array)
            {
                if (IsOdd(num))
                    yield return num;
            }
        }

        
        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        
        private static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }
    }

    
    public static class ArrayOperationFactory
    {
       
        public delegate IEnumerable<int> ArrayOperation(int[] array);

      
        public static ArrayOperation CreateArrayOperation(string operation)
        {
            switch (operation.ToLower())
            {
                case "парні":
                    return ArrayUtility.GetEvenNumbers;
                case "непарні":
                    return ArrayUtility.GetOddNumbers;
                default:
                    throw new ArgumentException("Невідома операція.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            try
            {
                
                ArrayOperationFactory.ArrayOperation getEven = ArrayOperationFactory.CreateArrayOperation("парні");
                ArrayOperationFactory.ArrayOperation getOdd = ArrayOperationFactory.CreateArrayOperation("непарні");

                
                Console.WriteLine("Парні числа: " + string.Join(", ", getEven(numbers)));
                Console.WriteLine("Непарні числа: " + string.Join(", ", getOdd(numbers)));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}