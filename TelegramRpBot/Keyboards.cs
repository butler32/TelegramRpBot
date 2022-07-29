using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramRpBot
{
    static public class Keyboards
    {
        static public InlineKeyboardMarkup CreationMenuKeyboard = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Статы", "playerCreationStatsMenu"),
                InlineKeyboardButton.WithCallbackData("Раса", "playerCreationRaceMenu")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Особенности расы", "playerCreationRaceSpecial"),
                InlineKeyboardButton.WithCallbackData("Имя персонажа", "playerCreationCharacterName")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Преимущества", "playerCreationPositiveMenu"),
                InlineKeyboardButton.WithCallbackData("Недостатки", "playerCreationNegativeMenu")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Причуды", "playerCreationQuirks"),
                InlineKeyboardButton.WithCallbackData("Навыки", "playerCreationAbilitiesMenu")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Подтвердить", "playerCreationConfirmCharacter"),
                InlineKeyboardButton.WithCallbackData("Отменить всё", "playerCreationResetAll")
            }
        });

        static public InlineKeyboardMarkup CreationStatsShop = new(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Купить силу - 10 очков", "playerCreationStatsBuyStrenght"),
                InlineKeyboardButton.WithCallbackData("Купить живучесть - 10 очков", "playerCreationStatsBuyHealth")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Купить ловкость - 20 очков", "playerCreationStatsBuyDexterity"),
                InlineKeyboardButton.WithCallbackData("Купить интеллект - 20 очков", "playerCreationStatsBuyInteligence")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Продать силу - 10 очков", "playerCreationStatsSellStrenght"),
                InlineKeyboardButton.WithCallbackData("Продать живучесть - 10 очков", "playerCreationStatsSellHealth")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Продать ловкость - 20 очков", "playerCreationStatsSellDexterity"),
                InlineKeyboardButton.WithCallbackData("Продать интеллект - 20 очков", "playerCreationStatsSellInteligence")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Вернуться", "playerCreationStatsBackToMenu")
            }
        });
    }
}
