using ChurchAdminAPI.Conexoes;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace ChurchAdminAPI.Controllers
{
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IConverter _converter;

        private readonly Conexoes.Sql _sql;

        public PdfController(IConverter converter)
        {
            _converter = converter;
            _sql = new Sql(); 
        }


        [HttpGet("v1/GerarPdf")]
        public IActionResult GerarPdf()
        {
            string ObterHtmlString()
            {
                var membros = _sql.ListarMembros();

                var sb = new StringBuilder();
                sb.Append(@"
                   <html>
                   <head>
                            <h4>Membros - Church Admin</h4>
                             
             ");

                foreach (var membro in membros)
                {
                    sb.AppendFormat(@" 
                         <h3>Matrícula: </h3>
                         <p>{0}</p>
                         <h3>Nome: </h3>
                         <p>{1}</p>
                         <h3>Cpf: </h3>
                         <p>{2}</p>
                         <h3>Cep: </h3>
                         <p>{3}</p>
                         <h3>Endereço: </h3>
                         <p>{4}</p>
                         <h3>Número: </h3>
                         <p>{5}</p>
                         <h3>Complemento: </h3>
                         <p>{6}</p>
                         <h3>Bairro: </h3>
                         <p>{7}</p>
                         <h3>Município: </h3>
                         <p>{8}</p>
                         <h3>Estado: </h3>
                         <p>{9}</p>
                         <h3>Email: </h3>
                         <p>{10}</p>
                         <h3>Telefone: </h3>
                         <p>{11}</p>
                         <h3>Sexo: </h3>
                         <p>{12}</p>
                         <h3>Data de nascimento: </h3>
                         <p>{13}</p>
                         <h3>Natural: </h3>
                         <p>{14}</p>
                         <h3>Estado civil: </h3>
                         <p>{15}</p>
                         <h3>Profissão: </h3>
                         <p>{16}</p>
                         <h3>Data batismo: </h3>
                         <p>{17}</p>
                         <h3>Cargo igreja: </h3>
                         <p>{18}</p>
                         <h3>Igreja Id: </h3>
                         <p>{19}</p>
                         <h3>Status: </h3>
                         <p>{20}</p>
                         <h3> </h3>
                         <h3> </h3>
                         <br>
                         <hr>
                         <br>

                    ", membro.Matricula, membro.Nome, membro.Cpf, membro.Cep, membro.Endereco, membro.Numero, membro.Complemento,
                       membro.Bairro, membro.Municipio, membro.Estado, membro.Email, membro.Fone, membro.Sexo, membro.Nascimento, membro.Naturalidade,
                       membro.EstadoCivil, membro.Profissao, membro.DataBatismoAguas, membro.CargoIgreja, membro.IgrejaID, membro.Status);      
                              
                }

                sb.Append(@"
                            </table>
                           </body>
                          </html>");

                return sb.ToString();
            }

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Relatório de Membros - Church Admin",
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = ObterHtmlString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "style.css") },
                HeaderSettings = { FontName = "Roboto", FontSize = 10, Right = "Página [page] de [toPage]", Line = false },
                FooterSettings = { FontName = "Roboto", FontSize = 10, Line = true, Center = "Church Admin"}
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);
            return File(file, "application/pdf");
        }
    }
}
