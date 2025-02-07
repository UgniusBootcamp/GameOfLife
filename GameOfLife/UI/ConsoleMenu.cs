using GameOfLife.Data.Constants;
using GameOfLife.Data.Entities.Menus;
using GameOfLife.Data.Interfaces;

namespace GameOfLife.UI
{
    public class ConsoleMenu(List<IMenuItem> items) : Menu(items)
    {
        public override void Show()
        {
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(GameConstants.MainMenuMessage);

                for (int i = 0; i < Items.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine($" {Items[i].Label} ");

                    Console.ResetColor();
                }

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex == 0) ? Items.Count - 1 : selectedIndex - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex == Items.Count - 1) ? 0 : selectedIndex + 1;
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        Items[selectedIndex].Execute();
                        return;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }
    }
}
