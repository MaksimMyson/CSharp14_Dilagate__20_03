namespace CSharp14_Dilagate_D_20_03
{
    public delegate double ArithmeticOperation(double num1, double num2);

    
    public static class ArithmeticFactory
    {
        public static ArithmeticOperation CreateOperation(char op)
        {
            switch (op)
            {
                case '+':
                    return (num1, num2) => num1 + num2;
                case '-':
                    return (num1, num2) => num1 - num2;
                case '*':
                    return (num1, num2) => num1 * num2;
                default:
                    throw new ArgumentException("Непідтримувана операція.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {  
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            try
            {
                
                ArithmeticOperation add = ArithmeticFactory.CreateOperation('+');
                ArithmeticOperation subtract = ArithmeticFactory.CreateOperation('-');
                ArithmeticOperation multiply = ArithmeticFactory.CreateOperation('*');

                
                double result1 = add(5, 3);
                double result2 = subtract(10, 4);
                double result3 = multiply(6, 7);

                
                Console.WriteLine($"Додавання: 5 + 3 = {result1}");
                Console.WriteLine($"Віднімання: 10 - 4 = {result2}");
                Console.WriteLine($"Множення: 6 * 7 = {result3}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
