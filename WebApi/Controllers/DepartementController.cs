using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Base;
using WebApi.Models;
using WebApi.Repositories.Data;

namespace WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : BaseController<DepartementRepository, Departement, int>
    {
        private readonly DepartementRepository _repository;
        public DepartementController(DepartementRepository departementRepository) : base(departementRepository)
        {
            _repository = departementRepository;
        }


    }
}

