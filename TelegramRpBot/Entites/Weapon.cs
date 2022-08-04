using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramRpBot.Entites
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Damage { get; set; }
        public string DamageType { get; set; }
        public string HitType { get; set; }
        public int Price { get; set; }
        public int Strenght { get; set; }
    }
}
