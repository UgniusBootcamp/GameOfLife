using System;

namespace GameOfLife.Data.Constants
{
    public static class GameConstants
    {
        public const char Alive = '0'; // Alive cell representation

        public const char Dead = ' '; // Dead cell representation

        public const string LenghtInputMessage = "Enter the length of the map 1 - "; // Message for inputting the length of the map

        public const string HeightInputMessage = "Enter the height of the map 1 - "; // Message for inputting the height of the map

        public const string GenerationMessage = "Generation: {0}"; // Message for displaying the current generation

        public const string PopulationMessage = "Population: {0}"; // Message for displaying the current population

        public const int DefaultAliveNeighborCount = 2; // value for alive cell to stay alive

        public const int DefaultAliveNeighborCount2 = 3; // value for alive cell to stay alive

        public  const int DefaultResurrectionNeighborCount = 3; // value for dead cell to become alive

        public const int DefaultMapSize= 20; // Default map length

        public const int DefaultDelay = 1000; // Default delay between generations

        public const char MapCorner = '+'; // Map corner representation

        public const char MapHorizontalBorder = '-'; // Map horizontal border representation

        public const char MapVerticalBorder = '|'; // Map vertical border representation

        public const string InvalidMapSizeMessage = "Invalid map size"; // Message for invalid map size

        public const string InvalidCellPositionMessage = "Invalid cell position"; // Message for invalid cell position

        public const string GameRunningMessage = "Press 'P' to pause, 'Q' to exit, Left/Right Arrow to switch"; // Message for game running

        public const string GamePausedMessage = "Press 'R' to resume, Press 'S' to save, 'Q' to exit, Left/Right Arrow to switch"; // Message for game paused

        public const string GameSaveDirectory = "GameSaves"; // Folder for game saves

        public const string MainMenuMessage = "Use Arrow keys to navigate. Press Enter to select. Press Escape to exit.\n"; // Main menu message

        public const string OptionMessage = "Select Option: 1 -"; // Option selection message

        public const string DefaultFileExtension = "json"; // Default file extension

        public const string DefaultGameSaveName = "game"; // Default game save name

        public const string FileNameEnterMessage = "Enter file name:"; // File name entering message

        public const string NoGameFoundMessage = "No Game Found"; // No game was found message

        public const string StartNewGameMessage = "Press 'N' to Start New Game"; // Action to start new game message

        public const string GameIsPause = "Game is Paused"; // Game is paused message

        public const string FileNotFoundMessage = "The file does not exist: "; // File not found message

        public const string FailedToReadGameMessage = "Failed to read Game from file:"; // Failed to read a game from a file message 

        public const string FailedToSaveGameMessage = "Failed to save Game to file"; // Failed to save game to a file message

        public const string JsonExtension = ".json"; // Json extension

        public const string StartGame = "Start Game"; // Start game message

        public const string LoadGame = "Load Game"; // Load game message

        public const string Exit = "Exit"; // Exit game message

        public const int NextMapLengthOffset = 10; // Next map to print x offset

        public const int NextMapHeightOffset = 5; // Next map to print y offset

        public const int MessageOffset = 4; // Offset to print messages

        public const char MapUnitIsAlive = '1'; // Alive cell in map

        public const char MapUnitIsDead = '0'; // Dead cell in map

        public const int DefaultFileSelectionNumber = 5; // Default number to select files

        public const int DefaultGameRunCount = 1000; // Number of games to run

        public const string Game = "Game - "; // Game
         
        public const int GamesToShow = 8; // Game to Show 

        public const string HowManyGame = "Type how many games to run 1 -"; // how many games to run message

        public const string Header = "Generation - {0} | Alive Cells - {1} | Live Games - {2}"; // game header
    }
}
