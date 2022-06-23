using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChurchAdminAPI.Controllers
{
    [EnableCors("PermitirTudo")]
    [ApiController]
    public class MembroController : ControllerBase
    {
        private readonly Conexoes.Sql _sql;


        public MembroController()
        {
            _sql = new Conexoes.Sql();
        }

        [HttpPost("v1/CadastrarMembro")]
        public IActionResult CadastrarMembro(Models.Membro membro)
        {
            try
            {
                _sql.CadastrarMembro(membro);

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

        [HttpPut("v1/AtualizarMembro")]
        public IActionResult AtualizarMembro(Models.Membro membro)
        {
            try
            {
                _sql.AtualizarMembro(membro);
                return StatusCode(200);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }

        }

        [HttpDelete("v1/DeletarMembro/{matricula}")]
        public IActionResult DeletarMembro(int matricula)
        {
            try
            {
                _sql.DeletarMembro(matricula);

                return StatusCode(200);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("v1/ListarMembros")]
        public IActionResult ListarMembros()
        {
            try
            {
                var membros = _sql.ListarMembros();

                return StatusCode(200, membros);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
