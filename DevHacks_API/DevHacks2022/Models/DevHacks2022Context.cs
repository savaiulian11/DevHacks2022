using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DevHacks2022.Models;

public partial class DevHacks2022Context : DbContext
{
    public DevHacks2022Context()
    {
    }

    public DevHacks2022Context(DbContextOptions<DevHacks2022Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityType> ActivityTypes { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyUser> CompanyUsers { get; set; }

    public virtual DbSet<Reward> Rewards { get; set; }

    public virtual DbSet<RewardsUser> RewardsUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserActivity> UserActivities { get; set; }

    public virtual DbSet<WorkHour> WorkHours { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.IdType).HasColumnName("ID_Type");
            entity.Property(e => e.Link).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);

        });

        modelBuilder.Entity<ActivityType>(entity =>
        {
            entity.ToTable("Activity_Types");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<CompanyUser>(entity =>
        {
            entity.ToTable("Company_Users");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdCompany).HasColumnName("ID_Company");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

        });

        modelBuilder.Entity<Reward>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Provider).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Milestone).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<RewardsUser>(entity =>
        {
            entity.ToTable("Rewards_User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdReward).HasColumnName("ID_Reward");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Number)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<UserActivity>(entity =>
        {
            entity.ToTable("User_Activity");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdActivity).HasColumnName("ID_Activity");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

         
        });

        modelBuilder.Entity<WorkHour>(entity =>
        {
            entity.ToTable("Work_Hours");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActiveTime)
                .HasColumnType("datetime")
                .HasColumnName("Active_Time");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
