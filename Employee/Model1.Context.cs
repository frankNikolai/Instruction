﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Employee
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gr691_fnvEntities : DbContext
    {
        public gr691_fnvEntities()
            : base("name=gr691_fnvEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Instruction> Instruction { get; set; }
        public virtual DbSet<Instruction_Employees> Instruction_Employees { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Organization_Employees> Organization_Employees { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<View_Instruction> View_Instruction { get; set; }
        public virtual DbSet<User_Auto> User_Auto { get; set; }
    }
}
