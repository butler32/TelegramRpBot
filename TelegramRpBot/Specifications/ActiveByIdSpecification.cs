using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramRpBot.Entites;
using TelegramRpBot.Interfaces;

namespace TelegramRpBot.Specifications
{
    class ActiveByIdSpecification : ISpecification<Active>
    {
        private long id;

        public ActiveByIdSpecification(long id)
        {
            this.id = id;
        }

        public IList<string> Includes => null;

        public IQueryable<Active> Apply(IQueryable<Active> query)
        {
            return query.Where(i => i.PlayerId == id);
        }
    }
}
