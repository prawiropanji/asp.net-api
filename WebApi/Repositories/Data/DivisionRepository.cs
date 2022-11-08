using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebApi.Context;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories.Data
{
    public class DivisionRepository : GeneralRepository<Division, int>
    {
        private readonly MyContext _myContext;

        public DivisionRepository(MyContext myContext) : base(myContext)
        {
            _myContext = myContext;
        }

        public Division Get(string name)
        {
            return _myContext.divisions.FirstOrDefault(d => d.Name == name);
        }   
    }
}
