using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GamingCommunity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "community_data");

            migrationBuilder.CreateTable(
                name: "content_ratings",
                schema: "community_data",
                columns: table => new
                {
                    content_rating_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content_rating = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content_ratings", x => x.content_rating_id);
                });

            migrationBuilder.CreateTable(
                name: "developers",
                schema: "community_data",
                columns: table => new
                {
                    developer_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    developer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developers", x => x.developer_id);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                schema: "community_data",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    genre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "platforms",
                schema: "community_data",
                columns: table => new
                {
                    platform_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    platform = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_platforms", x => x.platform_id);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                schema: "community_data",
                columns: table => new
                {
                    publisher_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    publisher = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.publisher_id);
                });

            migrationBuilder.CreateTable(
                name: "user_levels",
                schema: "community_data",
                columns: table => new
                {
                    level_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_level = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_levels", x => x.level_id);
                });

            migrationBuilder.CreateTable(
                name: "games",
                schema: "community_data",
                columns: table => new
                {
                    game_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    release_date = table.Column<DateOnly>(type: "date", nullable: true),
                    genre_id = table.Column<int>(type: "integer", nullable: false),
                    platform_id = table.Column<int>(type: "integer", nullable: false),
                    developer_id = table.Column<int>(type: "integer", nullable: false),
                    publisher_id = table.Column<int>(type: "integer", nullable: false),
                    content_rating_id = table.Column<int>(type: "integer", nullable: false),
                    image_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.game_id);
                    table.ForeignKey(
                        name: "FK_games_content_ratings_content_rating_id",
                        column: x => x.content_rating_id,
                        principalSchema: "community_data",
                        principalTable: "content_ratings",
                        principalColumn: "content_rating_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_games_developers_developer_id",
                        column: x => x.developer_id,
                        principalSchema: "community_data",
                        principalTable: "developers",
                        principalColumn: "developer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_games_genres_genre_id",
                        column: x => x.genre_id,
                        principalSchema: "community_data",
                        principalTable: "genres",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_games_platforms_platform_id",
                        column: x => x.platform_id,
                        principalSchema: "community_data",
                        principalTable: "platforms",
                        principalColumn: "platform_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_games_publishers_publisher_id",
                        column: x => x.publisher_id,
                        principalSchema: "community_data",
                        principalTable: "publishers",
                        principalColumn: "publisher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "community_data",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    level_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_users_user_levels_level_id",
                        column: x => x.level_id,
                        principalSchema: "community_data",
                        principalTable: "user_levels",
                        principalColumn: "level_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_reviews",
                schema: "community_data",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    game_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false),
                    review_text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game_reviews", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_game_reviews_games_game_id",
                        column: x => x.game_id,
                        principalSchema: "community_data",
                        principalTable: "games",
                        principalColumn: "game_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_game_reviews_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "community_data",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inbox_messages",
                schema: "community_data",
                columns: table => new
                {
                    message_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sender_id = table.Column<int>(type: "integer", nullable: false),
                    recipient_id = table.Column<int>(type: "integer", nullable: false),
                    message_text = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inbox_messages", x => x.message_id);
                    table.ForeignKey(
                        name: "FK_inbox_messages_users_recipient_id",
                        column: x => x.recipient_id,
                        principalSchema: "community_data",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inbox_messages_users_sender_id",
                        column: x => x.sender_id,
                        principalSchema: "community_data",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "threads",
                schema: "community_data",
                columns: table => new
                {
                    thread_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    content = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_threads", x => x.thread_id);
                    table.ForeignKey(
                        name: "FK_threads_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "community_data",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_connections",
                schema: "community_data",
                columns: table => new
                {
                    connection_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    friend_id = table.Column<int>(type: "integer", nullable: false),
                    connection_type = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    connection_start = table.Column<DateOnly>(type: "date", nullable: true),
                    connection_end = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "CURRENT_DATE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_connections", x => x.connection_id);
                    table.ForeignKey(
                        name: "FK_user_connections_users_friend_id",
                        column: x => x.friend_id,
                        principalSchema: "community_data",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_connections_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "community_data",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_profiles",
                schema: "community_data",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    bio = table.Column<string>(type: "text", nullable: true),
                    avatar_id = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    gaming_platform_link = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_profiles", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_user_profiles_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "community_data",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                schema: "community_data",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    thread_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_comments_threads_thread_id",
                        column: x => x.thread_id,
                        principalSchema: "community_data",
                        principalTable: "threads",
                        principalColumn: "thread_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "community_data",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "votes",
                schema: "community_data",
                columns: table => new
                {
                    vote_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vote_type = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    thread_id = table.Column<int>(type: "integer", nullable: true),
                    comment_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_votes", x => x.vote_id);
                    table.ForeignKey(
                        name: "FK_votes_comments_comment_id",
                        column: x => x.comment_id,
                        principalSchema: "community_data",
                        principalTable: "comments",
                        principalColumn: "comment_id");
                    table.ForeignKey(
                        name: "FK_votes_threads_thread_id",
                        column: x => x.thread_id,
                        principalSchema: "community_data",
                        principalTable: "threads",
                        principalColumn: "thread_id");
                    table.ForeignKey(
                        name: "FK_votes_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "community_data",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_thread_id",
                schema: "community_data",
                table: "comments",
                column: "thread_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_user_id",
                schema: "community_data",
                table: "comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_content_ratings_content_rating",
                schema: "community_data",
                table: "content_ratings",
                column: "content_rating",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_developers_developer",
                schema: "community_data",
                table: "developers",
                column: "developer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_game_reviews_game_id",
                schema: "community_data",
                table: "game_reviews",
                column: "game_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_game_reviews_user_id",
                schema: "community_data",
                table: "game_reviews",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_games_content_rating_id",
                schema: "community_data",
                table: "games",
                column: "content_rating_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_developer_id",
                schema: "community_data",
                table: "games",
                column: "developer_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_genre_id",
                schema: "community_data",
                table: "games",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_platform_id",
                schema: "community_data",
                table: "games",
                column: "platform_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_publisher_id",
                schema: "community_data",
                table: "games",
                column: "publisher_id");

            migrationBuilder.CreateIndex(
                name: "IX_genres_genre",
                schema: "community_data",
                table: "genres",
                column: "genre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inbox_messages_recipient_id",
                schema: "community_data",
                table: "inbox_messages",
                column: "recipient_id");

            migrationBuilder.CreateIndex(
                name: "IX_inbox_messages_sender_id",
                schema: "community_data",
                table: "inbox_messages",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_platforms_platform",
                schema: "community_data",
                table: "platforms",
                column: "platform",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_publishers_publisher",
                schema: "community_data",
                table: "publishers",
                column: "publisher",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_threads_user_id",
                schema: "community_data",
                table: "threads",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_connections_friend_id",
                schema: "community_data",
                table: "user_connections",
                column: "friend_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_connections_user_id",
                schema: "community_data",
                table: "user_connections",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_levels_user_level",
                schema: "community_data",
                table: "user_levels",
                column: "user_level",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_level_id",
                schema: "community_data",
                table: "users",
                column: "level_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                schema: "community_data",
                table: "users",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_votes_comment_id",
                schema: "community_data",
                table: "votes",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_votes_thread_id",
                schema: "community_data",
                table: "votes",
                column: "thread_id");

            migrationBuilder.CreateIndex(
                name: "IX_votes_user_id",
                schema: "community_data",
                table: "votes",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_reviews",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "inbox_messages",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "user_connections",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "user_profiles",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "votes",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "games",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "comments",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "content_ratings",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "developers",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "genres",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "platforms",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "publishers",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "threads",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "users",
                schema: "community_data");

            migrationBuilder.DropTable(
                name: "user_levels",
                schema: "community_data");
        }
    }
}
