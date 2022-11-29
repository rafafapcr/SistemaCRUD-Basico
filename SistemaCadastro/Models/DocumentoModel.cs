using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastro.Models
{
    public class DocumentoModel
    { 
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Revisao { get; set; }
        public DateTime DataPlanejada { get; set; }
        public decimal Valor { get; set; }

    }
}
