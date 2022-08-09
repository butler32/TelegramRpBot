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
        static Repository<Active> activeRepository = new Repository<Active>();
        static Repository<Armor> armorRepository = new Repository<Armor>();
        static Repository<Inventory> inventoryRepository = new Repository<Inventory>();
        static Repository<Item> itemRepository = new Repository<Item>();
        static Repository<Potion> potionRepository = new Repository<Potion>();
        static Repository<Weapon> weaponRepository = new Repository<Weapon>();
        static Repository<Monster> monsterRepository = new Repository<Monster>();
        static Repository<Advantage> advantageRepsitory = new Repository<Advantage>();
        static Repository<Disadvantage> disadvantageRepository = new Repository<Disadvantage>();


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
                    case "/addmob":
                        {
                            player.InputPlayer = (int)PlayerInput.Mob;
                            playerRepository.Update(player);
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ќапишите через пробел им€, сп, защиту, тип защиты, атаку");
                            break;
                        }

                    case "получить":
                        {
                            await ParseService.AdvantageParse(botClient, message);
                            break;
                        }

                    case "улучшить":
                        {
                            player.InputPlayer = (int)PlayerInput.Ability;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "¬ведите название умени€, когда закончите напишите вернутьс€");
                            break;
                        }

                    case "проверить":
                        {
                            await AbilityService.AbilityCheck(botClient, message);
                            break;
                        }

                    case "вернутьс€":
                        {
                            player.InputPlayer = (int)PlayerInput.NonInput;
                            await CharacterCreationService.CreationMenu(botClient, message, player);
                            break;
                        }

                    case "создать":
                        {

                            break;
                        }

                    case "/roll":
                        {
                            Random random = new Random();

                            int num1;
                            int num2;
                            int num3;

                            num1 = random.Next(1, 6);
                            num2 = random.Next(1, 6);
                            num3 = random.Next(1, 6);

                            if (messageSplit.Length == 1)
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"¬ыпало {num1} + {num2} + {num3} = {num1 + num2 + num3}");
                            }
                            break;
                        }

                    default:
                        {
                            switch ((PlayerInput)player.InputPlayer)
                            {
                                case PlayerInput.NonInput:
                                    {
                                        break;
                                    }

                                case PlayerInput.RaceInput:
                                    {
                                        player.Race = message.Text;
                                        player.InputPlayer = (int)PlayerInput.RaceSpecial;
                                        playerRepository.Update(player);
                                        await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                                            text: "Ќапишите особенности расы через зап€тую. ќни ни на что не вли€ют, но можно их отыгрывать (если нету пиши нету)");
                                        break;
                                    }

                                case PlayerInput.RaceSpecial:
                                    {
                                        player.RaceSpecial = message.Text;
                                        player.InputPlayer = (int)PlayerInput.NonInput;
                                        playerRepository.Update(player);
                                        await CharacterCreationService.CreationMenu(botClient, message, player);
                                        break;
                                    }

                                case PlayerInput.CharacterName:
                                    {
                                        player.CharacterName = message.Text;
                                        player.InputPlayer = (int)PlayerInput.NonInput;
                                        playerRepository.Update(player);
                                        await CharacterCreationService.CreationMenu(botClient, message, player);
                                        break;
                                    }

                                case PlayerInput.Advantage:
                                    {
                                        await AddvantegesService.GetAdvantage(botClient, message);
                                        break;
                                    }

                                case PlayerInput.Disadvantage:
                                    {
                                        await AddvantegesService.GetGisadvantage(botClient, message);
                                        break;
                                    }

                                case PlayerInput.Ability:
                                    {
                                        await AbilityService.AbilityUpgrade(botClient, message);
                                        break;
                                    }

                                case PlayerInput.Mob:
                                    {
                                        await MobService.AddMob(botClient, message);
                                        break;
                                    }

                                case PlayerInput.ActiveLeft:
                                    {
                                        await ItemService.ChangeLeftHand(botClient, message);
                                        break;
                                    }

                                case PlayerInput.ActiveRight:
                                    {
                                        await ItemService.ChangeRightHand(botClient, message);
                                        break;
                                    }

                                case PlayerInput.ActiveArmor:
                                    {
                                        await ItemService.ChangeArmor(botClient, message);
                                        break;
                                    }
                            }

                            break;
                        }
                }
            }
            else
            {
                await CharacterCreationService.AddNewCharacter(botClient, message);
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