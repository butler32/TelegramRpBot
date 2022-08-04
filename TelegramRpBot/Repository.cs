using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TelegramRpBot.Interfaces;

namespace TelegramRpBot
{
    public class Repository<T>
        where T : class
    {
        private readonly BotDbContext context;

        public Repository()
        {
            //this.context = context;
            var optionsBuilder = new DbContextOptionsBuilder<BotDbContext>();
            var options = optionsBuilder
                .UseSqlServer("Server=DESKTOP-I1FC7CO;Database=RPBotDb;Trusted_Connection=True;Encrypt=False;")
                .Options;
            context = new BotDbContext(options);
        }
        
        public T Add (T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();

            context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;

            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.ChangeTracker.Clear();
            context.Update(entity);
            context.SaveChanges();
        }

        public T Get(int id)
        {
            var entity = context.Set<T>().Find(id);

            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public IList<T> List()
        {
            return context.Set<T>().AsNoTracking().ToList();
        }

        public T Get(ISpecification<T> specification)
        {
            return ApplySpecification(context.Set<T>(), specification).FirstOrDefault();
        }

        private IQueryable<T> ApplySpecification(IQueryable<T> source, ISpecification<T> specification)
        {
            var result = specification.Apply(source);

            if (specification.Includes != null)
            {
                foreach (var include in specification.Includes)
                {
                    result = result.Include(include);
                }
            }

            return result.AsNoTracking();
        }
    }
}
