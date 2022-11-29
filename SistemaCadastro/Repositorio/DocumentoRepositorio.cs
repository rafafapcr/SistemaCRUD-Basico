using SistemaCadastro.Data;
using SistemaCadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastro.Repositorio
{
    public class DocumentoRepositorio : IDocumentoRepositorio
    {
        private readonly DataContext _bancoContext;
        public DocumentoRepositorio(DataContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<DocumentoModel> Consulta()
        {
            return _bancoContext.Documentos.ToList();
        }
        public DocumentoModel Cadastrar(DocumentoModel documento)
        {
            //Create 
            _bancoContext.Documentos.Add(documento);
            _bancoContext.SaveChanges();
            return documento;
        }

    }
}
