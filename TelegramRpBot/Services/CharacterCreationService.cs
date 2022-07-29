using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramRpBot.Entites;
using TelegramRpBot.Enums;

namespace TelegramRpBot.Services
{
    public class CharacterCreationService
    {
        static Repository<Player> playerRepository = new Repository<Player>();

        public static async Task CreationMenu(ITelegramBotClient botClient, Message message, Player player)
        {
            // Player player = playerRepository.List().FirstOrDefault(i => i.UserId == (int)message.From.Id);
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                text: $"Меню.\nИмя персонажа: {player.CharacterName}\nРаса: {player.Race}\nОсобенности расы: {player.RaceSpecial}\n\n" +
                $"Преимущества:\n\n\nОчков осталось: {player.Points}",
                replyMarkup: Keyboards.CreationMenuKeyboard);
        }

        public static async Task CreationStats(ITelegramBotClient botClient, Message message, Player player)
        {
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                    text: $"Очков осталось: {player.Points}\n\nСила - {player.Strength}\nЛовкость - {player.Dexterity}\n" +
                    $"Интеллект - {player.Inteligence}\nЖивучесть - {player.Health}\nХп - {player.HealthPoints} (зависят от силы)\n" +
                    $"Усталость - {player.Fatigue} (зависит от живучести)",
                    replyMarkup: Keyboards.CreationStatsShop);
        }

        public static async Task<Player> ResetAll(ITelegramBotClient botClient, CallbackQuery callbackQuery, Player player)
        {
            player.CharacterName = "Нету";
            player.Race = "Нету";
            player.RaceSpecial = "Нету";
            player.Strength = 10;
            player.Dexterity = 10;
            player.Inteligence = 10;
            player.Health = 10;
            player.HealthPoints = 10;
            player.Fatigue = 10;
            player.Points = 75;
            await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Всё сброшено, начинай заново");
            return player;
        }

        public static async Task CallBackDataCheck(ITelegramBotClient botClient, CallbackQuery callbackQuery, Player player)
        {
            switch(callbackQuery.Data)
            {
                case "playerCreationStatsMenu":
                    {
                        await CharacterCreationService.CreationStats(botClient, callbackQuery.Message, player);
                        break;
                    }

                case "playerCreationRaceSpecial":
                    {
                        Handlers.playerInput = PlayerInput.RaceSpecial;
                        await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                            text: "Введите особенности расы");
                        break;
                    }

                case "playerCreationCharacterName":
                    {
                        Handlers.playerInput = PlayerInput.CharacterName;
                        await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                            text: "Введите имя персонажа");
                        break;
                    }

                case "playerCreationStatsBuyStrenght":
                    {
                        player = await StatsService.BuyStrength(botClient, callbackQuery, player);
                        playerRepository.Update(player);
                        break;
                    }

                case "playerCreationStatsBuyDexterity":
                    {
                        player = await StatsService.BuyDexterity(botClient, callbackQuery, player);
                        playerRepository.Update(player);
                        break;
                    }

                case "playerCreationStatsBuyInteligence":
                    {
                        player = await StatsService.BuyInteligence(botClient, callbackQuery, player);
                        playerRepository.Update(player);
                        break;
                    }

                case "playerCreationStatsBuyHealth":
                    {
                        player = await StatsService.BuyHealth(botClient, callbackQuery, player);
                        playerRepository.Update(player);
                        break;
                    }

                case "playerCreationStatsSellStrenght":
                    {
                        player = await StatsService.SellStrength(botClient, callbackQuery, player);
                        playerRepository.Update(player);
                        break;
                    }

                case "playerCreationStatsSellDexterity":
                    {
                        player = await StatsService.SellDexterity(botClient, callbackQuery, player);
                        playerRepository.Update(player);
                        break;
                    }

                case "playerCreationStatsSellInteligence":
                    {
                        player = await StatsService.SellInteligence(botClient, callbackQuery, player);
                        playerRepository.Update(player);
                        break;
                    }

                case "playerCreationStatsSellHealth":
                    {
                        player = await StatsService.SellHealth(botClient, callbackQuery, player);
                        playerRepository.Update(player);
                        break;
                    }

                case "playerCreationResetAll":
                    {
                        player = await CharacterCreationService.ResetAll(botClient, callbackQuery, player);
                        break;
                    }

                case "playerCreationRaceMenu":
                    {
                        Handlers.playerInput = PlayerInput.RaceInput;
                        await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                            text: "Напишите название расы");
                        break;
                    }

                case "playerCreationPositiveMenu":
                    {
                        await AddvantegesService.SendAllAdvantages(botClient, callbackQuery.Message.Chat.Id);
                        break;
                    }

                case "playerCreationNegativeMenu":
                    {
                        await AddvantegesService.SendAllDisadvantages(botClient, callbackQuery.Message.Chat.Id);
                        break;
                    }

                case "playerCreationStatsBackToMenu":
                    {
                        await CharacterCreationService.CreationMenu(botClient, callbackQuery.Message, player);
                        break;
                    }

                case "playerCreationConfirmCharacter":
                    {
                        playerRepository.Update(player);
                        break;
                    }
            }
        }
    }
}
