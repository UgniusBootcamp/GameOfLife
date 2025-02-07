using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.UI
{
    public class ConsoleInput : IInputHandler
    {
        public int GetInt(string message)
        {
            Console.WriteLine(message);
            int.TryParse(Console.ReadLine(), out int result);

            return result;
        }

        public string? GetString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
