using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BetAndBuild.Server.Models
{
    public partial class MainDbContext : DbContext
    {
        public MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bet> Bets { get; set; } = null!;
        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<ClubCompetition> ClubCompetitions { get; set; } = null!;
        public virtual DbSet<Competition> Competitions { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Coupon> Coupons { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Season> Seasons { get; set; } = null!;
        public virtual DbSet<UserPassword> UserPasswords { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.ToTable("Bet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BetDate)
                    .HasColumnType("datetime")
                    .HasColumnName("bet_date");

                entity.Property(e => e.CouponId).HasColumnName("coupon_id");

                entity.Property(e => e.Draw).HasColumnName("draw");

                entity.Property(e => e.GoalsGuest).HasColumnName("goals_guest");

                entity.Property(e => e.GoalsHost).HasColumnName("goals_host");

                entity.Property(e => e.MatchId).HasColumnName("match_id");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.WinGuest).HasColumnName("win_guest");

                entity.Property(e => e.WinHost).HasColumnName("win_host");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Bets)
                    .HasForeignKey(d => d.CouponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bet_Coupon");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Bets)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bet_Match");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Bets)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bet_User");
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Club_Country");
            });

            modelBuilder.Entity<ClubCompetition>(entity =>
            {
                entity.ToTable("Club_Competition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClubId).HasColumnName("club_id");

                entity.Property(e => e.CompetitionId).HasColumnName("competition_id");

                entity.Property(e => e.SeasonId).HasColumnName("season_id");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.ClubCompetitions)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Club_Competition_Club");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.ClubCompetitions)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Club_Competition_Competition");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.ClubCompetitions)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Club_Competition_Season");
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.ToTable("Competition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.IsLeagueCompetition).HasColumnName("is_league_competition");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.TeamsCounter).HasColumnName("teams_counter");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("Competition_Country");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.ToTable("Coupon");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompetitionId).HasColumnName("competition_id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.FixtureNumber).HasColumnName("fixture_number");

                entity.Property(e => e.GoalsGuest).HasColumnName("goals_guest");

                entity.Property(e => e.GoalsHost).HasColumnName("goals_host");

                entity.Property(e => e.GuestId).HasColumnName("guest_id");

                entity.Property(e => e.HostId).HasColumnName("host_id");

                entity.Property(e => e.OddsDraw)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("odds_draw");

                entity.Property(e => e.OddsGuest)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("odds_guest");

                entity.Property(e => e.OddsHost)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("odds_host");

                entity.Property(e => e.SeasonId).HasColumnName("season_id");

                entity.Property(e => e.XGHost)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("xG_host");

                entity.Property(e => e.XgGuest)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("xg_guest");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Match_Competition");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.MatchGuests)
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Match_Guest");

                entity.HasOne(d => d.Host)
                    .WithMany(p => p.MatchHosts)
                    .HasForeignKey(d => d.HostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Match_Host");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Match_Season");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Budget)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("budget");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.LastActivity)
                    .HasColumnType("datetime")
                    .HasColumnName("last_activity");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("login");
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.ToTable("Season");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<UserPassword>(entity =>
            {
                entity.ToTable("User_Password");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expire_date");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.PlayerId).HasColumnName("player_id");

                entity.Property(e => e.Salt).HasColumnName("salt");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.UserPasswords)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Password_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
