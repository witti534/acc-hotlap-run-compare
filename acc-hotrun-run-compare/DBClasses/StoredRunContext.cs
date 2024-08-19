using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace acc_hotrun_run_compare.DBClasses;

public sealed partial class StoredRunContext : DbContext
{
    public DbSet<RunInformation> RunInformationSet { get; set; }
    public DbSet<SectorInformation> SectorInformationSet { get; set; }

    private static StoredRunContext Instance = null;
    /// <summary>
    /// This class gives the whole context needed to store RunInformation and SectorInformation objects
    /// </summary>
    private StoredRunContext()
    {
        Database.EnsureCreated();
    }

    public static StoredRunContext GetInstance()
    {
        //If Instance == null, create a new StoredRunContext
        Instance ??= new StoredRunContext();

        return Instance;
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
