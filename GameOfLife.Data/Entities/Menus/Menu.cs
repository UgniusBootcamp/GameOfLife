using GameOfLife.Data.Interfaces;
namespace GameOfLife.Data.Entities.Menus
{
    public abstract class Menu
    {
        protected List<IMenuItem> Items = new List<IMenuItem>();

        public Menu(List<IMenuItem> items)
        {
            Items = items;
        }

        public abstract void Show();
    }
}
