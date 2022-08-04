using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramRpBot.Entites;
using TelegramRpBot.Interfaces;

namespace TelegramRpBot.Specifications
{
    public class AdvantageByNameSpecification : ISpecification<Advantage>
    {
        private long id;
        private string name;

        public AdvantageByNameSpecification(string name, long id)
        {
            this.name = name;
            this.id = id;
        }

        public IList<string> Includes => null;

        public IQueryable<Advantage> Apply(IQueryable<Advantage> query)
        {
            return query.Where(i => id == i.PlayerId).Where(n => n.Name.ToLower() == name.ToLower());
        }
    }
}
