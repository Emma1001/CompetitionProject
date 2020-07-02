using Competition.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Competition.Repositories
{
    public class GenericRepository<T> where T : BaseEntity
    {
        protected ManagerDbContext context { get; set; }
        protected DbSet<T> Items { get; set; }

        public GenericRepository()
        {
            context = new ManagerDbContext();
            Items = context.Set<T>();
        }

        public T GetById(int id)
        {
            return Items
                    .Where(i => i.Id == id)
                    .FirstOrDefault();
        }

        public List<T> GetAll()
        {
            return Items.ToList();
        }


        public void Insert(T item)
        {
            Items.Add(item);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            T item = GetById(id);

            if (item != null)
            {
                Items.Remove(item);
                context.SaveChanges();
            }
        }
        

        public void Update(T item)
        {
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}