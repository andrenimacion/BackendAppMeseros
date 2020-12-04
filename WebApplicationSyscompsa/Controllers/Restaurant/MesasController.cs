using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationSyscompsa.Models;

namespace WebApplicationSyscompsa.Controllers.Restaurant
{
    [Route("api/MesasJob")]
    [ApiController]
    public class MesasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MesasController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("DataMesas")]
        public async Task<IActionResult> reportSave([FromBody] AdapMesa model)
        {

            if (ModelState.IsValid)
            {
                _context.AdapMesa.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(model);
                }
                else
                { return BadRequest("Revisa bien los datos que estas enviando a la base de datos"); }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("DeleteMesa/{id}")]
        public ActionResult<DataTable> DeletProduct([FromRoute] string DeleteMesa)
        {
            string Sentencia = "DELETE FROM AdapMesa WHERE Id = @IdMesa;";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using SqlCommand cmd = new SqlCommand(Sentencia, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@IdMesa", DeleteMesa));
                adapter.Fill(dt);
            }
            if (dt == null)
            {
                return NotFound("");
            }
            return Ok(dt);
        }

        [HttpPut]
        [Route("MesaUpdate/{Id}")]
        public async Task<IActionResult> ProductUpdate([FromRoute] int Id, [FromBody] AdapMesa model)
        {
            // string imagen = model.IMAGENBIT;

            if (Id != model.Id)
            {
                return BadRequest("El ID de la mesa no es compatible, o no existe");
            }

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(model);

        }


    }
}