using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComfyTowels.Models;

namespace ComfyTowels.Data
{
    public class ComfyTowelsContext : DbContext
    {
        public ComfyTowelsContext (DbContextOptions<ComfyTowelsContext> options)
            : base(options)
        {
        }

        public DbSet<ComfyTowels.Models.Towels> Towels { get; set; } = default!;
    }
}
