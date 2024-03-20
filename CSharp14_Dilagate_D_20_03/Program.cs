namespace CSharp14_Dilagate_D_20_03
{
        public static class MethodUtility
        {
          
            public static void DisplayCurrentTime()
            {
                Console.WriteLine($"Поточний час: {DateTime.Now:HH:mm:ss}");
            }

           
            public static void DisplayCurrentDate()
            {
                Console.WriteLine($"Поточна дата: {DateTime.Now:yyyy-MM-dd}");
            }

           
            public static void DisplayCurrentDayOfWeek()
            {
                Console.WriteLine($"Поточний день тижня: {DateTime.Now.DayOfWeek}");
            }

            
            public static double CalculateTriangleArea(double baseLength, double height)
            {
                return 0.5 * baseLength * height;
            }

            
            public static double CalculateRectangleArea(double length, double width)
            {
                return length * width;
            }
        }

        
        public static class MethodFactory
        {
          
            public delegate void ActionMethod();

            
            public delegate double FuncMethod(double arg1, double arg2);

            
            public static object CreateMethod(string methodName)
            {
                switch (methodName.ToLower())
                {
                    case "поточний час":
                        return new ActionMethod(MethodUtility.DisplayCurrentTime);
                    case "поточна дата":
                        return new ActionMethod(MethodUtility.DisplayCurrentDate);
                    case "поточний день тижня":
                        return new ActionMethod(MethodUtility.DisplayCurrentDayOfWeek);
                    case "площа трикутника":
                        return new FuncMethod(MethodUtility.CalculateTriangleArea);
                    case "площа прямокутника":
                        return new FuncMethod(MethodUtility.CalculateRectangleArea);
                    default:
                        throw new ArgumentException("Невідомий метод.");
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    
                    MethodFactory.ActionMethod displayTime = (MethodFactory.ActionMethod)MethodFactory.CreateMethod("поточний час");
                    MethodFactory.ActionMethod displayDate = (MethodFactory.ActionMethod)MethodFactory.CreateMethod("поточна дата");
                    MethodFactory.ActionMethod displayDayOfWeek = (MethodFactory.ActionMethod)MethodFactory.CreateMethod("поточний день тижня");
                    MethodFactory.FuncMethod calculateTriangleArea = (MethodFactory.FuncMethod)MethodFactory.CreateMethod("площа трикутника");
                    MethodFactory.FuncMethod calculateRectangleArea = (MethodFactory.FuncMethod)MethodFactory.CreateMethod("площа прямокутника");

                   
                    displayTime();
                    displayDate();
                    displayDayOfWeek();
                    Console.WriteLine($"Площа трикутника: {calculateTriangleArea(5, 8)}");
                    Console.WriteLine($"Площа прямокутника: {calculateRectangleArea(4, 6)}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
        }
}
