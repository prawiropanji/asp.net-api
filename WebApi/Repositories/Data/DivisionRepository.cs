using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebApi.Context;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories.Data
{
    public class DivisionRepository : IRepository<Division, int>
    {
        private readonly MyContext _myContext;

        public DivisionRepository(MyContext myContext)
        {

            _myContext = myContext;
        }

        public IEnumerable<Division> Get()
        {

            return _myContext.divisions.ToList();
        }

        public Division Get(int id)
        {
            return _myContext.divisions.Find(id);
        }

        public int Create(Division division)
        {
            _myContext.divisions.Add(division);
            return _myContext.SaveChanges();

        }

        public int Update(Division division)
        {
            _myContext.Entry(division).State = EntityState.Modified;
            return _myContext.SaveChanges();


        }

        public int Delete(int id)
        {
            var division = _myContext.divisions.Find(id);
            if (division != null)
            {
                _myContext.divisions.Remove(division);
                return _myContext.SaveChanges();
            }

            return 0;
        }
    }
}
