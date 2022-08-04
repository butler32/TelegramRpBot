using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramRpBot.Entites;
using TelegramRpBot.Interfaces;

namespace TelegramRpBot.Specifications
{
    public class PlayerByIdSpecification : ISpecification<Player>
    {
        private long id;

        public PlayerByIdSpecification(long id)
        {
            this.id = id;
        }

        public IList<string> Includes => null;

        public IQueryable<Player> Apply(IQueryable<Player> query)
        {
            return query.Where(i => i.UserId == id);
        }
    }
}
