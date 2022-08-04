using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramRpBot.Entites
{
    public class Player
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string CharacterName { get; set; }
        public string Race { get; set; }
        public string RaceSpecial { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Inteligence { get; set; }
        public int Health { get; set; }
        public int HealthPoints { get; set; }
        public int Fatigue { get; set; }
        public int Points { get; set; }
        public int Money { get; set; }
        public int InputPlayer { get; set; }
    }
}
