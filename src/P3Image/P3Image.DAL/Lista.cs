//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P3Image.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lista
    {
        public int Codigo { get; set; }
        public int CodigoCampo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    
        public virtual Campos Campos { get; set; }
    }
}
