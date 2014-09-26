using P3Image.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3Image.DAL
{
    public class SubCategoriaDAL
    {
        private P3ImageEntities _db;

        private Func<SubCategoria, SubCategoriaDTO> ConverteParaSubCategoriaDTO = (subCategoria) => new SubCategoriaDTO()
        {
            Codigo = subCategoria.Codigo,
            CodigoCategoria = subCategoria.CodigoCategoria,
            Descricao = subCategoria.Descricao,
            Slug = subCategoria.Slug,
            CamposDTO = subCategoria.Campos.Select(c => new CamposDTO()
                            {
                                Codigo = c.Codigo,
                                CodigoSubCategoria = c.CodigoSubCategoria,
                                Descricao = c.Descricao,
                                Ordem = c.Ordem,
                                Tipo = c.Tipo,
                                ListaDTO = c.Lista.Select(d => new ListaDTO()
                                {
                                    Codigo = d.Codigo,
                                    CodigoCampo = d.CodigoCampo,
                                    Descricao = d.Descricao
                                }).ToList()
                            }).ToList()
        };

        public bool AdicionaSubCategoria(SubCategoriaDTO subCategoriaDTO)
        {
            using (_db = new P3ImageEntities())
            {
                _db.SubCategoria.Add(new SubCategoria()
                    {
                        CodigoCategoria = subCategoriaDTO.CodigoCategoria,
                        Descricao = subCategoriaDTO.Descricao,
                        Slug = subCategoriaDTO.Slug,
                        Campos = subCategoriaDTO.CamposDTO.Select(c => new Campos()
                        {
                            Descricao = c.Descricao,
                            Ordem = c.Ordem,
                            Tipo = c.Tipo,
                            Lista = c.ListaDTO.Select(d => new Lista()
                            {
                                Descricao = d.Descricao
                            }).ToList()
                        }).ToList()
                    });
                return _db.SaveChanges() > 0;
            }
        }

        public bool AlteraSubCategoria(SubCategoriaDTO subCategoriaDTO)
        {
            using (_db = new P3ImageEntities())
            {
                var subCategoria = _db.SubCategoria.Find(subCategoriaDTO.Codigo);
                subCategoria.CodigoCategoria = subCategoriaDTO.CodigoCategoria;
                subCategoria.Descricao = subCategoriaDTO.Descricao;
                subCategoria.Slug = subCategoriaDTO.Slug;

                foreach (var campos in subCategoria.Campos.Where(c => c.Ativo).ToList())
                {
                    var sub = subCategoriaDTO.CamposDTO.Where(d => d.Codigo == campos.Codigo).FirstOrDefault();
                    if (sub != null)
                    {
                        foreach (var listas in campos.Lista.Where(c => c.Ativo && !sub.ListaDTO.Any(e => e.Codigo == c.Codigo)).ToList())
                        {
                            var lista = _db.Lista.Find(listas.Codigo);
                            lista.Ativo = false;
                        }
                    }
                }

                foreach (var campos in subCategoria.Campos.Where(c => c.Ativo && !subCategoriaDTO.CamposDTO.Any(d => d.Codigo == c.Codigo)).ToList())
                {
                    campos.Ativo = false;
                }

                foreach (var novoCampos in subCategoriaDTO.CamposDTO.Where(c => !subCategoria.Campos.Any(d => d.Codigo == c.Codigo)))
                {
                    _db.Campos.Add(new Campos()
                        {
                            CodigoSubCategoria = subCategoriaDTO.Codigo,
                            Descricao = novoCampos.Descricao,
                            Ordem = novoCampos.Ordem,
                            Tipo = novoCampos.Tipo
                        });

                    if (novoCampos.ListaDTO.Count > 0)
                        novoCampos.ListaDTO.ForEach(c => _db.Lista.Add(new Lista() { CodigoCampo = c.CodigoCampo, Descricao = c.Descricao }));
                }

                return _db.SaveChanges() > 0;
            }
        }

        public SubCategoriaDTO SubCategoria(int codigo)
        {
            using (_db = new P3ImageEntities())
            {
                return ConverteParaSubCategoriaDTO(_db.SubCategoria.Find(codigo));
            }
        }

        public List<SubCategoriaDTO> SubCategorias()
        {
            using (_db = new P3ImageEntities())
            {
                return _db.SubCategoria.Select(c => ConverteParaSubCategoriaDTO(c)).ToList();
            }
        }
    }
}