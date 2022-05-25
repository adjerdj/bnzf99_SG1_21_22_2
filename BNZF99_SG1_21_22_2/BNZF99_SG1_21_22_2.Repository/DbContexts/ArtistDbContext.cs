using BNZF99_SG1_21_22_2.Models.Entities;
using BNZF99_SG1_21_22_2.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace BNZF99_SG1_21_22_2.Repository.DbContexts
{
    public class ArtistDbContext : DbContext
    {
        public virtual DbSet<Artist> Artists { get; set; }

        public ArtistDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Artist.mdf;Integrated Security=true;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed
            var keith = new Artist() { Id = 1, Name = "Keith Richards", Born = new DateTime(1943, 12, 18), RecordLabel = "Rolling Stones Records", Instrument = (Instruments)5, IsOnRehab = true, EndOfContract = new DateTime(2024, 6, 30) };
            var phil = new Artist() { Id = 2, Name = "Phil Collins", Born = new DateTime(1951, 1, 30), RecordLabel = "Virgin Records Ltd", Instrument = (Instruments)0, IsOnRehab = false, EndOfContract = new DateTime(2022, 12, 31) };
            var sting = new Artist() { Id = 3, Name = "Sting", Born = new DateTime(1951, 10, 2), RecordLabel = "Universal Music Group N.V.", Instrument = (Instruments)6, IsOnRehab = false, EndOfContract = new DateTime(2023, 12, 31) };
            var moby = new Artist() { Id = 4, Name = "Moby", Born = new DateTime(1965, 9, 11), RecordLabel = "Elektra Records", Instrument = (Instruments)7, IsOnRehab = false, EndOfContract = new DateTime(2023, 1, 15) };
            var david = new Artist() { Id = 5, Name = "David Gilmour", Born = new DateTime(1946, 3, 6), RecordLabel = "Sony Music Entertainment", Instrument = (Instruments)5, IsOnRehab = false, EndOfContract = new DateTime(2025, 1, 1) };
            var stromae = new Artist() { Id = 6, Name = "Stromae", Born = new DateTime(1985, 3, 12), RecordLabel = "Universal Music Group N.V.", Instrument = (Instruments)6, IsOnRehab = false, EndOfContract = new DateTime(2023, 7, 1) };
            var zoli = new Artist() { Id = 7, Name = "Beck Zoltán", Born = new DateTime(1971, 9, 1), RecordLabel = "ZAJZAJZAJ KFT.", Instrument = (Instruments)6, IsOnRehab = false, EndOfContract = new DateTime(2025, 12, 1) };
            var woodkid = new Artist() { Id = 8, Name = "Woodkid", Born = new DateTime(1983, 3, 16), RecordLabel = "Universal Music Group N.V.", Instrument = (Instruments)6, IsOnRehab = false, EndOfContract = new DateTime(2025, 7, 1) };
            var hozier = new Artist() { Id = 9, Name = "Hozier", Born = new DateTime(1990, 3, 17), RecordLabel = "Universal Music Group N.V.", Instrument = (Instruments)6, IsOnRehab = false, EndOfContract = new DateTime(2022, 12, 31) };
            var roger = new Artist() { Id = 10, Name = "Roger Waters", Born = new DateTime(1943, 9, 6), RecordLabel = "Sony Music Entertainment", Instrument = (Instruments)6, IsOnRehab = false, EndOfContract = new DateTime(2024, 12, 31) };

            modelBuilder.Entity<Artist>().HasData(keith, phil, sting, moby, david, stromae, zoli, woodkid, hozier, roger);
        }
    }
}
