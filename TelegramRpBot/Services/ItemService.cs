using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramRpBot.Entites;
using TelegramRpBot.Enums;
using TelegramRpBot.Specifications;

namespace TelegramRpBot.Services
{
    public class ItemService
    {
        static Repository<Player> playerRepository = new Repository<Player>();
        static Repository<Item> itemRepository = new Repository<Item>();
        static Repository<Inventory> inventoryRepository = new Repository<Inventory>();
        static Repository<Active> activeRepository = new Repository<Active>();
        static Repository<Potion> potionRepository = new Repository<Potion>();
        static Repository<Weapon> weaponRepository = new Repository<Weapon>();
        static Repository<Armor> armorRepository = new Repository<Armor>();

        public static async Task ChangeActiveSlot(ITelegramBotClient botClient, Message message)
        {
            Inventory inventory = inventoryRepository.Get(new InventoryByIdSpecification(message.From.Id));
            Player player = playerRepository.Get(new PlayerByIdSpecification(message.From.Id));

            string weapons = "";
            string[] weaponsList;
            if (inventory.Weapons == null)
            {
                weapons = "У тебя нету оружия";
            }
            else
            {
                weaponsList = inventory.Weapons.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var weapon in weaponsList)
                {
                    weapons += weapon + "\n";
                }
            }

            player.InputPlayer = (int)PlayerInput.Weapon;
            playerRepository.Update(player);

            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Список твоих оружий:\n{weapons}");
        }

        public static async Task ChangeLeftHand(ITelegramBotClient botClient, Message message)
        {
            var weaponsList = weaponRepository.List();
            Weapon weapon = weaponsList.FirstOrDefault(n => n.Name.ToLower() == message.Text.ToLower());

            if (weapon != null)
            {
                Active active = activeRepository.Get(new ActiveByIdSpecification(message.From.Id));
                active.LeftHand = weapon.Name;
                activeRepository.Update(active);

                Player player = playerRepository.Get(new PlayerByIdSpecification(message.From.Id));
                player.InputPlayer = (int)PlayerInput.NonInput;
                playerRepository.Update(player);

                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Левая рука сменена на {weapon.Name}");
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Введи оружие нормально");
            }
        }

        public static async Task ChangeRightHand(ITelegramBotClient botClient, Message message)
        {
            var weaponsList = weaponRepository.List();
            Weapon weapon = weaponsList.FirstOrDefault(n => n.Name.ToLower() == message.Text.ToLower());

            if (weapon != null)
            {
                Active active = activeRepository.Get(new ActiveByIdSpecification(message.From.Id));
                active.RightHand = weapon.Name;
                activeRepository.Update(active);

                Player player = playerRepository.Get(new PlayerByIdSpecification(message.From.Id));
                player.InputPlayer = (int)PlayerInput.NonInput;
                playerRepository.Update(player);

                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: $"Правая рука сменена на {weapon.Name}");
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: "Введи оружие нормально");
            }
        }

        public static async Task ChangeArmor(ITelegramBotClient botClient, Message message)
        {

        }

        public static async Task AddWeapon(ITelegramBotClient botClient, Message message)
        {

        }

        public static async Task AddArmor(ITelegramBotClient botClient, Message message)
        {

        }

        public static async Task AddItem(ITelegramBotClient botClient, Message message)
        {

        }

        public static async Task AddPotion(ITelegramBotClient botClient, Message message)
        {

        }

        public static async Task CreateWeapon(ITelegramBotClient botClient, Message message)
        {

        }
    }
}
