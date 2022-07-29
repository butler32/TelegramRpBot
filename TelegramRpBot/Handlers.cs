using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Microsoft.Data.SqlClient;
using TelegramRpBot.Entites;
using Telegram.Bot;
using TelegramRpBot.Enums;
using TelegramRpBot.Services;

namespace TelegramRpBot
{

    public class Handlers
    {
        static Repository<Player> playerRepository = new Repository<Player>();
        static Repository<Accessories> accessoriesRepository = new Repository<Accessories>();
        static Repository<Active> activeRepository = new Repository<Active>();
        static Repository<Armor> armorRepository = new Repository<Armor>();
        static Repository<Inventory> inventoryRepository = new Repository<Inventory>();
        static Repository<Item> itemRepository = new Repository<Item>();
        static Repository<Potion> potionRepository = new Repository<Potion>();
        static Repository<Weapon> weaponRepository = new Repository<Weapon>();
        static Repository<Monster> monsterRepository = new Repository<Monster>();
        static Repository<Advantage> advantageRepsitory = new Repository<Advantage>();
        static Repository<Disadvantage> disadvantageRepository = new Repository<Disadvantage>();

        public static PlayerInput playerInput = 0;

        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                // UpdateType.Unknown:
                // UpdateType.ChannelPost:
                // UpdateType.EditedChannelPost:
                // UpdateType.ShippingQuery:
                // UpdateType.PreCheckoutQuery:
                // UpdateType.Poll:
                UpdateType.Message => BotOnMessageReceived(botClient, update.Message!),
                UpdateType.EditedMessage => BotOnMessageReceived(botClient, update.EditedMessage!),
                UpdateType.CallbackQuery => BotOnCallbackQueryReceived(botClient, update.CallbackQuery!),
                //UpdateType.InlineQuery => BotOnInlineQueryReceived(botClient, update.InlineQuery!),
                //UpdateType.ChosenInlineResult => BotOnChosenInlineResultReceived(botClient, update.ChosenInlineResult!),
                _ => UnknownUpdateHandlerAsync(botClient, update)
            };

            try
            {
                await handler;
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(botClient, exception, cancellationToken);
            }
        }

        private static async Task BotOnMessageReceived(ITelegramBotClient botClient, Message message)
        {
            string[] messageSplit = message.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            if (messageSplit[0] != "/start")
            {
                Player player = playerRepository.List().FirstOrDefault(i => i.UserId == (int)message.From.Id);

                switch (messageSplit[0].ToLower())
                {
                    case "приобрести":
                        {
                            await AddvantegesService.GetAdvantageOrDisadvantage(botClient, message);
                            break;
                        }

                    default:
                        {
                            switch (playerInput)
                            {
                                case PlayerInput.NonInput:
                                    {
                                        break;
                                    }

                                case PlayerInput.RaceInput:
                                    {
                                        player.Race = message.Text;
                                        playerInput = PlayerInput.RaceSpecial;
                                        await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                            text: "Напишите особенности расы через запятую. Они ни на что не влияют, но можно их отыгрывать (если нету пиши нету)");
                                        break;
                                    }

                                case PlayerInput.RaceSpecial:
                                    {
                                        player.RaceSpecial = message.Text;
                                        playerInput = PlayerInput.NonInput;
                                        await CharacterCreationService.CreationMenu(botClient, message, player);
                                        break;
                                    }

                                case PlayerInput.CharacterName:
                                    {
                                        player.CharacterName = message.Text;
                                        playerInput = PlayerInput.NonInput;
                                        await CharacterCreationService.CreationMenu(botClient, message, player);
                                        break;
                                    }
                            }

                            break;
                        }
                }
            }
            else
            {
                Advantage advantage = advantageRepsitory.Add(new Advantage
                {
                    PlayerId = (int)message.From.Id,
                });

                Disadvantage disadvantage = disadvantageRepository.Add(new Disadvantage
                {
                    PlayerId = (int)message.From.Id,
                });

                Inventory inventory = inventoryRepository.Add(new Inventory
                {
                    PlayerId = (int)message.From.Id,
                });

                Active active = activeRepository.Add(new Active
                {
                    PlayerId = (int)message.From.Id,
                    MainHand = "Правая",
                });

                Player player = playerRepository.Add(new Player
                {
                    UserId = (int)message.From.Id,
                    CharacterName = "Нету",
                    Race = "Нету",
                    RaceSpecial = "Нету",
                    Strength = 10,
                    Dexterity = 10,
                    Inteligence = 10,
                    Health = 10,
                    HealthPoints = 10,
                    Fatigue = 10,
                    Points = 75,
                });

                await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                                            text: $"Персонаж создан. Очков осталось: {player.Points}");
                await CharacterCreationService.CreationMenu(botClient, message, player);
            }
        }

        // Process Inline Keyboard callback data
        private static async Task BotOnCallbackQueryReceived(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            Player player = playerRepository.List().FirstOrDefault(i => i.UserId == (int)callbackQuery.From.Id);

            if (callbackQuery.Data.StartsWith("playerCreation"))
            {
                await CharacterCreationService.CallBackDataCheck(botClient, callbackQuery, player);
            }

            
        }

        private static Task UnknownUpdateHandlerAsync(ITelegramBotClient botClient, Update update)
        {
            Console.WriteLine($"Unknown update type: {update.Type}");
            return Task.CompletedTask;
        }
        
        
    }
}