
using DbUp;
using Microsoft.Extensions.Configuration;

using System;
using System.IO;
using System.Reflection;

namespace SearchIndexer
{
    public class Program
    {
        static void Main()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsetting.json")
            .Build();

            var conString = config.GetConnectionString("ConString");
            var upgrader = DeployChanges.To
                       .SqlDatabase(conString)
                       .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                       .LogToConsole()
                       .Build();

            EnsureDatabase.For.SqlDatabase(conString);
            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();



        }
    }
}

   



