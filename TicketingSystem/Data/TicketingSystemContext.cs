using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketingSystem.Models;

    public class TicketingSystemContext : DbContext
    {
        public TicketingSystemContext (DbContextOptions<TicketingSystemContext> options)
            : base(options)
        {
        }

        public DbSet<TicketingSystem.Models.Technicians> Technicians { get; set; } = default!;

        public DbSet<TicketingSystem.Models.Tickets> Tickets { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Technicians>().ToTable("Technicians");
        modelBuilder.Entity<Tickets>().ToTable("Tickets");
    }


    public DbSet<TicketingSystem.Models.AllTickets> AllTickets { get; set; } = default!;
}
