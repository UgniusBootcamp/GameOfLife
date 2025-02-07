using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.UI
{
    public class ConsoleOutput : IOutputHandler
    {
        public void Output(string message)
        {
            Console.WriteLine(message);
        }

        public void Output(string[] messages)
        {
            foreach (var message in messages) 
            {
                Console.WriteLine(message);
            }
        }

        public void Clear() { Console.Clear(); }
    }
}
