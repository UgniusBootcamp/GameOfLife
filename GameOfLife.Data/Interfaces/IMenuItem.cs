namespace GameOfLife.Data.Interfaces
{
    public interface IMenuItem
    {
        string Label { get; }

        /// <summary>
        /// menu item action
        /// </summary>
        void Execute();
    }
}
