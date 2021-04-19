using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FormsExamples.Models;

namespace FormsExamples.Data
{
    public class FormsExamplesContext : DbContext
    {
        public FormsExamplesContext (DbContextOptions<FormsExamplesContext> options)
            : base(options)
        {
        }

        public DbSet<FormsExamples.Models.Movie> Movie { get; set; }
    }
}
