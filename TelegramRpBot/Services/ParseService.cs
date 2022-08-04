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
    public class ParseService
    {
        static Repository<Player> playerRepository = new Repository<Player>();

        public static async Task ItemParse(ITelegramBotClient botClient, Message message)
        {
            string[] splitMessage = message.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (splitMessage.Length > 1)
            {
                switch(splitMessage[1].ToLower())
                {
                    case "оружие":
                        {
                            break;
                        }

                    case "броню":
                        {
                            break;
                        }

                    case "предмет":
                        {
                            break;
                        }
                }
            }
        }

        public static async Task AdvantageParse(ITelegramBotClient botClient, Message message)
        {
            Player player = playerRepository.List().FirstOrDefault(i => i.UserId == message.From.Id);

            string[] splitMessage = message.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (splitMessage.Length > 1)
            {
                if (splitMessage[1].ToLower() == "преимущество")
                {
                    player.InputPlayer = (int)PlayerInput.Advantage;
                    playerRepository.Update(player);
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Напишите преимущество\nВ конце напишите вернуться");
                }
                else if (splitMessage[1].ToLower() == "недостаток")
                {
                    player.InputPlayer = (int)PlayerInput.Disadvantage;
                    playerRepository.Update(player);
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Напишите недостаток\nВ конце напишите вернуться");
                }
                else
                {
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Нормально буквы пиши");
                }
            }
        }
    }
}
