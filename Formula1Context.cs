using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace project1.Data.Models;

public partial class Formula1Context : DbContext
{
    public Formula1Context()
    {
    }

    public Formula1Context(DbContextOptions<Formula1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<RaceResult> RaceResults { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=STUDENT7;Initial Catalog=Formula1;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__Drivers__A411C5BD3D454E54");

            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Nationality)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nationality");
            entity.Property(e => e.TeamId).HasColumnName("team_id");

            entity.HasOne(d => d.Team).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK__Drivers__team_id__398D8EEE");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.RaceId).HasName("PK__Races__1C8FE2F9175CA7A3");

            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.RaceDate).HasColumnName("race_date");
            entity.Property(e => e.RaceName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("race_name");
            entity.Property(e => e.SeasonYear).HasColumnName("season_year");
        });

        modelBuilder.Entity<RaceResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Race_Res__AFB3C316482F19A0");

            entity.ToTable("Race_Results");

            entity.Property(e => e.ResultId).HasColumnName("result_id");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.Points)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("points");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Driver).WithMany(p => p.RaceResults)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK__Race_Resu__drive__3F466844");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceResults)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("FK__Race_Resu__race___3E52440B");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Teams__F82DEDBCF1BDDD91");

            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.FoundationYear).HasColumnName("foundation_year");
            entity.Property(e => e.TeamName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("team_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
