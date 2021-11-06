// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsetting.json")
    .Build();

var conString = config.GetConnectionString("ConString");

Console.Read();