namespace GameOfLife.Data.Interfaces.UI
{
    public interface IOptionSelector
    {
        /// <summary>
        /// Method to display options for user to select and get the selection option index
        /// </summary>
        /// <param name="values">options</param>
        /// <returns>selected option index</returns>
        public int Select(string[] values);
    }
}
