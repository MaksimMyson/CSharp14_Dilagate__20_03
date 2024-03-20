namespace CSharp14_Dilagate_D_20_03
{
    public delegate void MessageDelegate(string message);

    public class MessageApp
    {
        
        public static void DisplayMessage(string message)
        {
            Console.WriteLine($"Повідомлення: {message}");
        }

        
        public static void SendMessage(MessageDelegate messageDelegate, string message)
        {
            messageDelegate(message);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;  
            
            MessageDelegate messageDelegate = new MessageDelegate(DisplayMessage);

            
            SendMessage(messageDelegate, "Це тестове повідомлення.");

            
            SendMessage(messageDelegate, "Це ще одне повідомлення.");

            
            messageDelegate = new MessageDelegate(Console.WriteLine);
            SendMessage(messageDelegate, "Інше повідомлення з іншим методом виводу.");
        }
    }
}
