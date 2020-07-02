using Competition.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Competition.Repositories
{
    public class ManagerDbContext : DbContext
    {
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<AthleteToDiscipline> AthleteToDisciplines { get; set; }

        public ManagerDbContext()
            : base("Server=DESKTOP-QDMFR0L;Database=CompetitionProject1;Trusted_Connection=True;")
        {
            Athletes = this.Set<Athlete>();
            Teams = this.Set<Team>();
            Disciplines = this.Set<Discipline>();
            AthleteToDisciplines = this.Set<AthleteToDiscipline>();
        }
    }
}