namespace GameOfLife.Data.Entities.Menu
{
    public class MenuManager(Menu[] menus)
    {
        private Menu[] Menus = menus;
        private int _currentMenuIndex = 0;

        public void ShowMenu()
        {
            Menus[_currentMenuIndex].ShowMenu();
        }
    }
}
