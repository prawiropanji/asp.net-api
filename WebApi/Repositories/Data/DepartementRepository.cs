using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories.Data
{
    public class DepartementRepository : GeneralRepository<Departement,int>
    {
        private readonly MyContext _myContext;

        public DepartementRepository(MyContext myContext) : base(myContext)
        {

            _myContext = myContext;
        }

      
    }
}
