using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramRpBot.Entites;
using TelegramRpBot.Specifications;

namespace TelegramRpBot.Services
{
    public class AbilityService
    {
        static Repository<Ability> abilityRepository = new Repository<Ability>();
        static Repository<Player> playerRepository = new Repository<Player>();

        public static async Task AbilityUpgrade(ITelegramBotClient botClient, Message message)
        {
            Player player = playerRepository.Get(new PlayerByIdSpecification(message.From.Id));
            Ability ability = abilityRepository.Get(new AbilityByNameSpecification(message.Text, message.From.Id));

            if (ability != null)
            {
                if (ability.Difficulty == "Л")
                {
                    if (ability.Stat == "ЛВ")
                    {
                        if (ability.Level <= player.Dexterity - 1)
                        {
                            ability.Level = player.Dexterity - 1;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 0 очков");
                        }
                        else if (ability.Level == player.Dexterity)
                        {
                            if (player.Points >= 1)
                            {
                                ability.Level += 1;
                                player.Points -= 1;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 1 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level == player.Dexterity + 1)
                        {
                            if (player.Points >= 2)
                            {
                                ability.Level += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 2 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level >= player.Dexterity + 2)
                        {
                            if (player.Points >= (ability.Level - player.Dexterity - 1) * 4)
                            {
                                ability.Level += 1;
                                player.Points -= (ability.Level - player.Dexterity - 1) * 4;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за {(ability.Level - player.Dexterity - 1) * 4} очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                    }
                    else if (ability.Stat == "ИН")
                    {
                        if (ability.Level <= player.Inteligence - 1)
                        {
                            ability.Level = player.Inteligence - 1;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 0 очков");
                        }
                        else if (ability.Level == player.Inteligence)
                        {
                            if (player.Points >= 1)
                            {
                                ability.Level += 1;
                                player.Points -= 1;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 1 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level == player.Inteligence + 1)
                        {
                            if (player.Points >= 2)
                            {
                                ability.Level += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 2 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level >= player.Inteligence + 2)
                        {
                            if (player.Points >= (ability.Level - player.Inteligence - 1) * 4)
                            {
                                ability.Level += 1;
                                player.Points -= (ability.Level - player.Inteligence - 1) * 4;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за {(ability.Level - player.Inteligence - 1) * 4} очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                    }
                    else if (ability.Stat == "ЖВ")
                    {
                        if (ability.Level <= player.Health - 1)
                        {
                            ability.Level = player.Health - 1;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 0 очков");
                        }
                        else if (ability.Level == player.Health)
                        {
                            if (player.Points >= 1)
                            {
                                ability.Level += 1;
                                player.Points -= 1;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 1 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level == player.Health + 1)
                        {
                            if (player.Points >= 2)
                            {
                                ability.Level += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 2 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level >= player.Health + 2)
                        {
                            if (player.Points >= (ability.Level - player.Health - 1) * 4)
                            {
                                ability.Level += 1;
                                player.Points -= (ability.Level - player.Health - 1) * 4;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за {(ability.Level - player.Health - 1) * 4} очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                    }
                }
                else if (ability.Difficulty == "С")
                {
                    if (ability.Stat == "ЛВ")
                    {
                        if (ability.Level <= player.Dexterity - 2)
                        {
                            ability.Level = player.Dexterity - 2;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 0 очков");
                        }
                        else if (ability.Level == player.Dexterity - 1)
                        {
                            if (player.Points >= 1)
                            {
                                ability.Level += 1;
                                player.Points -= 1;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 1 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level == player.Dexterity)
                        {
                            if (player.Points >= 2)
                            {
                                ability.Level += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 2 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level >= player.Dexterity + 1)
                        {
                            if (player.Points >= (ability.Level - player.Dexterity) * 4)
                            {
                                ability.Level += 1;
                                player.Points -= (ability.Level - player.Dexterity) * 4;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за {(ability.Level - player.Dexterity) * 4} очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                    }
                    else if (ability.Stat == "ИН")
                    {
                        if (ability.Level <= player.Inteligence - 2)
                        {
                            ability.Level = player.Inteligence - 2;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 0 очков");
                        }
                        else if (ability.Level == player.Inteligence)
                        {
                            if (player.Points >= 1)
                            {
                                ability.Level += 1;
                                player.Points -= 1;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 1 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level == player.Inteligence)
                        {
                            if (player.Points >= 2)
                            {
                                ability.Level += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 2 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level >= player.Inteligence + 1)
                        {
                            if (player.Points >= (ability.Level - player.Inteligence) * 4)
                            {
                                ability.Level += 1;
                                player.Points -= (ability.Level - player.Inteligence) * 4;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за {(ability.Level - player.Inteligence) * 4} очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                    }
                    else if (ability.Stat == "ЖВ")
                    {
                        if (ability.Level <= player.Health - 2)
                        {
                            ability.Level = player.Health - 2;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 0 очков");
                        }
                        else if (ability.Level == player.Health - 1)
                        {
                            if (player.Points >= 1)
                            {
                                ability.Level += 1;
                                player.Points -= 1;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 1 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level == player.Health)
                        {
                            if (player.Points >= 2)
                            {
                                ability.Level += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 2 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level >= player.Health + 1)
                        {
                            if (player.Points >= (ability.Level - player.Health) * 4)
                            {
                                ability.Level += 1;
                                player.Points -= (ability.Level - player.Health) * 4;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за {(ability.Level - player.Health) * 4} очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                    }
                }
                else if (ability.Difficulty == "Т")
                {
                    if (ability.Stat == "ЛВ")
                    {
                        if (ability.Level <= player.Dexterity - 3)
                        {
                            ability.Level = player.Dexterity - 3;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 0 очков");
                        }
                        else if (ability.Level == player.Dexterity - 2)
                        {
                            if (player.Points >= 1)
                            {
                                ability.Level += 1;
                                player.Points -= 1;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 1 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level == player.Dexterity - 1)
                        {
                            if (player.Points >= 2)
                            {
                                ability.Level += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 2 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level >= player.Dexterity)
                        {
                            if (player.Points >= (ability.Level - player.Dexterity + 1) * 4)
                            {
                                ability.Level += 1;
                                player.Points -= (ability.Level - player.Dexterity + 1) * 4;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за {(ability.Level - player.Dexterity + 1) * 4} очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                    }
                    else if (ability.Stat == "ИН")
                    {
                        if (ability.Level <= player.Inteligence - 3)
                        {
                            ability.Level = player.Inteligence - 3;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 0 очков");
                        }
                        else if (ability.Level == player.Inteligence - 2)
                        {
                            if (player.Points >= 1)
                            {
                                ability.Level += 1;
                                player.Points -= 1;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 1 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level == player.Inteligence - 1)
                        {
                            if (player.Points >= 2)
                            {
                                ability.Level += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 2 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level >= player.Inteligence)
                        {
                            if (player.Points >= (ability.Level - player.Inteligence + 1) * 4)
                            {
                                ability.Level += 1;
                                player.Points -= (ability.Level - player.Inteligence + 1) * 4;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за {(ability.Level - player.Inteligence + 1) * 4} очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                    }
                    else if (ability.Stat == "ЖВ")
                    {
                        if (ability.Level <= player.Health - 3)
                        {
                            ability.Level = player.Health - 3;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 0 очков");
                        }
                        else if (ability.Level == player.Health - 2)
                        {
                            if (player.Points >= 1)
                            {
                                ability.Level += 1;
                                player.Points -= 1;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 1 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level == player.Health - 1)
                        {
                            if (player.Points >= 2)
                            {
                                ability.Level += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за 2 очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Не хватает очков");
                            }
                        }
                        else if (ability.Level >= player.Health)
                        {
                            if (player.Points >= (ability.Level - player.Health + 1) * 4)
                            {
                                ability.Level += 1;
                                player.Points -= (ability.Level - player.Health + 1) * 4;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Умение {ability.Name} улучшено до {ability.Level} за {(ability.Level - player.Health + 1) * 4} очков");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                    }
                }

                playerRepository.Update(player);
                abilityRepository.Update(ability);
            }
        }

        public static async Task AbilityCheck(ITelegramBotClient botClient, Message message)
        {
            Player player = playerRepository.Get(new PlayerByIdSpecification(message.From.Id));
            IEnumerable<Ability> abilitiesList = abilityRepository.List().Where(i => i.PlayerId == player.UserId);
            Random random = new Random();
            int num1;
            int num2;
            int num3;

            string[] splitMessage = message.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            num1 = random.Next(1, 6);
            num2 = random.Next(1, 6);
            num3 = random.Next(1, 6);

            int bonus;

            bonus = 0;

            if (splitMessage.Length == 3)
            {
                bool isBonus = int.TryParse(splitMessage[2], out bonus);
            }
            if (splitMessage.Length == 4)
            {
                bool isBonus = int.TryParse(splitMessage[3], out bonus);
            }

            if (num1 + num2 + num3 <= 4)
            {
                if (player.Id == 885877113)
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Выпало {num2 + num1 + num3} - критический успех\n\n\n\n\n\n\n\nгиена ебаная");
                else
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Выпало {num2 + num1 + num3} - критический успех!");
            }
            else if (num1 + num2 + num3 >= 17)
            {
                if (player.Id == 885877113)
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Выпало {num2 + num1 + num3} - кричический провал/АХАХАХА СОСИ ЛОХ");
                else
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Выпало {num2 + num1 + num3} - критический провал!");
            }

            if (splitMessage[1].ToLower() == "силы")
            {
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Выпало {num2} + {num1} + {num3} + {bonus} = {num1 + num2 + num3} против {player.Strength + bonus} силы");
                
            }
            else if (splitMessage[1].ToLower() == "ловкости")
            {
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Выпало {num2} + {num1} + {num3} + {bonus} = {num1 + num2 + num3} против {player.Dexterity + bonus} ловкости");
                
            }
            else if (splitMessage[1].ToLower() == "интеллекта")
            {
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Выпало {num2} + {num1} + {num3} + {bonus} = {num1 + num2 + num3} против {player.Inteligence + bonus} интеллекта");
                
            }
            else if (splitMessage[1].ToLower() == "живучести")
            {
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Выпало {num2} + {num1} + {num3} + {bonus} = {num1 + num2 + num3} против {player.Health + bonus} живучести");
                
            }
            else if (splitMessage[1].ToLower() == "самоконтроля")
            {
                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Выпало {num2} + {num1} + {num3} + {bonus} = {num1 + num2 + num3} против {12 + bonus} самоконтроля");
                
            }
            else
            {
                Ability ability = abilitiesList.FirstOrDefault(n => n.Name.ToLower().StartsWith(splitMessage[1].ToLower()));

                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Выпало {num2} + {num1} + {num3} + {bonus} = {num1 + num2 + num3} против {ability.Level + bonus} уровня умения");
                
            }
        }
    }
}
