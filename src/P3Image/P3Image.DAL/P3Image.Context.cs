﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    internal partial class P3ImageEntities : DbContext
    {
        public P3ImageEntities()
            : base("name=P3ImageEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Campos> Campos { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Lista> Lista { get; set; }
        public DbSet<SubCategoria> SubCategoria { get; set; }
    }
}
