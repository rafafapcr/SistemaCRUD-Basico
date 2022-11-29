using SistemaCadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastro.Repositorio
{
    public interface IDocumentoRepositorio
    {
        List<DocumentoModel> Consulta();
        DocumentoModel Cadastrar(DocumentoModel documento);

    }
}
