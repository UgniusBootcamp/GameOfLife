using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Data.Constants
{
    public static class GameConstants
    {
        public const char Alive = '0'; // Alive cell representation

        public const char Dead = ' '; // Dead cell representation

        public const string LenghtInputMessage = "Enter the length of the map: "; // Message for inputting the length of the map

        public const string HeightInputMessage = "Enter the height of the map: "; // Message for inputting the height of the map

        public const string GenerationMessage = "Generation: {0}"; // Message for displaying the current generation

        public const string PopulationMessage = "Population: {0}"; // Message for displaying the current population

        public const int DefaultAliveNeighborCount = 2; // value for alive cell to stay alive

        public const int DefaultAliveNeighborCount2 = 3; // value for alive cell to stay alive

        public  const int DefaultResurrectionNeighborCount = 3; // value for dead cell to become alive

        public const int DefaultMapSize= 10; // Default map length

        public const int DefaultDelay = 1000; // Default delay between generations

        public const char MapCorner = '+'; // Map corner representation

        public const char MapHorizontalBorder = '-'; // Map horizontal border representation

        public const char MapVerticalBorder = '|'; // Map vertical border representation

        public const string InvalidMapSizeMessage = "Invalid map size"; // Message for invalid map size

        public const string InvalidCellPositionMessage = "Invalid cell position"; // Message for invalid cell position
    }
}
