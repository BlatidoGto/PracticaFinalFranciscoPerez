using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticaFinalFranciscoPerez.Models;

namespace PracticaFinalFranciscoPerez.Data
{
    public class PracticaFinalFranciscoPerezContext : DbContext
    {
        public PracticaFinalFranciscoPerezContext (DbContextOptions<PracticaFinalFranciscoPerezContext> options)
            : base(options)
        {
        }

        public DbSet<PracticaFinalFranciscoPerez.Models.PersonaItem> PersonaItem { get; set; } = default!;
    }
}
