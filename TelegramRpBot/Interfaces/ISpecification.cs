using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramRpBot.Interfaces
{
    public interface ISpecification<T>
        where T : class
    {
        IList<string> Includes { get; }

        IQueryable<T> Apply(IQueryable<T> query);
    }
}
