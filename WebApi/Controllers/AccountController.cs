using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApi.Context;
using WebApi.Models;
using WebApi.Utils;
using WebAppMVC.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private MyContext _myContext;
        public AccountController(MyContext myContext)
        {
            _myContext = myContext;
        }

        [HttpPost("Login")]
        public IActionResult Login(RequestLogin requestLogin)
        {

            var user = _myContext.Users
                .Include(u => u.Employee)
                .Include(u => u.Role)
                .SingleOrDefault(u => u.Employee.Email == requestLogin.Email);

            if (user != null)
            {
                if (Hashing.ValidatePassword(requestLogin.Password, user.Password))
                {

                    return Ok(
                        new
                        {
                            message = "berhasil login!",
                            statusCode = 200,
                            data = new
                            {
                                id = user.Id,
                                fullname = user.Employee.FullName,
                                email = user.Employee.Email,
                                role = user.Role.Name
                            }
                        });

                }


            }
            

            return BadRequest(new { message = "Login gagal!", statusCode = 400 });

        }

        [HttpPost("Register")]
        public IActionResult Register(RequestRegister requestRegister)
        {
            var user = _myContext.Employees.SingleOrDefault(e => e.Email == requestRegister.Email);
            if (user == null)
            {
                _myContext.Employees.Add(new Employee(0, requestRegister.Fullname, requestRegister.Email, requestRegister.BirthDate));
                var result = _myContext.SaveChanges();
                if (result > 0)
                {
                    var employeeId = _myContext.Employees.SingleOrDefault(e => e.Email == requestRegister.Email).Id;
                    _myContext.Users.Add(new User(0, Hashing.HashPassword(requestRegister.Password), 1, employeeId));
                    var usersResult = _myContext.SaveChanges();
                    if (usersResult > 0)
                    {
                        return Ok(new { message = "register berhasil!", statusCode = 200 });
                    }

                }
            }
            return BadRequest(new { message = "register gagal!", statusCode = 400 });

           
        }

        [HttpPost("Change_Password")]
        public IActionResult ChangePassword(RequestChangePassword requestChangePassword)
        {
            var user = _myContext.Users.Include(u => u.Employee).FirstOrDefault(u => u.Employee.Email.Equals(requestChangePassword.Email));

            if (user != null) {
                if (Hashing.ValidatePassword(requestChangePassword.OldPassword, user.Password))
                {
                    user.Password = Hashing.HashPassword(requestChangePassword.NewPassword);
                    _myContext.Entry(user).State = EntityState.Modified;
                    var result = _myContext.SaveChanges();
                    if (result > 0)
                    {
                        return Ok(new { message = "Ubah Password berhasil!", statusCode = 200 });
                    }
                }

            }

    
            return BadRequest(new { message = "Ubah Password gagal!", statusCode = 400 });
        }

        [HttpPost("Fogot_Password")]
        public IActionResult ForgotPassword(RequestForgotPassword requestForgotPassword)
        {
            var user = _myContext.Users.Include(u => u.Employee).SingleOrDefault(u => u.Employee.Email == requestForgotPassword.Email && u.Employee.FullName == requestForgotPassword.FullName);

            if (user != null)
            {
                user.Password = Hashing.HashPassword(requestForgotPassword.NewPassword);
                _myContext.Entry(user).State = EntityState.Modified;
                var result = _myContext.SaveChanges();
                if (result > 0)
                {
                    return Ok(new { message = "Ubah Password berhasil!", statusCode = 200 });
                }
            }
            return BadRequest(new { message = "Ubah Password gagal!", statusCode = 400 });
        }

        

    }
}
