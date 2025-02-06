using GameOfLife.Data.Constants;
using GameOfLife.Data.Interfaces;

namespace GameOfLife.UI
{
    public class UserInputHandler : IInputHandler
    {
        public int GetInt(string message)
        {
            Console.WriteLine(message);
            return int.TryParse(Console.ReadLine(), out int result) ? result : GameConstants.DefaultMapSize;
        }
    }
}
