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


        // UPDATE
        public DocumentoModel ListarPorId(int id)
        {
            return _bancoContext.Documentos.FirstOrDefault(x => x.Id == id);
        }

        public DocumentoModel AtualizarDocumento(DocumentoModel documento)
        {
            DocumentoModel documentoDB = ListarPorId(documento.Id);

            //Se não existir Id dar a seguinte mensagem de erro.
            if (documentoDB == null) throw new SystemException("O sistema não conseguiu alterar o documento.");

            documentoDB.Codigo = documento.Codigo;
            documentoDB.Titulo = documento.Titulo;
            documentoDB.Revisao = documento.Revisao;
            documentoDB.DataPlanejada = documento.DataPlanejada;
            documentoDB.Valor = documento.Valor;

            _bancoContext.Documentos.Update(documentoDB);
            _bancoContext.SaveChanges();

            return documentoDB;

        }

        //READ
        public List<DocumentoModel> Consulta()
        {
            return _bancoContext.Documentos.ToList();
        }

        //CREATE
        public DocumentoModel Cadastrar(DocumentoModel documento)
        {             
            _bancoContext.Documentos.Add(documento);
            _bancoContext.SaveChanges();
            return documento;
        }

        //DELETE
        public bool ExcluirDocumento(int id)
        {
            DocumentoModel documentoDB = ListarPorId(id);

            //Se não existir Id dar a seguinte mensagem de erro.
            if (documentoDB == null) throw new SystemException("Não foi possível excluir o documento.");

            _bancoContext.Documentos.Remove(documentoDB);
            _bancoContext.SaveChanges();

            return true;
        }

    }
}
