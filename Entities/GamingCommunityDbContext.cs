using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Entities
{
    public class GamingCommunityDbContext : DbContext
    {
        public GamingCommunityDbContext(DbContextOptions<GamingCommunityDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    modelBuilder.Entity(entityType.Name).ToTable(entityType.Name, "community_data");
            //}

            modelBuilder.Entity<InboxMessage>()
                .HasOne(im => im.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .IsRequired();

            modelBuilder.Entity<InboxMessage>()
                .HasOne(im => im.Sender)
                .WithMany(u => u.SentMessages)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserConnections)
                .WithOne(uc => uc.User)
                .HasForeignKey(uc => uc.ConnectionId);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.GameReview)
                .WithOne(gr => gr.Game)
                .HasForeignKey<GameReview>(gr => gr.ReviewId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserProfileId);

            modelBuilder.Entity<Comment>().HasKey(c => c.CommentId);
            modelBuilder.Entity<ContentRating>().HasKey(c => c.ContentRatingId);
            modelBuilder.Entity<Developer>().HasKey(c => c.DeveloperId);
            modelBuilder.Entity<Platform>().HasKey(c => c.PlatformId);
            modelBuilder.Entity<Publisher>().HasKey(c => c.PublisherId);
            modelBuilder.Entity<Game>().HasKey(c => c.GameId);
            modelBuilder.Entity<GameReview>().HasKey(c => c.ReviewId);
            modelBuilder.Entity<GamingThread>().HasKey(c => c.ThreadId);
            modelBuilder.Entity<Genre>().HasKey(c => c.GenreId);
            modelBuilder.Entity<InboxMessage>().HasKey(c => c.MessageId);
            modelBuilder.Entity<User>().HasKey(c => c.UserId);
            modelBuilder.Entity<UserConnection>().HasKey(c => c.ConnectionId);
            modelBuilder.Entity<UserLevel>().HasKey(c => c.LevelId);
            modelBuilder.Entity<Vote>().HasKey(c => c.VoteId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserLevel> UserLevels { get; set; }
        public DbSet<GamingThread> GamingThreads { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<ContentRating> ContentRatings { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameReview> GamesReviews { get; set; }
        public DbSet<UserConnection> UserConnections { get; set; }
        public DbSet<InboxMessage> InboxMessages { get; set; }
    }
}
