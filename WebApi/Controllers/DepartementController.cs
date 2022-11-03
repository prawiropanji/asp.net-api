using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : ControllerBase
    {
        private readonly DepartementRepository _repository;
        public DepartementController(DepartementRepository departementRepository)
        {
            _repository = departementRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departements = _repository.Get();
            return Ok(departements);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var departement = _repository.Get(id);
            if (departement != null)
                return Ok(departement);

            return Ok(new { Message = "Data tidak Ditemukan!" });
        }

        [HttpPost]
        public IActionResult Create(Departement departement)
        {
            var data = new Departement(departement.Id, departement.Name, departement.DivisionId);
            var result = _repository.Create(data);
            if (result > 0)
                return Ok(new { Message = "Data Berhasil Disimpan!" });

            return Ok(new { Message = "Data Gagal Disimpan!" });
        }

        [HttpPut]
        public IActionResult Update(Departement departement)
        {

            var result = _repository.Update(departement);
            if (result > 0)
                return Ok(new { Message = "Data Berhasil DiUpdate!" });

            return Ok(new { Message = "Data Gagal DiUpdate!" });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result > 0)
                return Ok(new { Message = "Data Berhasil Dihapus!" });


            return Ok(new { Message = "Data tidak Berhasil DiHapus!" });
        }


    }
}

