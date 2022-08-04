using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using TelegramRpBot.Entites;
using System.Threading.Tasks;

namespace TelegramRpBot
{
    class Program
    {
        private static string Token { get; set; } = "1765353729:AAEMjwPK9tBy0pDUSl9HBwZirM9JYtzFPbo";
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();

            using var cts = new CancellationTokenSource();
            var bot = new TelegramBotClient(Token);
            ReceiverOptions receiverOptions = new ReceiverOptions { AllowedUpdates = { } };
            bot.StartReceiving(Handlers.HandleUpdateAsync, Handlers.HandleErrorAsync, receiverOptions, cancellationToken: cts.Token);
            var me = await bot.GetMeAsync();
            Console.WriteLine($"Бот {me.Username} начал работу");
            Console.ReadLine();
            cts.Cancel();
        }
    }
}
