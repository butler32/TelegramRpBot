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
        static Repository<Advantage> advantageRepository = new Repository<Advantage>();
        static Repository<Disadvantage> disadvantageRepository = new Repository<Disadvantage>();
        static Repository<Active> activeRepository = new Repository<Active>();
        static Repository<Inventory> inventoryRepository = new Repository<Inventory>();
        static Repository<Ability> abilityReposiroty = new Repository<Ability>();

        public static async Task CreationMenu(ITelegramBotClient botClient, Message message, Player player)
        {
            IEnumerable<Advantage> advantageList = advantageRepository.List().Where(l => l.Level > 0).Where(i => i.PlayerId == message.From.Id);
            IEnumerable<Disadvantage> disadvantageList = disadvantageRepository.List().Where(l => l.Level > 0).Where(i => i.PlayerId == message.From.Id);
            IEnumerable<Ability> abilitiesList = abilityReposiroty.List().Where(i => i.PlayerId == message.From.Id).Where(l => l.Level > 0);

            string advantages = "Приемущества:\n";
            string disadvantages = "Недостатки:\n";
            string abilities = "Умения:\n";

            if (advantageList != null)
            {
                foreach (var adv in advantageList)
                {
                    advantages += adv.Name + "\n";
                }
            }
            else
            {
                advantages += "Нету";
            }

            if (disadvantageList != null)
            {
                foreach (var dis in disadvantageList)
                {
                    disadvantages += dis.Name + "\n";
                }
            }
            else
            {
                disadvantages += "Нету";
            }

            if(abilitiesList != null)
            {
                foreach (var abil in abilitiesList)
                {
                    abilities += abil.Name + " - " + abil.Level + "\n";
                }
            }
            else
            {
                abilities += "Нету";
            }

            // Player player = playerRepository.List().FirstOrDefault(i => i.UserId == (int)message.From.Id);
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id,
                text: $"Меню.\nИмя персонажа: {player.CharacterName}\nРаса: {player.Race}\nОсобенности расы: {player.RaceSpecial}\n\n" +
                $"{advantages}\n\n{disadvantages}\n\n{abilities}\n\nОчков осталось: {player.Points}",
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
                        player.InputPlayer = (int)PlayerInput.RaceSpecial;
                        playerRepository.Update(player);
                        await botClient.SendTextMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                            text: "Введите особенности расы");
                        break;
                    }

                case "playerCreationCharacterName":
                    {
                        player.InputPlayer = (int)PlayerInput.CharacterName;
                        playerRepository.Update(player);
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

                case "playerCreationStatsBuySalt":
                    {
                        await StatsService.BuySalt(botClient, callbackQuery);
                        break;
                    }

                case "playerCreationResetAll":
                    {
                        player = await CharacterCreationService.ResetAll(botClient, callbackQuery, player);
                        break;
                    }

                case "playerCreationRaceMenu":
                    {
                        player.InputPlayer = (int)PlayerInput.RaceInput;
                        playerRepository.Update(player);
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

        public static async Task AddNewCharacter(ITelegramBotClient botClient, Message message)
        {
            long userId = message.From.Id;

            Player player = playerRepository.Add(new Player
            {
                UserId = userId,
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
                Money = 2000,
                InputPlayer = 0,
            });

            inventoryRepository.Add(new Inventory
            {
                PlayerId = userId,
            });

            activeRepository.Add(new Active
            {
                PlayerId = userId,
            });

            #region Создание преимуществ
            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Бесстрашие",
                Price = 2,
                Level = 0,
                MaxLevel = 1000
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Боевые рефлексы",
                Price = 15,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Высокий болевой порог",
                Price = 10,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Гибкость",
                Price = 5,
                Level = 0,
                MaxLevel = 2
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Мягкое падение",
                Price = 10,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Ночное видение",
                Price = 1,
                Level = 0,
                MaxLevel = 9
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Обострённый слух",
                Price = 2,
                Level = 0,
                MaxLevel = 1000
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Обострённые вкус и обаяние",
                Price = 2,
                Level = 0,
                MaxLevel = 1000
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Обострённое осязание",
                Price = 2,
                Level = 0,
                MaxLevel = 1000
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Острое зрение",
                Price = 2,
                Level = 0,
                MaxLevel = 1000
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Обоюдорукость",
                Price = 5,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Полная устойчивость",
                Price = 15,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Понимание животных",
                Price = 5,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Прыгун",
                Price = 100,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Сорвиголова",
                Price = 15,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Талант к языкам",
                Price = 10,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Трудно убить",
                Price = 2,
                Level = 0,
                MaxLevel = 1000
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Увеличенное блокирование",
                Price = 5,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Увеличенное уклонение",
                Price = 15,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Увеличенное парирование",
                Price = 10,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Удача",
                Price = 15,
                Level = 0,
                MaxLevel = 3
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Сопротивление заболеванию",
                Price = 3,
                Level = 0,
                MaxLevel = 2
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Сопротивление яду",
                Price = 5,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Чувство опасности",
                Price = 15,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Эмпатия",
                Price = 15,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Острые когти",
                Price = 5,
                Level = 0,
                MaxLevel = 1
            });
            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Острые зубы",
                Price = 1,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Острые клыки",
                Price = 2,
                Level = 0,
                MaxLevel = 1
            });

            advantageRepository.Add(new Advantage
            {
                PlayerId = userId,
                Name = "Сопротивление повреждениям",
                Price = 5,
                Level = 0,
                MaxLevel = 3
            });
            #endregion

            #region Создание недостатков

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Вспыльчивость",
                Price = 10,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Жадность",
                Price = 15,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Заблуждения",
                Price = 5,
                Level = 0,
                MaxLevel = 3
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Зависть",
                Price = 10,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Законопослушный",
                Price = 10,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Импульсивность",
                Price = 10,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Клятва",
                Price = 5,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Кодекс чести",
                Price = 5,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Кровожадность",
                Price = 10,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Любопытство",
                Price = 5,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Навязчивая идея",
                Price = 5,
                Level = 0,
                MaxLevel = 2
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Невезение",
                Price = 10,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Нетерпимость",
                Price = 1,
                Level = 0,
                MaxLevel = 10
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Пацифизм",
                Price = 5,
                Level = 0,
                MaxLevel = 2
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Правдивость",
                Price = 5,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Прожорливость",
                Price = 5,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Развратность",
                Price = 15,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Самоуверенность",
                Price = 5,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Слабое зрение",
                Price = 25,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Тугоухость",
                Price = 10,
                Level = 0,
                MaxLevel = 1
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Фобии",
                Price = 1,
                Level = 0,
                MaxLevel = 1000
            });

            disadvantageRepository.Add(new Disadvantage
            {
                PlayerId = userId,
                Name = "Чувство долга",
                Price = 2,
                Level = 0,
                MaxLevel = 5
            });

            #endregion

            #region Создание умений

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Азартные игры",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Акробатика",
                Stat = "ЛВ",
                Difficulty = "Т",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Артистизм",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Верховая езда",
                Stat = "ЛВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Взлом",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Выживание",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Гуманитарные науки",
                Stat = "ИН",
                Difficulty = "Т",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Допрашивание",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Драка",
                Stat = "ЛВ",
                Difficulty = "Л",
                Level = 0,
                Default = false
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Знание местности",
                Stat = "ИН",
                Difficulty = "Л",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Изменение внешности",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Каратэ",
                Stat = "ЛВ",
                Difficulty = "Т",
                Level = 0,
                Default = false
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Карманное воровство",
                Stat = "ЛВ",
                Difficulty = "Т",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Контрабанда",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Лазание",
                Stat = "ЛВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Лидерство",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Ловушки",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Маскировка",
                Stat = "ИН",
                Difficulty = "Л",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Метание",
                Stat = "ЛВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Метание оружия",
                Stat = "ЛВ",
                Difficulty = "Л",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Наблюдатель",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Натуралист",
                Stat = "ИН",
                Difficulty = "Т",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Обращение с животными",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Обыск",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Оккультизм",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Оружейник",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Рапира",
                Stat = "ЛВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Короткий меч",
                Stat = "ЛВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Цеп",
                Stat = "ЛВ",
                Difficulty = "Т",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Топор",
                Stat = "ЛВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Булава",
                Stat = "ЛВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Палаш",
                Stat = "ЛВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Нож",
                Stat = "ЛВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Двуручный меч",
                Stat = "ЛВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Первая помощь",
                Stat = "ИН",
                Difficulty = "Л",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Пирушки",
                Stat = "ЖВ",
                Difficulty = "Л",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Письмо",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Плавание",
                Stat = "ЖВ",
                Difficulty = "Л",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Побег",
                Stat = "ЛВ",
                Difficulty = "Т",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Право",
                Stat = "ИН",
                Difficulty = "Т",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Прыжки",
                Stat = "ЛВ",
                Difficulty = "Л",
                Level = 0,
                Default = false
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Прятанье",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Публичное выступление",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Скрытность",
                Stat = "ЛВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Следопыт",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Слежка",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Собирание",
                Stat = "ИН",
                Difficulty = "Л",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Социальные науки",
                Stat = "ИН",
                Difficulty = "Т",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Духовая трубка",
                Stat = "ЛВ",
                Difficulty = "Т",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Лук",
                Stat = "ЛВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Арбалет",
                Stat = "ЛВ",
                Difficulty = "Л",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Тактика",
                Stat = "ИН",
                Difficulty = "Т",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Торговец",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Ходьба",
                Stat = "ЖВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Щит",
                Stat = "ЛВ",
                Difficulty = "Л",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Дипломатия",
                Stat = "ИН",
                Difficulty = "Т",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Заговаривание зубов",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Запугивание",
                Stat = "ИН",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Хорошие манеры",
                Stat = "ИН",
                Difficulty = "Л",
                Level = 0,
                Default = true
            });

            abilityReposiroty.Add(new Ability
            {
                PlayerId = userId,
                Name = "Сексапильность",
                Stat = "ЖВ",
                Difficulty = "С",
                Level = 0,
                Default = true
            });

            #endregion

            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Персонаж создан");
            await CharacterCreationService.CreationMenu(botClient, message, player);
        }
    }
}
