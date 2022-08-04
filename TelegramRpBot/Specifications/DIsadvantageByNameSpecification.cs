using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramRpBot.Entites;
using TelegramRpBot.Interfaces;

namespace TelegramRpBot.Specifications
{
    public class DIsadvantageByNameSpecification : ISpecification<Disadvantage>
    {
        private long id;
        private string name;

        public DIsadvantageByNameSpecification(string name, long id)
        {
            this.id = id;
            this.name = name;
        }

        public IList<string> Includes => null;

        public IQueryable<Disadvantage> Apply(IQueryable<Disadvantage> query)
        {
            return query.Where(i => i.PlayerId == id).Where(n => n.Name.ToLower() == name.ToLower());
        }
    }
}
