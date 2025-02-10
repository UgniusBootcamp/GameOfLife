using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.UI
{
    public class ConsoleOutput : IOutputHandler
    {
        /// <summary>
        /// Method for user output to console
        /// </summary>
        /// <param name="message">message to user</param>
        public void Output(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Method for user output to console overload with many messages
        /// </summary>
        /// <param name="messages">many messages to user</param>
        public void Output(string[] messages)
        {
            foreach (var message in messages) 
            {
                Console.WriteLine(message);
            }
        }

        /// <summary>
        /// Method to clear console window
        /// </summary>
        public void Clear() { Console.Clear(); }
    }
}
