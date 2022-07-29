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
    public class AddvantegesService
    {
        static Repository<Player> playerRepository = new Repository<Player>();
        static Repository<Advantage> advantageRepository = new Repository<Advantage>();
        static Repository<Disadvantage> disadvantageRepository = new Repository<Disadvantage>();

        public static async Task GetAdvantageOrDisadvantage(ITelegramBotClient botClient, Message message)
        {
            Player player = playerRepository.List().FirstOrDefault(i => i.UserId == message.From.Id);
            Advantage advantage = advantageRepository.List().FirstOrDefault(i => i.PlayerId == message.From.Id);
            Disadvantage disadvantage = disadvantageRepository.List().FirstOrDefault(i => i.PlayerId == message.From.Id);
            string[] splitMessage = message.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch(splitMessage[1].ToLower())
            {
                case "бесстрашие":
                    {
                        if(player.Points >= 2)
                        {
                            advantage.Fearless += 1;
                            player.Points -= 2;
                            await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"Бесстрашие получено");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                        }
                        break;
                    }
                case "гибкость":
                    {
                        if (advantage.Flexibility == 0)
                        {
                            if(player.Points >= 5)
                            {
                                advantage.Flexibility += 1;
                                player.Points -= 5;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Гибкость первого уровня получена");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                        else if(advantage.Flexibility == 1)
                        {
                            if (player.Points >= 15)
                            {
                                advantage.Flexibility += 1;
                                player.Points -= 10;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Гибкость второго уровня получена");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "У тебя гибкость и так максимальная");
                        }

                        break;
                    }

                case "обоюдорукость":
                    {
                        if (advantage.DoubleHand == 0)
                        {
                            if (player.Points >= 5)
                            {
                                advantage.DoubleHand += 1;
                                player.Points -= 5;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Обоюдорукость получена");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "У тебя и так есть обоюдорукость");
                        }
                        break;
                    }
                case "прыгун":
                    {
                        if (advantage.Jumper == 0)
                        {
                            if (player.Points >= 100)
                            {
                                advantage.Jumper += 1;
                                player.Points -= 100;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Прыгун получен");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты уже и так прыгун");
                        }
                        break;
                    }
                case "сорвиголова":
                    {
                        if (advantage.Daredevil == 0)
                        {
                            if (player.Points >= 15)
                            {
                                advantage.Daredevil += 1;
                                player.Points -= 15;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Сорвиголова получен");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты уже и так сорвиголова");
                        }
                        break;
                    }
                case "удача":
                    {
                        if (advantage.Luck == 0)
                        {
                            if (player.Points >= 15)
                            {
                                advantage.Luck += 1;
                                player.Points -= 15;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Удача получена");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                        break;
                    }
                case "эмпатия":
                    {
                        if (advantage.Empathy == 0)
                        {
                            if (player.Points >= 15)
                            {
                                advantage.Empathy += 1;
                                player.Points -= 15;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Эмпатия получена");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "У тебя и так есть эмпатия");
                        }
                        break;
                    }
                case "вспыльчивость":
                    {
                        if (disadvantage.HotTemper == 0)
                        {
                            disadvantage.HotTemper += 1;
                            player.Points += 10;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Вспыльчивость получена");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже вспыльчив");
                        }
                        break;
                    }
                case "жадность":
                    {
                        if (disadvantage.Greed == 0)
                        {
                            disadvantage.Greed += 1;
                            player.Points += 15;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Жадность получена");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "ты и так уже жадный");
                        }
                        break;
                    }
                case "заблуждения":
                    {
                        if (disadvantage.Delusion < 3)
                        {
                            disadvantage.Delusion += 1;
                            player.Points += 5;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Заблуждения получены");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже достаточно заблуждаешься");
                        }
                        break;
                    }
                case "зависть":
                    {
                        if (disadvantage.Envy == 0)
                        {
                            disadvantage.Envy += 1;
                            player.Points += 10;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Зависть получена");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже завистлив");
                        }
                        break;
                    }
                case "законопослушный":
                    {
                        if (disadvantage.LawAbiding == 0)
                        {
                            disadvantage.LawAbiding += 1;
                            player.Points += 10;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Законопослушность приобретена");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже законопослушный");
                        }
                        break;
                    }
                case "импульсивность":
                    {
                        if (disadvantage.Impulsive == 0)
                        {
                            disadvantage.Impulsive += 1;
                            player.Points += 10;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Импульсивность приобретена");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже импульсивный");
                        }
                        break;
                    }
                case "клятва":
                    {
                        if (disadvantage.Oath < 3)
                        {
                            disadvantage.Oath += 1;
                            player.Points += 5;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Клятва приобретена");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже столько клятв отдал, хватит");
                        }
                        break;
                    }
                case "кровожадность":
                    {
                        if (disadvantage.BloodLust == 0)
                        {
                            disadvantage.BloodLust += 1;
                            player.Points += 10;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Кровожадность получена");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже кровожадный");
                        }
                        break;
                    }
                case "любопытство":
                    {
                        if (disadvantage.Curiosity == 0)
                        {
                            disadvantage.Curiosity += 1;
                            player.Points += 5;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Любопытство приобретено");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже любопытный");
                        }
                        break;
                    }
                case "невезение":
                    {
                        if (disadvantage.BadLuck == 0)
                        {
                            disadvantage.BadLuck += 1;
                            player.Points += 10;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Невезение получено");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже невезучий");
                        }
                        break;
                    }
                case "нетерпимость":
                    {
                        if (disadvantage.Intolerance == 0)
                        {
                            disadvantage.Intolerance += 1;
                            player.Points += 1;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Нетерпимость получена");
                        }
                        else if (disadvantage.Intolerance == 1)
                        {
                            disadvantage.Intolerance += 1;
                            player.Points += 4;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Нетерпимость получена");
                        }
                        else if (disadvantage.Intolerance == 2)
                        {
                            disadvantage.Intolerance += 1;
                            player.Points += 5;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Нетерпимость получена ");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже достаточно нетерпимый");
                        }
                        break;
                    }
                case "пацифизм":
                    {
                        if (disadvantage.Pacifism < 2)
                        {
                            disadvantage.Pacifism += 1;
                            player.Points += 5;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Пацифизм получен");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже пацифист");
                        }
                        break;
                    }
                case "правдивость":
                    {
                        if (disadvantage.Truthfullness == 0)
                        {
                            disadvantage.Truthfullness += 1;
                            player.Points += 5;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Правдивость получена");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "На земле и так уже нету более правдивого человека, чем ты, куда больше");
                        }
                        break;
                    }
                case "прожорливость":
                    {
                        if (disadvantage.Gluttony == 0)
                        {
                            disadvantage.Gluttony += 1;
                            player.Points += 5;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Прожорливость получена");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже прожорлив");
                        }
                        break;
                    }
                case "развратность":
                    {
                        if (disadvantage.Depravity == 0)
                        {
                            disadvantage.Depravity += 1;
                            player.Points += 15;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Развратность получена");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Извращенец блять");
                        }
                        break;
                    }
                case "самоуверенность":
                    {
                        if (disadvantage.SelfConfidence == 0)
                        {
                            disadvantage.SelfConfidence += 1;
                            player.Points += 5;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Самоуверенность получена");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже самоуверенный");
                        }
                        break;
                    }
                case "тугоухость":
                    {
                        if (disadvantage.BadHearing == 0)
                        {
                            disadvantage.BadHearing += 1;
                            player.Points += 10;
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Тугоухость получена");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так глухой");
                        }
                        break;
                    }
                case "боевые":
                    {
                        if (splitMessage[2].ToLower() == "рефлексы")
                        {
                            if (advantage.BattleReflex == 0)
                            {
                                if (player.Points >= 15)
                                {
                                    advantage.BattleReflex += 1;
                                    player.Points -= 15;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Боевые рефлексы получены");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "У тебя и так уже есть боевые рефлексы");
                            }
                        }
                        break;
                    }
                case "высокий":
                    {
                        if (splitMessage[2].ToLower() == "болевой" && splitMessage[3].ToLower() == "порог")
                        {
                            if (advantage.PainThreshold == 0)
                            {
                                if (player.Points >= 10)
                                {
                                    advantage.PainThreshold += 1;
                                    player.Points -= 10;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Высокий болевой порог получен");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "У тебя и так высокий болевой порог");
                            }
                        }
                        break;
                    }
                case "мягкое":
                    {
                        if (splitMessage[2].ToLower() == "падение")
                        {
                            if (advantage.SoftFall == 0)
                            {
                                if (player.Points >= 10)
                                {
                                    advantage.SoftFall += 1;
                                    player.Points -= 10;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Мягкое падение получено");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так мягко падаешь");
                            }
                        }
                        break;
                    }
                case "ночное":
                    {
                        if (splitMessage[2].ToLower() == "видение")
                        {
                            if (advantage.NightVision < 9)
                            {
                                if (player.Points >= 1)
                                {
                                    advantage.NightVision += 1;
                                    player.Points -= 1;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ночное зрение получено");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже ахуеть видишь");
                            }
                        }
                        break;
                    }
                case "обострённый":
                    {
                        if (splitMessage[2].ToLower() == "слух")
                        {
                            if (player.Points >= 2)
                            {
                                advantage.AcuteHearing += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Обострённый слух получен");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                        else if (splitMessage[2].ToLower() == "вкус")
                        {
                            if (player.Points >= 2)
                            {
                                advantage.AcuteTaste += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Обострённый вкус и обаяние получены");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                        else if (splitMessage[2].ToLower() == "осязание")
                        {
                            if (player.Points >= 2)
                            {
                                advantage.AcuteSenseOfTouch += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Обострённое осязание получено");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                        else if (splitMessage[2].ToLower() == "зрение")
                        {
                            if (player.Points >= 2)
                            {
                                advantage.AcuteVision += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Обострённое зрение получено");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                        break;
                    }
                case "полная":
                    {
                        if (splitMessage[2].ToLower() == "устойчивость")
                        {
                            if (advantage.FullStability == 0)
                            {
                                if (player.Points >= 15)
                                {
                                    advantage.FullStability += 1;
                                    player.Points -= 15;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Полная устойчивость получена");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так уже полностью устойчивый");
                            }
                        }
                        break;
                    }
                case "понимание":
                    {
                        if (splitMessage[2].ToLower() == "животных")
                        {
                            if (advantage.UnderstandingAnimals == 0)
                            {
                                if (player.Points >= 5)
                                {
                                    advantage.UnderstandingAnimals += 1;
                                    player.Points -= 5;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Понимание животных получено");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так как животное");
                            }
                        }
                        break;
                    }
                case "талант":
                    {
                        if (splitMessage[2].ToLower() == "к" && splitMessage[3].ToLower() == "языкам")
                        {
                            if (advantage.LanguageTalant == 0)
                            {
                                if (player.Points >= 10)
                                {
                                    advantage.LanguageTalant += 1;
                                    player.Points -= 10;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Талант к языкам получен");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так талант");
                            }
                        }
                        break;
                    }
                case "трудно":
                    {
                        if (splitMessage[2].ToLower() == "убить")
                        {
                            if (player.Points >= 2)
                            {
                                advantage.HardToKill += 1;
                                player.Points -= 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Теперь вас сложнее убить");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                            }
                        }
                        break;
                    }
                case "увеличенное":
                    {
                        if (splitMessage[2].ToLower() == "блокирование")
                        {
                            if (advantage.MoreDeffence == 0)
                            {
                                if (player.Points >= 5)
                                {
                                    advantage.MoreDeffence += 1;
                                    player.Points -= 5;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Увеличенное блокирование получено");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так увеличенно блокируешь");
                            }
                        }
                        else if (splitMessage[2].ToLower() == "уклонение")
                        {
                            if (advantage.MoreDodge == 0)
                            {
                                if (player.Points >= 15)
                                {
                                    advantage.MoreDodge += 1;
                                    player.Points -= 15;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Увеличенное уклонение получено");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так увеличенно уклоняешься");
                            }
                        }
                        else if (splitMessage[2].ToLower() == "парирование")
                        {
                            if (advantage.MoreParry == 0)
                            {
                                if (player.Points >= 10)
                                {
                                    advantage.MoreParry += 1;
                                    player.Points -= 10;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Увеличенное парирование получено");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так увеличенно парируешь");
                            }
                        }
                        break;
                    }
                case "крутая":
                    {
                        if (splitMessage[2].ToLower() == "удача")
                        {
                            if (advantage.Luck == 1)
                            {
                                if (player.Points >= 15)
                                {
                                    advantage.Luck += 1;
                                    player.Points -= 15;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Крутая удача получена");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                        }
                        break;
                    }
                case "ахуеть":
                    {
                        if (splitMessage[2].ToLower() == "какая" && splitMessage[3].ToLower() == "крутая" && splitMessage[4].ToLower() == "удача")
                        {
                            if (advantage.Luck == 2)
                            {
                                if (player.Points >= 30)
                                {
                                    advantage.Luck += 1;
                                    player.Points -= 30;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ахуеть какая крутая удача получена");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты максимально удачлив, пойди купи лотерейный билет");
                            }
                        }
                        break;
                    }
                case "чувство":
                    {
                        if (splitMessage[2].ToLower() == "опасности")
                        {
                            if (advantage.DangerSence == 0)
                            {
                                if (player.Points >= 15)
                                {
                                    advantage.DangerSence += 1;
                                    player.Points -= 15;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Чувство опасности получено");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Ты и так чувствуешь опасность");
                            }
                        }
                        else if (splitMessage[2].ToLower() == "долга")
                        {
                            if (disadvantage.SenseOfDuty == 0)
                            {
                                disadvantage.SenseOfDuty += 1;
                                player.Points += 2;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Чувство долга получено");
                            }
                            else if (disadvantage.SenseOfDuty == 1)
                            {
                                disadvantage.SenseOfDuty += 1;
                                player.Points += 3;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Чувство долга получено");
                            }
                            else if (disadvantage.SenseOfDuty < 5)
                            {
                                disadvantage.SenseOfDuty += 1;
                                player.Points += 5;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Чувство долга получено");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Кому ты ещё не должен?");
                            }
                        }
                        break;
                    }
                case "кодекс":
                    {
                        if (splitMessage[2].ToLower() == "чести")
                        {
                            if (disadvantage.CodeOfHonor < 3)
                            {
                                disadvantage.CodeOfHonor += 1;
                                player.Points += 5;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Кодекс чести получен");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "У тебя и так слишком много чести");
                            }
                        }
                        break;
                    }
                case "навязчивая":
                    {
                        if (splitMessage[2].ToLower() == "идея")
                        {
                            if (disadvantage.Obsession < 2)
                            {
                                disadvantage.Obsession += 1;
                                player.Points += 5;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Навязчивая идея получена");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "У тебя и так слишком много идей");
                            }
                        }
                        break;
                    }
                case "слабое":
                    {
                        if (splitMessage[2].ToLower() == "зрение")
                        {
                            if (disadvantage.BadVision == 0)
                            {
                                disadvantage.BadVision += 1;
                                player.Points += 25;
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Слабое зрение получено");
                            }
                            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "У тебя и так зрение -20");
                        }
                        break;
                    }
                case "острые":
                    {
                        if (splitMessage[2].ToLower() == "когти")
                        {
                            if (advantage.Claws == 0)
                            {
                                if (player.Points >= 5)
                                {
                                    advantage.Claws += 1;
                                    player.Points -= 5;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Острые когти получены");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "У тебя и так отсрые когти");
                            }
                        }
                        else if (splitMessage[2].ToLower() == "зубы")
                        {
                            if (advantage.SharpTeeth == 0)
                            {
                                if (player.Points >= 1)
                                {
                                    advantage.SharpTeeth += 1;
                                    player.Points -= 1;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Острые зубы получены");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "У тебя и так острые зубы");
                            }
                        }
                        else if (splitMessage[2].ToLower() == "клыки")
                        {
                            if (advantage.Fangs == 0)
                            {
                                if (player.Points >= 2)
                                {
                                    advantage.Fangs += 1;
                                    player.Points -= 2;
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Острые клыки получены");
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Не хватает очков");
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "У тебя и так острые клыки");
                            }
                        }
                        break;
                    }

                }

            advantageRepository.Update(advantage);
            disadvantageRepository.Update(disadvantage);
            playerRepository.Update(player);
        }

        public static async Task SendAllAdvantages(ITelegramBotClient botClient, long messageId)
        {
            await botClient.SendTextMessageAsync(chatId: messageId,
                text: "Преимущества:\n\n\n\nБесстрашие (2 очка за уровень)\nВас очень тяжело запугать! " +
                "Добавляйте ваш уровень бесстрашия к вашей Воле каждый"
                + " раз когда вы делаете бросок страха или должны сопротивляться запугиванию и сверхъестестенным силам, вызывающим страх."
                + " Вы также вычитаете ваш уровень Бесстрашия из всех бросков запугивания направленных против вас\n\n"
                + "Боевые рефлексы (15 очков)\nУ вас экстаординарная реакция и вы быстро приходите в себя при неожиданном нападении. "
                + "Вы получаете бонус +1 на любую активную защиту и +2 на все броски страха. Вы никогда не замираете в неожиданной ситуации"
                + "и получаете +6 на все броски ИН, чтобы очнуться или прийти в себя после оглушения\n\n"
                + "Высокий болевой порог (10 очков)\nВы никогда не испытываете шока, если вас ударили во время боя. Так же вы получаете " +
                "+3 на все броски живучести когда вас сбивают с ног или оглушают, либо когда вас пытают у вас +3 на бросок живучести, чтобы выдержать боль\n\n" +
                "Гибкость (5 или 15 очков)\nВы получаете +3 к на броски лазанья или побега, когда освобождаетесь от наручников. " +
                "Так же вы игнорируете штраф до -3 за работу в узком пространстве. За 15 очков тоже самое, но вместо 3 везде 5\n\n" +
                "Мягкое падение (10 очков)\nВы вычитаете из высоты падения 2 метра (автоматический успех умения Акробатика), так же " +
                "успешный бросок на ловкость уменьшит вдвое урон от падения (ваши конечести не должны быть связаны)\n\n" +
                "Ночное виденье (1 очко за уровень (максимум 9))\nПозволяет во время сражения или при проверке зрения игнорировать" +
                " штраф -1 (за каждый уровень) в темноте\n\n" +
                "Обострённые чувства (2 очка за уровень)\nЭто 4 разных преимущества: слух, вкус и обаяние, осязание, зрение. " +
                "Даёт +1 за каждый уровень на все броски чувств\n\n" +
                "Обоюдорукость (5 очков)\nИгнорирует штраф -4 при использовании не основной руки\n\n" +
                "Полная устойчиовсть (15 очков)\nУ вас нету проблем с сохранением баланса. Вы не делаете бросок на ловкость при ходьбе по " +
                "сухим узким поверхностям. Если поверхность мокрая или скользкая, то вы получаете +6 на бросок ловкости, чтобы сохранить баланс. " +
                "В бою вы получаете +4 во всех попытках сохранить устойчивость. Так же добавляет +1 к умениям акробатика и лазанье\n\n" +
                "Понимание животных (5 очков)\nМастер игры делает проверку на интеллект каждый раз, когда вы встречаете животное, и " +
                "говорит вам эмоциональное состояние животного, так же вы можете применять влияние на животных так же как и на людей\n\n" +
                "Прыгун (100 очков)\nВы можете прыгать во времени или в параллельные миры (за остальной информацией к илле, мне впадлу расписывать)\n\n" +
                "Сорвиголова (15 очков)\nКаждый раз когда вы необоснованно рискуете (по мнению мастера) вы получаете +1 ко всем умениям. " +
                "Так же вы можете перебросить кубики 1 раз при критическом провале, который произошёл во время вашей рискованной выходке\n\n" +
                "Талант к языкам (10 очков)\nВы бесплатно изучаете уровень владением языка, но если вы уже знаете этот язык хоть на каком-то уровне" +
                ", если вы его не знаете то надо платить");
            await botClient.SendTextMessageAsync(chatId: messageId,
                text: "Трудно убить (2 очка за уровень)\nВы получаете +1 за уровень при проверке на живучесть, когда провал означает смерть. " +
                "Если этот бонус делает из провального броска успешный, то вы теряете сознание\n\n" +
                "Увеличенное блокирование (5 очков)\nВы получаете +1 к значению блока при использовании умения щит\n\n" +
                "Увеличенное уклонение (15 очков)\nВы получаете +1 к значению уклонения\n\n" +
                "Увеличенное парирование (10 очков)\nВы получаете +1 к значению парирования\n\n" +
                "Удача (15 очков)\nКаждый 3 ролл вы можете перебросить 1 кубик и выбрать результат\n\n" +
                "Крутая удача (30 очков)\nКаждый 2 ролл вы можете перебросить 1 кубик и выбрать результат\n\n" +
                "Ахуеть какая крутая удача (60 очков)\nКаждый ролл вы можете перебросить 1 кубик и выбрать результат\n\n" +
                "Сопротивление яду (5 очков)\nВы получаете бонус +3 к сопротивлению яду\n\n" +
                "Сопротивление болезням (3 очка или 5 очков)\nВы получаете бонус +3 (за 3 очка) или бонус +8 (за 5 очков) при сопротивлении болезням\n\n" +
                "Чувство опасноти (15 очков)\nМастер тайно от вас кидает кубики на ваше восприятие, при успешном броске мастер говорит " +
                "вам о надвигающейся опасноти\n\n" +
                "Эмпатия (15 очков)\nКогда вы впервые встречаете НПС, вы можете попросить мастера сделать бросок на ваш интеллект и сказать, " +
                "что вы чувствуете на счёт этого человека. Если бросок провалился, то мастер скажет неправду\n\n" +
                "Сопротивление поврежденям (5 очков за уровень)\nУвеличивает сп 1 за уровень (максимум 3)\n\n" +
                "Острые когти (5 очков)\nУ вас острые когти. Урон как у кулака, но тип урона режущий\n\n" +
                "Острые зубы (1 очко)\nМожете кусаться\n\n" +
                "Острые клыки (2 очка)\nИми тоже можно кусаться, но больнее");
        }

        public static async Task SendAllDisadvantages(ITelegramBotClient botClient, long messageId)
        {
            await botClient.SendTextMessageAsync(chatId: messageId,
                text: "Недостатки:\n\n\n\nВспыльчивость (-10 очков)\nБросайте на самоконтроль в любой стрессовой ситуации. При провале вы оскорбляете, " +
                "нападаете, или иным способом начинаете дейстсовать против источника стресса\n\n" +
                "Жадность (-15 очков)\nКаждый раз когда вам предлагают награду, когда видите приманку или просто видите деньги, " +
                "сделайте проверку самоконтроля. В случае провала вы сделаете всё возможно, чтобы получить эти деньги\n\n" +
                "Заблуждение (-5, -10, -15 очков)\nВы сильно верите во что-то ненастоящее (и должны это отыгрывать). Незначительное: " +
                "ваше поведение вызывает вопросы у окружающих (-1 к отношению окружающих к вам). Значительное: ваше поведение " +
                "вызывает серьёзные вопросы у окружающих (-2 к отношению окружающих к вам). Серьёзное: окружающие боятся и жалеют вас " +
                "(-3 к отношению окружающих к вам)\n\n" +
                "Зависть (-10 очков)\nВы завидуете тем кто сильнее, умнее или богаче вас. Вы выступаете против любого плана представленного " +
                "тем, кому вы завидуете\n\n" +
                "Законопослушный (-10 очков)\nВы всегда следуете закону, если вам надо нарушить закон то киньте ролл самоконтроля, " +
                "если провал, то вы не будете нарушать, какие бы ни были последствия. Если вы всё таки нарушили, то киньте кубик ещё раз, " +
                "если провал, то идите сдавайтесь властям\n\n" +
                "Импульсвность (-10 очков)\nВы не любите разговоров, вы всегда сначала действуете, а потом думаете. Когда лучше будет " +
                "подождать, вы бросаете на самоконтроль и в случае провала действуете, какие бы ни были последствия\n\n" +
                "Клятва (-5, -10, -15 очков)\nКакая-то клятва, которую вы дали и не можете нарушить. Обсудите с мастером ценность клятвы\n\n" +
                "Кодекс чести (-5, -10, 15 очков)\nНеформальный кодекс стоит -5, формальный -10, за -15 вы обязаны совершить " +
                "самоубийство в случае нарушения кодекса\n\n" +
                "Кровожадность (-10 очков)\nВы желаете видеть своих врагов мёртвыми. Вы всегда убиваете своих врагов и делаете " +
                "контрольный удар или выстрел, чтобы убедиться, что враг умер. Если вам надо оставить кого-то в живых или просто пройти мимо" +
                ", то делайте бросок на самоконтроль\n\n" +
                "Любопытство (-5 очков)\n Вы очень любопытны и всегда лезете куда не надо (например, а что будет если нажать эту кнопку?). " +
                "Чтобы не делать чего-то любопытного, кидайте на самоконтроль\n\n" +
                "Навязчивая идея (-5, -10 очков)\nВы обязаны сделать какой-то поступок. Когда будет лучше отступиться от этой идеи, " +
                "киньте на самоконтроль. Стоимость обсуждайте с мастером\n\n" +
                "Невезение (-10 очков)\nВы ужасно невезучий. Если с кем-то должно случиться что-то плохое, то это будет с вами. " +
                "Один раз за игру мастер может вмешаться и сделать вам подлянку, например сделать успешный бросок провальным\n\n" +
                "Нетерпимость (-1, -5, -10 очков)\nВы нетерпимы к чему-то: классу, этносу, религии, полу, Стасу. Вы плохо относитесь " +
                "к ненавистному объекту и он относится к вам так же. Стоимость обсуждайте с мастером");

            await botClient.SendTextMessageAsync(chatId: messageId,
                text: "Пацифизм (-5, -10 очков)\nЗа -5 очков: вы получаете -4 к точности против людей, когда ваш удар может убить врага\n" +
                "За -10 очков: вы не можете вступать в бой, пока враг не нанесёт вам серьёзный вред\n\n" +
                "Правдивость (-5 очков)\nВы не любите врать. Делайте бросок самоконтроля, когда нужно смолчать, со штрафом -5 когда " +
                "нужно соврать. Так же у вас -5 к умениям заговаривание зубов и артистизм (когда нужно соврать)\n\n" +
                "Прожорливость (-5 очков)\nВы очень любите хорошую еду и напитки. Сделайте бросок самоконтроля, если нужно устоять " +
                "от вкусной еды или выпивки, в случае провала вы всегда пойдёте и попробуете это, независимо от ситуации\n\n" +
                "Развратность (-15 очков)\nПри каждом более менее продолжительном контакте с существом подходящего пола сделайте " +
                "бросок самоконтроля (со штрафом -5 если объект красивый, или -10 если очень красивый). В случае провала вы " +
                "должны 'наводить мосты', пуская в ход всю свою хитрость и умение\n\n" +
                "Самоуверенность (-5 очков)\nВы слишком уверенны в себе и это надо отыгрывать. Когда мастер считает, что вы действуете слишком " +
                "осторожно, сделайте бросок на самоконтроль. В случае провала вы должны действовать так, словно вы полностью " +
                "контролируете ситуацию. Так же вы получаете +2 реацкии у молодых и наивных людей\n\n" +
                "Слабое зрение (-25 очков)\nВы получаете штраф -6 к броскам умения зрение и -2 к точности\n\n" +
                "Тугоухость (-10 очков)\nУ вас проблемы со слухом. Вы получаете штраф -4 к любому броску слуха\n\n" +
                "Фобии (цену и последствия обсуждайте с иллёй и вовой)\n\n" +
                "Чувство долга (-2, -5, -10, -15, -20 очков\nВы чувствуете серьёзные обязательства по отношению к кому-то. " +
                "Цену обсуждайте с мастером\n\n" +
                "Сонливость (-8 очков)\nВы любите поспать");
        }
    }
}
