using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramRpBot.Entites
{
    public class Active
    {
        public int Id { get; set; }
        public long PlayerId { get; set; }
        public string MainHand { get; set; }
        public string LeftHand { get; set; }
        public string RightHand { get; set; }
        public string Armor { get; set; }
    }
}
