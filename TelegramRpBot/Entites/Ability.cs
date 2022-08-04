using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramRpBot.Entites
{
    public class Ability
    {
        public int Id { get; set; }
        public long PlayerId { get; set; }
        public string Name { get; set; }
        public string Stat { get; set; }
        public string Difficulty { get; set; }
        public int Level { get; set; }
        public bool Default { get; set; }

    }
}
