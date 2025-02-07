using GameOfLife.Data.Interfaces;
namespace GameOfLife.Data.Entities.Menus
{
    public abstract class Menu
    {
        protected List<IMenuItem> Items = new List<IMenuItem>();

        /// <summary>
        /// Constructor for Menu
        /// </summary>
        /// <param name="items">Menu items</param>
        public Menu(List<IMenuItem> items)
        {
            Items = items;
        }

        /// <summary>
        /// Method to show Menu items
        /// </summary>
        public abstract void Show();
    }
}
