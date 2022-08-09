using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramRpBot.Entites;
using TelegramRpBot.Interfaces;

namespace TelegramRpBot.Specifications
{
    class InventoryByIdSpecification : ISpecification<Inventory>
    {
        private long id;

        public InventoryByIdSpecification(long id)
        {
            this.id = id;
        }

        public IList<string> Includes => null;

        public IQueryable<Inventory> Apply(IQueryable<Inventory> query)
        {
            return query.Where(i => i.PlayerId == id);
        }
    }
}
