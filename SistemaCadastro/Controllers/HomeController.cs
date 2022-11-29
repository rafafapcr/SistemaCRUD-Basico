using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaCadastro.Models;
using SistemaCadastro.Repositorio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastro.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDocumentoRepositorio _documentoRepositorio;

        public HomeController(IDocumentoRepositorio documentoRepositorio)
        {
            _documentoRepositorio = documentoRepositorio;
        }
        public IActionResult Index()
        {
            List<DocumentoModel> documentos = _documentoRepositorio.Consulta();

            return View(documentos);
        }

        public IActionResult EditarDocumento()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
