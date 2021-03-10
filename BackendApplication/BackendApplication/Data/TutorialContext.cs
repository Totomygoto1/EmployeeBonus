using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BackendApplication.Models
{
    public class TutorialContext : DbContext
    {
        public TutorialContext (DbContextOptions<TutorialContext> options)
            : base(options)
        {
        }

        public DbSet<BackendApplication.Models.Tutorial> Tutorial { get; set; }
    }
}
