using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniLibrary.Models;

namespace UniLibrary.Data
{
    public class MvcRoomContext : DbContext
    {
        public MvcRoomContext(DbContextOptions<MvcRoomContext> options)
            : base(options)
        {
        }

        public DbSet<UniLibrary.Models.Room> Room { get; set; } = default!;
    }
}