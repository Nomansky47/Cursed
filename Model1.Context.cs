﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cursed
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AirEntities : DbContext
    {
        public AirEntities()
               : base("name=AirEntities")
        {
        }
        private static AirEntities _context;
        public static AirEntities GetContext()
        {
            if (_context == null)
                _context = new AirEntities();
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aircraft_Cabins> Aircraft_Cabins { get; set; }
        public virtual DbSet<Aircrafts> Aircrafts { get; set; }
        public virtual DbSet<Airports> Airports { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<Passengers> Passengers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
    }
}
