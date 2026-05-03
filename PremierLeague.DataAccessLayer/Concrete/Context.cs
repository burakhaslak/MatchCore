using Microsoft.EntityFrameworkCore;
using PremierLeague.DtoLayer.StandingDto;
using PremierLeague.DtoLayer.TeamDtos;
using PremierLeague.EntityLayer.Entities;

namespace PremierLeague.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<FootballMatch> FootballMatches { get; set; }
        public DbSet<MatchStatistic> MatchStatistics { get; set; }
        public DbSet<MatchEvent> MatchEvents { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Week> Weeks { get; set; }

        //Procedures
        public DbSet<ResultStandingsDto> ResultStandings { get; set; }
        public DbSet<ResultTeamFormDto> ResultTeamForms { get; set; }
        public DbSet<ResultJsonString> ResultJsonStrings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballMatch>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict); 

            // AwayTeam İlişkisi
            modelBuilder.Entity<FootballMatch>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<FootballMatch>()
                .HasOne(m => m.MatchStatistic)
                .WithOne(s => s.FootballMatch)
                .HasForeignKey<MatchStatistic>(s => s.FootballMatchId)
                .OnDelete(DeleteBehavior.Cascade); 


            modelBuilder.Entity<ResultStandingsDto>().HasNoKey();

            modelBuilder.Entity<ResultTeamFormDto>().HasNoKey();

            modelBuilder.Entity<ResultJsonString>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

    }
}
