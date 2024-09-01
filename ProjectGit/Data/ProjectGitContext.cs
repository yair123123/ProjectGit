using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectGit.Models;

namespace ProjectGit.Data
{
    public class ProjectGitContext : DbContext
    {
        public ProjectGitContext (DbContextOptions<ProjectGitContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectGit.Models.Managment> Managment { get; set; } = default!;
        public DbSet<ProjectGit.Models.Teachers> Teachers { get; set; } = default!;
        public DbSet<ProjectGit.Models.Students> Students { get; set; } = default!;
    }
}
