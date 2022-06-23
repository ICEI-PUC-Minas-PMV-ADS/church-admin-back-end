using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChurchAdminAPI.Controllers
{
    [EnableCors("PermitirTudo")]
    [ApiController]
    public class IgrejaController : ControllerBase
    {
        private readonly Conexoes.Sql _sql;


        public IgrejaController()
        {        
            _sql = new Conexoes.Sql();
        }

        [HttpPost("v1/CadastrarIgreja")]
        public IActionResult CadastrarIgreja(Models.Igreja igreja)
        {
            try
            {
                
                _sql.CadastrarIgreja(igreja);

                return StatusCode(200);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPut("v1/AtualizarIgreja")]
        public IActionResult AtualizarIgreja(Models.Igreja igreja)
        {
            try
            {
                _sql.AtualizarIgreja(igreja);
                return StatusCode(200);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("v1/DeletarIgreja/{id}")]
        public IActionResult DeletarIgreja(int id)
        {
            try
            {
                _sql.DeletarIgreja(id);
                return StatusCode(200);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("v1/ListarIgrejas")]
        public IActionResult ListarIgrejas()
        {
            try
            {
                var membros = _sql.ListarIgrejas();

                return StatusCode(200, membros);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
