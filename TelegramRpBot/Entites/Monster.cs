using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramRpBot.Entites
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sp { get; set; }
        public int Defence { get; set; }
        public string DefenceType { get; set; }
        public string Attack { get; set; }
    }
}
