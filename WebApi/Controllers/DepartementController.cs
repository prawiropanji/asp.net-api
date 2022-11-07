using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories.Data;

namespace WebApi.Controllers
{
    [Authorize]
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
            try
            {
                var departements = _repository.Get();
                if (departements != null)
                    return Ok(new { statusCode = 200, message = "Data ditemukan!", data = departements });
                return StatusCode(204, new { statusCode = 204, message = "Data tidak ada!" });

            }
            catch (Exception e)
            {
                return StatusCode(500, new { statusCode = 500, message = e.Message });
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var departement = _repository.Get(id);
                if (departement != null)
                    return Ok(new { statusCode = 200, message = "Data ditemukan!", data = departement });

                return StatusCode(204, new { statusCode = 204, message = "Data tidak Ditemukan!" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { statusCode = 500, message = e.Message });
            }

        }

        [HttpPost]
        public IActionResult Create(Departement departement)
        {
            try
            {
                var data = new Departement(departement.Id, departement.Name, departement.DivisionId);
                var result = _repository.Create(data);
                if (result > 0)
                    return Ok(new { statusCode = 200, message = "Data Berhasil Disimpan!" });

                return BadRequest(new { statusCode = 400, message = "Data Gagal Disimpan!" });
            }
            catch (Exception e)
            {

                return StatusCode(500, new { statusCode = 500, message = e.Message });
            }


        }

        [HttpPut]
        public IActionResult Update(Departement departement)
        {
            try
            {
                var result = _repository.Update(departement);
                if (result > 0)
                    return Ok(new { statusCode = 200, message = "Data Berhasil DiUpdate!" });

                return BadRequest(new { statusCode = 400, message = "Data Gagal DiUpdate!" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { statusCode = 500, message = e.Message });
            }

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _repository.Delete(id);
                if (result > 0)
                    return Ok(new { statusCode = 200, message = "Data Berhasil Dihapus!" });


                return BadRequest(new { statusCode = 400, message = "Data tidak Berhasil DiHapus!" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { statusCode = 500, message = e.Message });
            }

        }


    }
}

