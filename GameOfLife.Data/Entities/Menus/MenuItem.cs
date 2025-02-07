using GameOfLife.Data.Interfaces;

namespace GameOfLife.Data.Entities.Menus
{
    public class MenuItem : IMenuItem
    {
        public string Label { get; }
        public Action Function { get; }

        /// <summary>
        /// Menu Item constuctor
        /// </summary>
        /// <param name="label">Menu item label</param>
        /// <param name="function">action for a menu option to perfom if selected</param>
        public MenuItem(string label, Action function)
        {
            Label = label;
            Function = function;
        }

        /// <summary>
        /// Selected menu item execution
        /// </summary>
        public void Execute()
        {
            Function.Invoke();
        }
    }
}
