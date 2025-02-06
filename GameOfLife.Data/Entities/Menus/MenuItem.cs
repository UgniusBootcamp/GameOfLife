using GameOfLife.Data.Interfaces;

namespace GameOfLife.Data.Entities.Menus
{
    public class MenuItem : IMenuItem
    {
        public string Label { get; }
        public Action Function { get; }

        public MenuItem(string label, Action function)
        {
            Label = label;
            Function = function;
        }

        public void Execute()
        {
            Function.Invoke();
        }
    }
}
