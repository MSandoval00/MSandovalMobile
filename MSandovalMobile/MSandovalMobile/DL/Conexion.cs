using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using MSandovalMobile.Models;

namespace MSandovalMobile.DL
{
    public class Conexion:DbContext
    {
        //Tablas 
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Escuela> Escuela { get; set; }

        private readonly string rutaBD;
        public Conexion(string rutaBD)
        {
            this.rutaBD = rutaBD;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IConexion>().GetDatabasePath();
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
