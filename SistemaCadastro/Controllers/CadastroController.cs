using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Models;
using SistemaCadastro.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastro.Controllers
{
    public class CadastroController : Controller
    {
        private readonly IDocumentoRepositorio _documentoRepositorio;

        public CadastroController(IDocumentoRepositorio documentoRepositorio)
        {
            _documentoRepositorio = documentoRepositorio;
        }


        public IActionResult Index()
        {
            return View();
        }

        //CREATE
        [HttpPost]
        public IActionResult Criar(DocumentoModel documento)
        {
            _documentoRepositorio.Cadastrar(documento);
            return RedirectToAction("Index", "Home");
        }
    }
}
