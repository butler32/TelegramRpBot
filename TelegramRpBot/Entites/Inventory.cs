using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramRpBot.Entites
{
    public class Inventory
    {
        public int Id { get; set; }
        public long PlayerId { get; set; }
        public string Weapons { get; set; }
        public string Armor { get; set; }
        public string Potions { get; set; }
        public string Accessory { get; set; }
    }
}
