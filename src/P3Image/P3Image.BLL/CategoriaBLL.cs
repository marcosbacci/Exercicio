using P3Image.DAL;
using P3Image.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Image.BLL
{
    public class CategoriaBLL
    {
        private CategoriaDAL _categoriaDAL = new CategoriaDAL();

        public bool Adiciona(CategoriaDTO categoriaDTO)
        {
            return _categoriaDAL.AdicionaCategoria(categoriaDTO);
        }

        public bool Altera(CategoriaDTO categoriaDTO)
        {
            return _categoriaDAL.AlteraCategoria(categoriaDTO);
        }

        public CategoriaDTO Categoria(int codigo)
        {
            return _categoriaDAL.Categoria(codigo);
        }

        public List<CategoriaDTO> Categorias()
        {
            return _categoriaDAL.Categorias();
        }
    }
}
