using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using WebApi.Context;
using WebApi.Models;
using WebApi.Repositories.Data;
using WebApi.Utils;
using WebAppMVC.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly MyContext _myContext;
   
        private readonly AccountRepository _repository;
    

        public AccountController(AccountRepository accountRepository)
        {
            _repository = accountRepository;
        }

 
        [HttpPost("Login")]
        public IActionResult Login(RequestLogin requestLogin)
        {


            var user = _repository.GetUserDetails(requestLogin.Email);

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

            var employee = _repository.GetEmployee(requestRegister.Email);

            if (employee == null)
            {
               var result = _repository.CreateEmployee(requestRegister.Fullname, requestRegister.Email, requestRegister.BirthDate);
                if (result > 0)
                {
                    var employeeId = _repository.GetEmployee(requestRegister.Email).Id;
                    var userResult = _repository.CreateUser(Hashing.HashPassword(requestRegister.Password), employeeId);
                 
                    if (userResult > 0)
                    {
                        return Ok(new { message = "register berhasil!", statusCode = 200 });
                    }

                }
            }
            return BadRequest(new { message = "register gagal!", statusCode = 400 });

           
        }

        [HttpPut("Change_Password")]
        public IActionResult ChangePassword(RequestChangePassword requestChangePassword)
        {
            var user = _repository.GetUserEmployee(u => u.Employee.Email.Equals(requestChangePassword.Email));

            if (user != null) {
                if (Hashing.ValidatePassword(requestChangePassword.OldPassword, user.Password))
                {
                    user.Password = Hashing.HashPassword(requestChangePassword.NewPassword);
                    var result = _repository.UpdatePassword(user);
                    if (result > 0)
                    {
                        return Ok(new { message = "Ubah Password berhasil!", statusCode = 200 });
                    }
                }

            }

    
            return BadRequest(new { message = "Ubah Password gagal!", statusCode = 400 });
        }

        [HttpPut("Fogot_Password")]
        public IActionResult ForgotPassword(RequestForgotPassword requestForgotPassword)
        {
            var user = _repository.GetUserEmployee(u => u.Employee.Email == requestForgotPassword.Email && u.Employee.FullName == requestForgotPassword.FullName);

            if (user != null)
            {
                user.Password = Hashing.HashPassword(requestForgotPassword.NewPassword);
                var result = _repository.UpdatePassword(user);
                if (result > 0)
                {
                    return Ok(new { message = "Ubah Password berhasil!", statusCode = 200 });
                }
            }
            return BadRequest(new { message = "Ubah Password gagal!", statusCode = 400 });
        }

        

    }
}
