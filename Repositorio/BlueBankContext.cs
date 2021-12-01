using Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio
{
    public class BlueBankContext : DbContext
    {
        public BlueBankContext(DbContextOptions<BlueBankContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }
    }
}
