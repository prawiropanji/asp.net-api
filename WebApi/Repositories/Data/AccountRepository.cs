using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Context;
using WebApi.Models;
using WebAppMVC.Models;

namespace WebApi.Repositories.Data
{
    public class AccountRepository
    {
        private readonly MyContext _myContext;

        public AccountRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public User GetUserDetails(string email)
        {
            return _myContext.Users
                .Include(u => u.Employee)
                .Include(u => u.Role)
                .SingleOrDefault(u => u.Employee.Email == email);

        }

        public User GetUserEmployee(Expression<Func<User, bool>> predicate)
        {
            return _myContext.Users.Include(u => u.Employee).FirstOrDefault(predicate);
        }

        public Employee GetEmployee(string email)
        {
            return _myContext.Employees.SingleOrDefault(e => e.Email == email);
        }




        public int CreateEmployee(string fullName, string email, DateTime birthDate)
        {
            _myContext.Employees.Add(new Employee(0, fullName, email, birthDate));
            return _myContext.SaveChanges();
        }



        public int CreateUser(string password, int employeeId)
        {
            _myContext.Users.Add(new User(0, password, 1, employeeId));
            return _myContext.SaveChanges();
        }


        public int UpdatePassword(User user)
        {
            _myContext.Entry(user).State = EntityState.Modified;
            return _myContext.SaveChanges();

        }






    }

}
