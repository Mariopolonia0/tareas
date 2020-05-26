using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tarea2.Entidades;

namespace Tarea2.DAL
{
    public class Contexto : DbContext { 

        public DbSet<Registro> Registro { get; set; }

        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Tarea2Control.db");
        }



    }
}
