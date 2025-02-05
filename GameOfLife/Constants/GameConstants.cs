using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Constants
{
    public static class GameConstants
    {
        public const char Alive = '0'; // Alive cell representation

        public const char Dead = ' '; // Dead cell representation

        public const string LenghtInputMessage = "Enter the length of the map: "; // Message for inputting the length of the map

        public const string HeightInputMessage = "Enter the height of the map: "; // Message for inputting the height of the map

        public const string GenerationsInputMessage = "Enter the number of generations: "; // Message for inputting the number of generations

        public const string GenerationMessage = "Generation: {0}"; // Message for displaying the current generation

        public const string PopulationMessage = "Population: {0}"; // Message for displaying the current population

    }
}
