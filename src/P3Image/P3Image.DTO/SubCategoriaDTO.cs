using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Image.DTO
{
    public class SubCategoriaDTO
    {
        public int Codigo { get; set; }
        public int CodigoCategoria { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }

        public List<CamposDTO> CamposDTO { get; set; }
    }

    public class CamposDTO
    {
        public int Codigo { get; set; }
        public int CodigoSubCategoria { get; set; }
        public int Ordem { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }

        public List<ListaDTO> ListaDTO { get; set; }
    }

    public class ListaDTO
    {
        public int Codigo { get; set; }
        public int CodigoCampo { get; set; }
        public string Descricao { get; set; }
    }
}
