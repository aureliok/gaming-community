using Microsoft.EntityFrameworkCore;

namespace GamingCommunity.Entities
{
    public class GamingCommunityDbContext : DbContext
    {
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
