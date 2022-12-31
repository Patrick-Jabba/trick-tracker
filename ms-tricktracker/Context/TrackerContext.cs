using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ms_tracker.Models;

namespace ms_tracker.Context
{
    public class TrackerContext : DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> options) : base(options)
        {}

        public DbSet<Projeto> Projetos {get; set;}
    }
}