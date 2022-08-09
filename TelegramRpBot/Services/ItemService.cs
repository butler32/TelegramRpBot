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
    public class ItemService
    {
        static Repository<Player> playerRepository = new Repository<Player>();
        static Repository<Item> itemRepository = new Repository<Item>();
        static Repository<Inventory> inventoryRepository = new Repository<Inventory>();


    }
}
