using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GamingCommunity.Entities
{
    public class GamingCommunityDbContext : DbContext
    {
        public GamingCommunityDbContext(DbContextOptions<GamingCommunityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("community_data");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserLevel>(entity =>
            {
                entity.ToTable("user_levels");
                entity.HasKey(p => p.LevelId);
                entity.HasIndex(p => p.Level).IsUnique();

                entity.Property(p => p.LevelId).HasColumnName("level_id");
                entity.Property(p => p.Level).HasColumnName("user_level")
                                             .HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(p => p.UserId);
                entity.HasIndex(p => p.UserName).IsUnique();

                entity.Property(p => p.UserId).HasColumnName("user_id");
                entity.Property(p => p.UserName).HasColumnName("username")
                                                .HasMaxLength(50)
                                                .HasAnnotation("RegularExpression", @"^[^@]+$");
                entity.Property(p => p.Email).HasColumnName("email")
                                             .HasMaxLength(100);
                entity.Property(p => p.PasswordHash).HasColumnName("password_hash")
                                                    .HasMaxLength(60);
                entity.Property(p => p.LevelId).HasColumnName("level_id");

                entity.HasOne<UserLevel>()
                      .WithMany()
                      .HasForeignKey(u => u.LevelId);
            });

            modelBuilder.Entity<GamingThread>(entity =>
            {
                entity.ToTable("threads");
                entity.HasKey(p => p.ThreadId);
                entity.Property(p => p.ThreadId).HasColumnName("thread_id");
                entity.Property(p => p.Title).HasColumnName("title")
                                             .HasMaxLength(255);
                entity.Property(p => p.Content).HasColumnName("content");
                entity.Property(p => p.CreatedAt).HasColumnName("created_at")
                                                 .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(p => p.UserId).HasColumnName("user_id");

                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(t => t.UserId);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");
                entity.HasKey(p => p.CommentId);
                entity.Property(p => p.CommentId).HasColumnName("comment_id");
                entity.Property(p => p.Content).HasColumnName("content");
                entity.Property(p => p.CreatedAt).HasColumnName("created_at")
                                                 .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(p => p.UserId).HasColumnName("user_id");
                entity.Property(p => p.ThreadId).HasColumnName("thread_id");

                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(c => c.UserId);

                entity.HasOne<GamingThread>()
                      .WithMany()
                      .HasForeignKey(c => c.ThreadId);
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.ToTable("votes");
                entity.HasKey(p => p.VoteId);
                entity.Property(p => p.VoteId).HasColumnName("vote_id");
                entity.Property(p => p.VoteType).HasColumnName("vote_type")
                                                .IsRequired()
                                                .HasMaxLength(8);
                entity.Property(p => p.UserId).HasColumnName("user_id");
                entity.Property(p => p.ThreadId).HasColumnName("thread_id");
                entity.Property(p => p.CommentId).HasColumnName("comment_id");

                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(v => v.UserId);

                entity.HasOne<GamingThread>()
                      .WithMany()
                      .HasForeignKey(v => v.ThreadId);

                entity.HasOne<Comment>()
                      .WithMany()
                      .HasForeignKey(v => v.CommentId);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("user_profiles");
                entity.HasKey(p => p.UserId);
                entity.Property(p => p.UserId).HasColumnName("user_id");
                entity.Property(p => p.Bio).HasColumnName("bio");
                entity.Property(p => p.AvatarId).HasColumnName("avatar_id")
                                                .HasMaxLength(32);
                entity.Property(p => p.GamingPlatformLink).HasColumnName("gaming_platform_link");

                entity.HasOne<User>()
                      .WithOne()
                      .HasForeignKey<UserProfile>(up => up.UserId);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genres");
                entity.HasKey(p => p.GenreId);
                entity.HasIndex(p => p.GenreName).IsUnique();

                entity.Property(p => p.GenreId).HasColumnName("genre_id");
                entity.Property(p => p.GenreName).HasColumnName("genre")
                                                 .IsRequired();
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.ToTable("platforms");
                entity.HasKey(p => p.PlatformId);
                entity.HasIndex(p => p.PlatformName).IsUnique();

                entity.Property(p => p.PlatformId).HasColumnName("platform_id");
                entity.Property(p => p.PlatformName).HasColumnName("platform")
                                                    .IsRequired();
            });

            modelBuilder.Entity<Developer>(entity =>
            {
                entity.ToTable("developers");
                entity.HasKey(p => p.DeveloperId);
                entity.HasIndex(p => p.DeveloperName).IsUnique();

                entity.Property(p => p.DeveloperId).HasColumnName("developer_id");
                entity.Property(p => p.DeveloperName).HasColumnName("developer")
                                                     .IsRequired();
            });


            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("publishers");
                entity.HasKey(p => p.PublisherId);
                entity.HasIndex(p => p.PublisherName).IsUnique();

                entity.Property(p => p.PublisherId).HasColumnName("publisher_id");
                entity.Property(p => p.PublisherName).HasColumnName("publisher")
                                                     .IsRequired();
            });

            modelBuilder.Entity<ContentRating>(entity =>
            {
                entity.ToTable("content_ratings");
                entity.HasKey(p => p.ContentRatingId);
                entity.HasIndex(p => p.ContentRatingName).IsUnique();

                entity.Property(p => p.ContentRatingId).HasColumnName("content_rating_id");
                entity.Property(p => p.ContentRatingName).HasColumnName("content_rating")
                                                         .IsRequired();
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("games");
                entity.HasKey(p => p.GameId);
                entity.Property(p => p.GameId).HasColumnName("game_id");
                entity.Property(p => p.Title).HasColumnName("title")
                                             .HasMaxLength(60)
                                             .IsRequired();
                entity.Property(p => p.ReleaseDate).HasColumnName("release_date");
                entity.Property(p => p.GenreId).HasColumnName("genre_id");
                entity.Property(p => p.PlatformId).HasColumnName("platform_id");
                entity.Property(p => p.DeveloperId).HasColumnName("developer_id");
                entity.Property(p => p.PublisherId).HasColumnName("publisher_id");
                entity.Property(p => p.ContentRatingId).HasColumnName("content_rating_id");
                entity.Property(p => p.ImageId).HasColumnName("image_id");

                entity.HasOne<Genre>()
                      .WithMany()
                      .HasForeignKey(g => g.GenreId);

                entity.HasOne<Platform>()
                      .WithMany()
                      .HasForeignKey(g => g.PlatformId);

                entity.HasOne<Developer>()
                      .WithMany()
                      .HasForeignKey(g => g.DeveloperId);

                entity.HasOne<Publisher>()
                      .WithMany()
                      .HasForeignKey(g => g.PublisherId);

                entity.HasOne<ContentRating>()
                      .WithMany()
                      .HasForeignKey(g => g.ContentRatingId);
            });

            modelBuilder.Entity<GameReview>(entity =>
            {
                entity.ToTable("game_reviews");
                entity.HasKey(p => p.ReviewId);
                entity.Property(p => p.ReviewId).HasColumnName("review_id");
                entity.Property(p => p.GameId).HasColumnName("game_id");
                entity.Property(p => p.UserId).HasColumnName("user_id");
                entity.Property(p => p.Score).HasColumnName("score").IsRequired();
                entity.Property(p => p.ReviewText).HasColumnName("review_text");

                entity.HasOne<Game>()
                      .WithOne()
                      .HasForeignKey<GameReview>(gr => gr.GameId);

                entity.HasOne<User>()
                      .WithOne()
                      .HasForeignKey<GameReview>(up => up.UserId);
            });

            modelBuilder.Entity<UserConnection>(entity =>
            {
                entity.ToTable("user_connections");
                entity.HasKey(p => p.ConnectionId);
                entity.Property(p => p.ConnectionId).HasColumnName("connection_id");
                entity.Property(p => p.UserId).HasColumnName("user_id");
                entity.Property(p => p.FriendId).HasColumnName("friend_id");
                entity.Property(p => p.ConnectionType).HasColumnName("connection_type")
                                                      .HasMaxLength(15).IsRequired();
                entity.Property(p => p.ConnectionStart).HasColumnName("connection_start");
                entity.Property(p => p.ConnectionEnd).HasColumnName("connection_end")
                                                     .HasDefaultValueSql("CURRENT_DATE");

                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(uc => uc.UserId);

                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(uc => uc.FriendId);
            });

            modelBuilder.Entity<InboxMessage>(entity =>
            {
                entity.ToTable("inbox_messages");
                entity.HasKey(p => p.MessageId);
                entity.Property(p => p.MessageId).HasColumnName("message_id");
                entity.Property(p => p.SenderId).HasColumnName("sender_id");
                entity.Property(p => p.RecipientId).HasColumnName("recipient_id");
                entity.Property(p => p.MessageText).HasColumnName("message_text")
                                                   .HasMaxLength(400)
                                                   .IsRequired();
                entity.Property(p => p.CreatedAt).HasColumnName("created_at")
                                                 .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(im => im.SenderId);

                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(im => im.RecipientId);
            });
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
