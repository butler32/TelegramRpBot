using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramRpBot.Entites
{
    public class Advantage
    {
        public int Id { get; set; }
        public long PlayerId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Level { get; set; }
        public int MaxLevel { get; set; }
    }
}
