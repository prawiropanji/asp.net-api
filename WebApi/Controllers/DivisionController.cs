using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebApi.Models;
using WebApi.Repositories.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly DivisionRepository _repository;
        public DivisionController(DivisionRepository divisionRepository)
        {
            _repository = divisionRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var divisions = _repository.Get();
                if (divisions != null)
                    return Ok(new { statusCode = 200, message = "data ditemukan!", data = divisions });

                return StatusCode(204, new {statusCode = 204, message = "internal server error" });
               
            }
            catch (Exception e)
            {
                return StatusCode(500, new { statusCode = 500, message = e.Message });
            }
        
        }

        // GET https://localhost:7002/api/division/:id 
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var division = _repository.Get(id);
                if (division != null)
                    return Ok(new { statusCode = 200, message = "data ditemukan!", data = division });

                return StatusCode(204, new { Message = "Data tidak Ditemukan!" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { statusCode = 500, message = e.Message });
            }
            
        }

        [HttpPost]
        public IActionResult Create(Division division)
        {
            try
            {
                var result = _repository.Create(division);
                if (result > 0)
                    return Ok(new { Message = "Data Berhasil Disimpan!" });

                return BadRequest(new { Message = "Data Gagal Disimpan!" });
            }
            catch (Exception e)
            {

                return StatusCode(500, new { statusCode = 500, message = e.Message });
            }

           
        }

        [HttpPut]
        public IActionResult Update(Division division)
        {
            try
            {
                var result = _repository.Update(division);
                if (result > 0)
                    return Ok(new { Message = "Data Berhasil DiUpdate!" });

                return BadRequest(new { Message = "Data Gagal DiUpdate!" });
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
                    return Ok(new { Message = "Data Berhasil Dihapus!" });


                return BadRequest(new { Message = "Data tidak Berhasil DiHapus!" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { statusCode = 500, message = e.Message });

            }
          
        }


    }
}
