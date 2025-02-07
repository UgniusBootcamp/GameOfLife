namespace GameOfLife.Data.Interfaces.UI
{
    public interface IOutputHandler
    {
        /// <summary>
        /// display message
        /// </summary>
        /// <param name="message">message to display</param>
        public void Output(string message);

        /// <summary>
        /// display messages
        /// </summary>
        /// <param name="messages">messages to display</param>
        public void Output(string[] messages);

        /// <summary>
        /// clear output
        /// </summary>
        public void Clear();
    }
}
