using apiGestores.Context;
using apiGestores.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiGestores.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {

        private readonly AppDBContext context;

        public GestoresController(AppDBContext context)
        {
            this.context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Gestores_bd.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "GetGestor")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.Gestores_bd.FirstOrDefault(g => g.id == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Gestores_bd gestor)
        {
            try
            {
                context.Gestores_bd.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Gestores_bd gerstor)
        {
            try
            {
                if (gerstor.id != id)
                {
                    return BadRequest();
                }

                context.Entry(gerstor).State = EntityState.Modified;
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gerstor.id }, gerstor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.Gestores_bd.FirstOrDefault(g => g.id == id);
                if (gestor == null)
                {
                    return NotFound();
                }
                context.Gestores_bd.Remove(gestor);
                context.SaveChanges();
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
