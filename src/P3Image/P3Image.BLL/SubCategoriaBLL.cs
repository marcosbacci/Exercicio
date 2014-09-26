using P3Image.DAL;
using P3Image.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Image.BLL
{
    public class SubCategoriaBLL
    {
        private SubCategoriaDAL _subCategoriaDAL = new SubCategoriaDAL();

        public bool Adiciona(SubCategoriaDTO subCategoriaDTO)
        {
            return _subCategoriaDAL.AdicionaSubCategoria(subCategoriaDTO);
        }

        public bool Altera(SubCategoriaDTO subCategoriaDTO)
        {
            return _subCategoriaDAL.AlteraSubCategoria(subCategoriaDTO);
        }

        public SubCategoriaDTO Categoria(int codigo)
        {
            return _subCategoriaDAL.SubCategoria(codigo);
        }

        public List<SubCategoriaDTO> Categorias()
        {
            return _subCategoriaDAL.SubCategorias();
        }
    }
}
