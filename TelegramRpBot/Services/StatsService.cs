using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramRpBot.Entites;

namespace TelegramRpBot.Services
{
    public class StatsService
    {
        public static async Task<Player> BuyStrength(ITelegramBotClient botClient, CallbackQuery callbackQuery, Player player)
        {
            if (player.Points >= 10)
            {
                player.Points -= 10;
                player.Strength += 1;
                player.HealthPoints += 1;
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Вы успешно купили 1 ед. силы, а так же ваши хп увеличины на 1 ед.");
                await CharacterCreationService.CreationStats(botClient, callbackQuery.Message, player);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Еблан тебе не хватает");
            }
            return player;
        }

        public static async Task<Player> BuyDexterity(ITelegramBotClient botClient, CallbackQuery callbackQuery, Player player)
        {
            if (player.Points >= 20)
            {
                player.Points -= 20;
                player.Dexterity += 1;
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Вы успешно купили 1 ед. ловкости");
                await CharacterCreationService.CreationStats(botClient, callbackQuery.Message, player);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Еблан тебе не хватает");
            }
            return player;
        }

        public static async Task<Player> BuyInteligence(ITelegramBotClient botClient, CallbackQuery callbackQuery, Player player)
        {
            if (player.Points >= 20)
            {
                player.Points -= 20;
                player.Inteligence += 1;
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Вы успешно купили 1 ед. интеллекта");
                await CharacterCreationService.CreationStats(botClient, callbackQuery.Message, player);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Еблан тебе не хватает");
            }
            return player;
        }

        public static async Task<Player> BuyHealth(ITelegramBotClient botClient, CallbackQuery callbackQuery, Player player)
        {
            if (player.Points >= 10)
            {
                player.Points -= 10;
                player.Health += 1;
                player.Fatigue += 1;
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Вы успешно купили 1 ед. живучести, а так же ваша усталость увеличина на 1 ед.");
                await CharacterCreationService.CreationStats(botClient, callbackQuery.Message, player);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Еблан тебе не хватает");
            }
            return player;
        }

        public static async Task<Player> SellStrength(ITelegramBotClient botClient, CallbackQuery callbackQuery, Player player)
        {
            if (player.Strength > 1)
            {
                player.Points += 10;
                player.Strength -= 1;
                player.HealthPoints -= 1;
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Вы успешно продали 1 ед. силы, а так же ваши хп уменьшены на 1 ед. Вы получили 10 очков");
                await CharacterCreationService.CreationStats(botClient, callbackQuery.Message, player);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Еблан у тебя и так 1 сила, куда меньше дрыщ ебаный");
            }
            return player;
        }

        public static async Task<Player> SellDexterity(ITelegramBotClient botClient, CallbackQuery callbackQuery, Player player)
        {
            if (player.Dexterity > 1)
            {
                player.Points += 20;
                player.Dexterity -= 1;
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Вы успешно продали 1 ед. ловкости. Вы получили 20 очков");
                await CharacterCreationService.CreationStats(botClient, callbackQuery.Message, player);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Еблан у тебя и так 1 ловкость, куда меньше");
            }
            return player;
        }

        public static async Task<Player> SellInteligence(ITelegramBotClient botClient, CallbackQuery callbackQuery, Player player)
        {
            if (player.Inteligence > 1)
            {
                player.Points += 20;
                player.Inteligence -= 1;
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Вы успешно продали 1 ед. интеллекта. Вы получили 20 очков");
                await CharacterCreationService.CreationStats(botClient, callbackQuery.Message, player);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Еблан у тебя и так 1 интеллект, куда меньше тупень ёбаный");
            }
            return player;
        }

        public static async Task<Player> SellHealth(ITelegramBotClient botClient, CallbackQuery callbackQuery, Player player)
        {
            if (player.Health > 1)
            {
                player.Points += 10;
                player.Health -= 1;
                player.Fatigue -= 1;
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Вы успешно продали 1 ед. живучести, а так же ваша усталость уменьшена на 1 ед. Вы получили 10 очков");
                await CharacterCreationService.CreationStats(botClient, callbackQuery.Message, player);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                    text: "Еблан у тебя и так 1 живучесть, куда меньше");
            }
            return player;
        }

        public static async Task BuySalt(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id, text: "Зачем тебе 1 ед. соли?");
        }
    }
}
