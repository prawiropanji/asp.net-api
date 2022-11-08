using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebApi.Base;
using WebApi.Models;
using WebApi.Repositories.Data;

namespace WebApi.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : BaseController<DivisionRepository, Division, int>
    {
        private readonly DivisionRepository _repository;
        public DivisionController(DivisionRepository divisionRepository) :base(divisionRepository)
        {
            _repository = divisionRepository;
        }



    }
}
