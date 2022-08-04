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
    public class MobService
    {
        static Repository<Player> playerRepository = new Repository<Player>();
        static Repository<Monster> monsterRepository = new Repository<Monster>();

        public static async Task AddMob(ITelegramBotClient botClient, Message message)
        {
            Player player = playerRepository.List().FirstOrDefault(i => i.UserId == message.From.Id);

            string[] userMessageSplit = message.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] splitMessage = new string[5];

            if (userMessageSplit.Length == 5)
            {
                splitMessage = userMessageSplit;
            }
            else if (userMessageSplit.Length == 6)
            {
                splitMessage[0] = userMessageSplit[0] + ' ' + userMessageSplit[1];
                splitMessage[1] = userMessageSplit[2];
                splitMessage[2] = userMessageSplit[3];
                splitMessage[3] = userMessageSplit[4];
                splitMessage[4] = userMessageSplit[5];
            }
            else if (userMessageSplit.Length == 7)
            {
                splitMessage[0] = userMessageSplit[0] + ' ' + userMessageSplit[1] + ' ' + userMessageSplit[2];
                splitMessage[1] = userMessageSplit[3];
                splitMessage[2] = userMessageSplit[4];
                splitMessage[3] = userMessageSplit[5];
                splitMessage[4] = userMessageSplit[6];
            }
            else if (userMessageSplit.Length == 8)
            {
                splitMessage[0] = userMessageSplit[0] + ' ' + userMessageSplit[1] + ' ' + userMessageSplit[2] + ' ' + userMessageSplit[3];
                splitMessage[1] = userMessageSplit[4];
                splitMessage[2] = userMessageSplit[5];
                splitMessage[3] = userMessageSplit[6];
                splitMessage[4] = userMessageSplit[7];
            }
            else if (userMessageSplit.Length == 9)
            {
                splitMessage[0] = userMessageSplit[0] + ' ' + userMessageSplit[1] + ' ' + userMessageSplit[2] + ' ' + userMessageSplit[3] + ' ' + userMessageSplit[4];
                splitMessage[1] = userMessageSplit[5];
                splitMessage[2] = userMessageSplit[6];
                splitMessage[3] = userMessageSplit[7];
                splitMessage[4] = userMessageSplit[8];
            }

            if (splitMessage.Length == 5)
            {
                int sp = 0;
                int defence = 0;

                int.TryParse(splitMessage[1], out sp);
                int.TryParse(splitMessage[2], out defence);

                Monster monster = monsterRepository.Add(new Monster
                {
                    Name = splitMessage[0],
                    Sp = sp,
                    Defence = defence,
                    DefenceType = splitMessage[3],
                    Attack = splitMessage[4]
                });
                await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                    text: $"Моб добавлен\nИмя: {monster.Name}\n{monster.DefenceType}: {monster.Defence}\nАтака: {monster.Attack}\nСп: {monster.Sp}");
                player.InputPlayer = (int)PlayerInput.NonInput;
                playerRepository.Update(player);
            }
        }
    }
}
