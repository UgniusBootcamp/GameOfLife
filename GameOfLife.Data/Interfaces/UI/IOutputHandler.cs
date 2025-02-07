namespace GameOfLife.Data.Interfaces.UI
{
    public interface IOutputHandler
    {
        public void Output(string message);
        public void Output(string[] messages);
        public void Clear();
    }
}
