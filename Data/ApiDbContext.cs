using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TARpe19TodoApp.Models;

namespace TARpe19TodoApp.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public DbSet<ItemData> Items { get; set; }

        public DbSet<TODOItem> TaskItems { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<TARpe19TodoApp.Models.TODOHomework> TODOHomework { get; set; }
    }
}
