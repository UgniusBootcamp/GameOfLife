using System;
using GameOfLife.Data.Constants;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.UI
{
    public class OptionSelector(IOutputHandler outputHandler, IInputHandler inputHandler) : IOptionSelector
    {
        private readonly IInputHandler _inputHandler = inputHandler;
        private readonly IOutputHandler _outputHandler = outputHandler;

        /// <summary>
        /// Method to display options for user to select and get the selection option index
        /// </summary>
        /// <param name="values">options</param>
        /// <returns>selected option index</returns>
        public int Select(string[] values)
        {
            _outputHandler.Clear();

            if (values.Length == 0) return -1;

            var index = 0;
            values = values.Select(v => $"{++index}. {v}").ToArray();

            _outputHandler.Output(values);
            var input = _inputHandler.GetInt($"{GameConstants.OptionMessage} {index}");

            if (input < 1 || input > index) return 0;

            return input - 1;
        }
    }
}
