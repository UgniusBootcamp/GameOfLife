using GameOfLife.Data.Entities.Rules;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;
using GameOfLife.Data.Util;
using GameOfLife.UI;
using Microsoft.Extensions.DependencyInjection;


namespace GameOfLife.Dependencies
{
    public static class DependencyContainer
    {
        public static ServiceProvider ConfigureService()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IInputHandler, ConsoleInput>();
            services.AddSingleton<IOutputHandler, ConsoleOutput>();
            services.AddSingleton<IOptionSelector, OptionSelector>();
            services.AddSingleton<IRule, DefaultRule>();
            services.AddSingleton<IGameLogic, GameLogic>();
            services.AddSingleton<IFileService, JsonFileService>();
            services.AddSingleton<IGamePrinter, GamePrinter>();
            services.AddScoped<GameService>();
            services.AddTransient<IGameCreator, GameCreationService>();
            services.AddTransient<IGameLoader, GameLoaderService>();
            services.AddTransient<IGameSaver, GameSaver>();

            return services.BuildServiceProvider();
        }
    }
}
