﻿// <auto-generated />
using System;
using GamingCommunity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GamingCommunity.Migrations
{
    [DbContext(typeof(GamingCommunityDbContext))]
    partial class GamingCommunityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("community_data")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GamingCommunity.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("comment_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("ThreadId")
                        .HasColumnType("integer")
                        .HasColumnName("thread_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("CommentId");

                    b.HasIndex("ThreadId");

                    b.HasIndex("UserId");

                    b.ToTable("comments", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.ContentRating", b =>
                {
                    b.Property<int>("ContentRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("content_rating_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ContentRatingId"));

                    b.Property<string>("ContentRatingName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content_rating");

                    b.HasKey("ContentRatingId");

                    b.HasIndex("ContentRatingName")
                        .IsUnique();

                    b.ToTable("content_ratings", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.Developer", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("developer_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DeveloperId"));

                    b.Property<string>("DeveloperName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("developer");

                    b.HasKey("DeveloperId");

                    b.HasIndex("DeveloperName")
                        .IsUnique();

                    b.ToTable("developers", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("game_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GameId"));

                    b.Property<int>("ContentRatingId")
                        .HasColumnType("integer")
                        .HasColumnName("content_rating_id");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("integer")
                        .HasColumnName("developer_id");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    b.Property<string>("ImageId")
                        .HasColumnType("text")
                        .HasColumnName("image_id");

                    b.Property<int>("PlatformId")
                        .HasColumnType("integer")
                        .HasColumnName("platform_id");

                    b.Property<int>("PublisherId")
                        .HasColumnType("integer")
                        .HasColumnName("publisher_id");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date")
                        .HasColumnName("release_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("title");

                    b.HasKey("GameId");

                    b.HasIndex("ContentRatingId");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("GenreId");

                    b.HasIndex("PlatformId");

                    b.HasIndex("PublisherId");

                    b.ToTable("games", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.GameReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("review_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReviewId"));

                    b.Property<int>("GameId")
                        .HasColumnType("integer")
                        .HasColumnName("game_id");

                    b.Property<string>("ReviewText")
                        .HasColumnType("text")
                        .HasColumnName("review_text");

                    b.Property<int>("Score")
                        .HasColumnType("integer")
                        .HasColumnName("score");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("ReviewId");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("game_reviews", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.GamingThread", b =>
                {
                    b.Property<int>("ThreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("thread_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ThreadId"));

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("ThreadId");

                    b.HasIndex("UserId");

                    b.ToTable("threads", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("genre");

                    b.HasKey("GenreId");

                    b.HasIndex("GenreName")
                        .IsUnique();

                    b.ToTable("genres", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.InboxMessage", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("message_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MessageId"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)")
                        .HasColumnName("message_text");

                    b.Property<int>("RecipientId")
                        .HasColumnType("integer")
                        .HasColumnName("recipient_id");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer")
                        .HasColumnName("sender_id");

                    b.HasKey("MessageId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("inbox_messages", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.Platform", b =>
                {
                    b.Property<int>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("platform_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlatformId"));

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("platform");

                    b.HasKey("PlatformId");

                    b.HasIndex("PlatformName")
                        .IsUnique();

                    b.ToTable("platforms", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("publisher_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PublisherId"));

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("publisher");

                    b.HasKey("PublisherId");

                    b.HasIndex("PublisherName")
                        .IsUnique();

                    b.ToTable("publishers", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<int>("LevelId")
                        .HasColumnType("integer")
                        .HasColumnName("level_id");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("password_hash");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("username");

                    b.HasKey("UserId");

                    b.HasIndex("LevelId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("users", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.UserConnection", b =>
                {
                    b.Property<int>("ConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("connection_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ConnectionId"));

                    b.Property<DateOnly?>("ConnectionEnd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("connection_end")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<DateOnly?>("ConnectionStart")
                        .HasColumnType("date")
                        .HasColumnName("connection_start");

                    b.Property<string>("ConnectionType")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("connection_type");

                    b.Property<int>("FriendId")
                        .HasColumnType("integer")
                        .HasColumnName("friend_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("ConnectionId");

                    b.HasIndex("FriendId");

                    b.HasIndex("UserId");

                    b.ToTable("user_connections", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.UserLevel", b =>
                {
                    b.Property<int>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("level_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LevelId"));

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("user_level");

                    b.HasKey("LevelId");

                    b.HasIndex("Level")
                        .IsUnique();

                    b.ToTable("user_levels", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.UserProfile", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<string>("AvatarId")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("avatar_id");

                    b.Property<string>("Bio")
                        .HasColumnType("text")
                        .HasColumnName("bio");

                    b.Property<string>("GamingPlatformLink")
                        .HasColumnType("text")
                        .HasColumnName("gaming_platform_link");

                    b.HasKey("UserId");

                    b.ToTable("user_profiles", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.Vote", b =>
                {
                    b.Property<int>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("vote_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VoteId"));

                    b.Property<int?>("CommentId")
                        .HasColumnType("integer")
                        .HasColumnName("comment_id");

                    b.Property<int?>("ThreadId")
                        .HasColumnType("integer")
                        .HasColumnName("thread_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<string>("VoteType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("vote_type");

                    b.HasKey("VoteId");

                    b.HasIndex("CommentId");

                    b.HasIndex("ThreadId");

                    b.HasIndex("UserId");

                    b.ToTable("votes", "community_data");
                });

            modelBuilder.Entity("GamingCommunity.Entities.Comment", b =>
                {
                    b.HasOne("GamingCommunity.Entities.GamingThread", null)
                        .WithMany()
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingCommunity.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingCommunity.Entities.Game", b =>
                {
                    b.HasOne("GamingCommunity.Entities.ContentRating", null)
                        .WithMany()
                        .HasForeignKey("ContentRatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingCommunity.Entities.Developer", null)
                        .WithMany()
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingCommunity.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingCommunity.Entities.Platform", null)
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingCommunity.Entities.Publisher", null)
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingCommunity.Entities.GameReview", b =>
                {
                    b.HasOne("GamingCommunity.Entities.Game", null)
                        .WithOne()
                        .HasForeignKey("GamingCommunity.Entities.GameReview", "GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingCommunity.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("GamingCommunity.Entities.GameReview", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingCommunity.Entities.GamingThread", b =>
                {
                    b.HasOne("GamingCommunity.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingCommunity.Entities.InboxMessage", b =>
                {
                    b.HasOne("GamingCommunity.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingCommunity.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingCommunity.Entities.User", b =>
                {
                    b.HasOne("GamingCommunity.Entities.UserLevel", null)
                        .WithMany()
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingCommunity.Entities.UserConnection", b =>
                {
                    b.HasOne("GamingCommunity.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingCommunity.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingCommunity.Entities.UserProfile", b =>
                {
                    b.HasOne("GamingCommunity.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("GamingCommunity.Entities.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamingCommunity.Entities.Vote", b =>
                {
                    b.HasOne("GamingCommunity.Entities.Comment", null)
                        .WithMany()
                        .HasForeignKey("CommentId");

                    b.HasOne("GamingCommunity.Entities.GamingThread", null)
                        .WithMany()
                        .HasForeignKey("ThreadId");

                    b.HasOne("GamingCommunity.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
