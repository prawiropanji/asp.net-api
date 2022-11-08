using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Base
{
    public class BaseController<Repository, Entity, Key> : ControllerBase
        where Repository : class, IRepository<Entity, Key>
        where Entity : class
    {
        private readonly Repository _repository;
        public BaseController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listData = _repository.Get();
                if (listData != null)
                    return Ok(new { statusCode = 200, message = "Data ditemukan!", data = listData });
                return StatusCode(204, new { statusCode = 204, message = "Data tidak ada!" });

            }
            catch (Exception e)
            {
                return StatusCode(500, new { statusCode = 500, message = e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Key id)
        {
            try
            {
                var data = _repository.Get(id);
                if (data != null)
                    return Ok(new { statusCode = 200, message = "Data ditemukan!", data = data });

                return StatusCode(204, new { statusCode = 204, message = "Data tidak Ditemukan!" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { statusCode = 500, message = e.Message });
            }
        }

        [HttpPost]
        public IActionResult Create(Entity entity)
        {
            try
            {
                var result = _repository.Create(entity);
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
        public IActionResult Update(Entity entity)
        {
            try
            {
                var result = _repository.Update(entity);
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
        public IActionResult Delete(Key id)
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
