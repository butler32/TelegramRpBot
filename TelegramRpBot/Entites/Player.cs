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
        public int UserId { get; set; }
        public string CharacterName { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Inteligence { get; set; }
        public int Health { get; set; }
        public int HealthPoints { get; set; }
        public int Fatigue { get; set; }
        public int Points { get; set; }
        public string Race { get; set; }
        public string RaceSpecial { get; set; }
        public int InventoryId { get; set; }
        public int ActiveId { get; set; }
        
    }
}
