using P3Image.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Image.DAL
{
    public class CategoriaDAL
    {
        private P3ImageEntities _db;

        private Func<Categoria, CategoriaDTO> ConverteParaCategoriaDTO = (categoria) => new CategoriaDTO()
        {
            Codigo = categoria.Codigo,
            Descricao = categoria.Descricao,
            Slug = categoria.Slug
        };

        public bool AdicionaCategoria(CategoriaDTO categoriaDTO)
        {
            using (_db = new P3ImageEntities())
            {
                _db.Categoria.Add(new Categoria() { Descricao = categoriaDTO.Descricao, Slug = categoriaDTO.Slug });
                return _db.SaveChanges() > 0;
            }
        }

        public bool AlteraCategoria(CategoriaDTO categoriaDTO)
        {
            using (_db = new P3ImageEntities())
            {
                var categoria = _db.Categoria.Find(categoriaDTO.Codigo);
                categoria.Descricao = categoriaDTO.Descricao;
                categoria.Slug = categoriaDTO.Slug;
                _db.Categoria.Attach(categoria);
                _db.Entry(categoria).State = System.Data.EntityState.Modified;
                return _db.SaveChanges() > 0;
            }
        }

        public CategoriaDTO Categoria(int codigo)
        {
            using (_db = new P3ImageEntities())
            {
                return ConverteParaCategoriaDTO(_db.Categoria.Find(codigo));
            }
        }

        public List<CategoriaDTO> Categorias()
        {
            using (_db = new P3ImageEntities())
            {
                return _db.Categoria.Where(c => c.Ativo).Select(c => ConverteParaCategoriaDTO(c)).ToList();
            }
        }
    }
}
