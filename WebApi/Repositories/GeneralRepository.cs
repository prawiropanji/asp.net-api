using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class GeneralRepository<Entity, Key> : IRepository<Entity, Key>
        where Entity : class
    {

        private readonly MyContext _myContext;

        public GeneralRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public int Create(Entity entity)
        {
            _myContext.Set<Entity>().Add(entity);
            return _myContext.SaveChanges();
        }

        public int Delete(Key id)
        {
            var data = _myContext.Set<Entity>().Find(id);
            _myContext.Set<Entity>().Remove(data);
            var result = _myContext.SaveChanges();
            return result;

        }

        public IEnumerable<Entity> Get()
        {
            return _myContext.Set<Entity>().ToList();
        }

        public Entity Get(Key id)
        {
            return _myContext.Set<Entity>().Find(id);
        }

     

        public int Update(Entity entity)
        {
            _myContext.Entry(entity).State = EntityState.Modified;
            return _myContext.SaveChanges();
        }
    }
}
