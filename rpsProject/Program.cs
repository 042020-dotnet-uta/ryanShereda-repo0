using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

//Ryan Shereda, JD Heckenliable, Michael Hall
namespace rpsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize logger
            var services = new ServiceCollection();
            ConfigureServices(services);

            //prepare logger for game, to be disposed of on game end
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                //initialize game with logger
                Gameplay game = serviceProvider.GetService<Gameplay>();

                //start game
                game.StartGame();
            }
            //new Gameplay().StartGame();
        }

        //Method taken from Mark Moore's RPS Project example
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
            .AddTransient<Gameplay>();
        }
    }
}
