namespace GameOfLife.Data.Entities.Menu
{
    public class MenuManager(Menu[] menus)
    {
        private Menu[] _menus = menus;
        private int _currentMenuIndex = 0;
        private int _selectedActionIndex = 0;
        private bool _isRunning = true;

        public void Run() 
        {
            while (_isRunning)
            {
                Console.Clear();
                ShowMenu();
                AwaitInput();
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("=== Game of Life ===");
            
            var menu = _menus[_currentMenuIndex];

            for (int i = 0; i < menu.Actions.Length; i++)
            {
                if ( i == _selectedActionIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("=> ");

                }
                else
                {
                    Console.Write("   ");
                }

                Console.WriteLine($"{i + 1}. {menu.Actions[i].Name}");
                Console.ResetColor();
            }
        }

        private void AwaitInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    _menus[_currentMenuIndex].Actions[_selectedActionIndex].Execute();
                    break;
                case ConsoleKey.UpArrow:
                    _selectedActionIndex = Math.Max(0, _selectedActionIndex - 1);
                    break;
                case ConsoleKey.DownArrow:
                    _selectedActionIndex = Math.Min(_menus[_currentMenuIndex].Actions.Length - 1, _selectedActionIndex + 1);
                    break;
                case ConsoleKey.Escape:
                    _isRunning = false;
                    break;
            }
        }
    }
}
