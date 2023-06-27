using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Models;

namespace ProjetoMVC.DataContext
{
    public class AgendaDataContext : DbContext
    {
        public AgendaDataContext(DbContextOptions options) : base(options)
        {



        }

        public DbSet<Contato> Contatos { get; set;}

    }
}