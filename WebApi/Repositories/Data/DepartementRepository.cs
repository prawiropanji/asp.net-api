using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories.Data
{
    public class DepartementRepository : IRepository<Departement, int>
    {
        private readonly MyContext _myContext;

        public DepartementRepository(MyContext myContext)
        {

            _myContext = myContext;
        }

        public IEnumerable<Departement> Get()
        { 
        
            return _myContext.departements.ToList();
        }

        public Departement Get(int id)
        {
            return _myContext.departements.Find(id);
        }

        public int Create(Departement departement)
        {
            _myContext.departements.Add(departement);
            return _myContext.SaveChanges();

        }

        public int Update(Departement departement)
        {
            _myContext.Entry(departement).State = EntityState.Modified;
            return _myContext.SaveChanges();


        }

        public int Delete(int id)
        {
            var departement = _myContext.departements.Find(id);
            if (departement != null)
            {
                _myContext.departements.Remove(departement);
                return _myContext.SaveChanges();
            }

            return 0;
        }
    }
}
