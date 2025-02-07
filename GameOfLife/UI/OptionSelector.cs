using System;
using GameOfLife.Data.Constants;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.UI
{
    public class OptionSelector(IOutputHandler outputHandler, IInputHandler inputHandler) : IOptionSelector
    {
        private readonly IInputHandler _inputHandler = inputHandler;
        private readonly IOutputHandler _outputHandler = outputHandler;

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
