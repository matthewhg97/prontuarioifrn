﻿//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_Prontuario.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class prontuarioEntities : DbContext
    {
        public prontuarioEntities()
            : base("name=prontuarioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<consulta> consulta { get; set; }
        public DbSet<medico> medico { get; set; }
        public DbSet<paciente> paciente { get; set; }
        public DbSet<recepcionista> recepcionista { get; set; }
    }
}
