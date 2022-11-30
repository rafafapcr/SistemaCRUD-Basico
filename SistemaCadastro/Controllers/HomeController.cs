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

        // READ
        public IActionResult Index()
        {
            List<DocumentoModel> documentos = _documentoRepositorio.Consulta();

            return View(documentos);
        }

        // DELETE
        public IActionResult ApagarDocumento(int id)
        {
            DocumentoModel documento = _documentoRepositorio.ListarPorId(id);
            return View(documento);
        }


        public IActionResult ConfirmarExlusao(int id)
        {
            _documentoRepositorio.ExcluirDocumento(id);
            return RedirectToAction("Index");
        }

        // UPDATE
        public IActionResult EditarDocumento(int id)
        {
            DocumentoModel documento = _documentoRepositorio.ListarPorId(id);
            return View(documento);
        }

        [HttpPost]
        public IActionResult Alterar(DocumentoModel documento)
        {
            _documentoRepositorio.AtualizarDocumento(documento);
            return RedirectToAction("Index");
        }



    }
}
