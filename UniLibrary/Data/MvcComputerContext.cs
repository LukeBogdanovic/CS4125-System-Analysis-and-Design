using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniLibrary.Models;

namespace UniLibrary.Data
{
    public class MvcComputerContext : DbContext
    {
        public MvcComputerContext (DbContextOptions<MvcComputerContext> options)
            : base(options)
        {
        }

        public DbSet<UniLibrary.Models.Computer> Computer { get; set; } = default!;
    }
}
