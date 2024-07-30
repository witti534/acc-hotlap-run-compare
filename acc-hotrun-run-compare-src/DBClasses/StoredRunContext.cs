using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace acc_hotlab_private_run_compare.DBClasses;

public partial class StoredRunContext : DbContext
{
    public DbSet<RunInformation> RunInformationSet { get; set; }
    public DbSet<SectorInformation> SectorInformationSet { get; set; } 

    /// <summary>
    /// This class gives the whole context needed to store RunInformation and SectorInformation objects
    /// </summary>
    public StoredRunContext()
    {
        Database.EnsureCreated();
    }

    public StoredRunContext(DbContextOptions<StoredRunContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=efcore.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Set up keys of SectorInformation and RunInformation entities
        modelBuilder.Entity<SectorInformation>()
            .HasKey(nameof(SectorInformation.RunID), nameof(SectorInformation.LapNumber), nameof(SectorInformation.SectorIndex));

        modelBuilder.Entity<RunInformation>()
            .HasKey(nameof(RunInformation.RunID));
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
