﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K_12.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class K_12Entities : DbContext
    {
        public K_12Entities()
            : base("name=K_12Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BaseEntity> BaseEntities { get; set; }
        public virtual DbSet<student_medication> student_medication { get; set; }
        public virtual DbSet<student_parent> student_parent { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<student_section> student_section { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
    }
}
