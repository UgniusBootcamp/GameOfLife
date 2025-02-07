using System;
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

            var index = 0;
            values = values.Select(v => $"{++index}. {v}").ToArray();

            if (values.Length == 0) return index;

            _outputHandler.Output(values);
            var input = _inputHandler.GetInt($"Select Option: 1 - {index}");

            if (input < 1 || input > index) return 0;

            return input - 1;
        }
    }
}
