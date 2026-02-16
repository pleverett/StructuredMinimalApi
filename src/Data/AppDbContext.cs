namespace Chirper.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostLike> PostLikes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentLike> CommentLikes { get; set; }
    public DbSet<Follow> Follows { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureUsersTable(modelBuilder);
        ConfigurePostsTable(modelBuilder);
        ConfigureCommentsTable(modelBuilder);
        ConfigureLikesTable(modelBuilder);
        ConfigureFollowsTable(modelBuilder);
        ConfigureCommentLikesTable(modelBuilder);
        ConfigureRefreshTokensTable(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private static void ConfigureUsersTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<User>();

        builder.HasIndex(x => x.Username)
            .IsUnique();

        builder.HasIndex(x => x.ReferenceId)
            .IsUnique();
        
        builder.HasMany(x => x.Posts)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.LikedPosts)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Comments)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.LikedComments)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Following)
            .WithOne(x => x.FollowerUser)
            .HasForeignKey(x => x.FollowerUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Followers)
            .WithOne(x => x.FollowedUser)
            .HasForeignKey(x => x.FollowedUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    private static void ConfigurePostsTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<Post>();

        builder.HasIndex(x => x.ReferenceId)
            .IsUnique();

        // Index on foreign key for user's posts
        builder.HasIndex(x => x.UserId);

        // Index on CreatedAtUtc for sorting (descending for newest first)
        builder.HasIndex(x => x.CreatedAtUtc)
            .IsDescending();

        // Composite index for efficient "get user's posts ordered by date" queries
        builder.HasIndex(x => new { x.UserId, x.CreatedAtUtc })
            .IsDescending(false, true); // UserId ASC, CreatedAtUtc DESC

        builder.Property(x => x.Title)
            .HasMaxLength(100);

        builder.HasMany(x => x.Likes)
            .WithOne(x => x.Post)
            .HasForeignKey(x => x.PostId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Post)
            .HasForeignKey(x => x.PostId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    private static void ConfigureCommentsTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<Comment>();

        builder.HasIndex(x => x.ReferenceId)
            .IsUnique();

        // Index on PostId foreign key for "get comments for post" queries
        builder.HasIndex(x => x.PostId);

        // Index on UserId foreign key for "get user's comments" queries
        builder.HasIndex(x => x.UserId);

        // Index on CreatedAtUtc for sorting comments
        builder.HasIndex(x => x.CreatedAtUtc)
            .IsDescending();

        // Composite index for "get post's comments ordered by date"
        builder.HasIndex(x => new { x.PostId, x.CreatedAtUtc })
            .IsDescending(false, true); // PostId ASC, CreatedAtUtc DESC

        // Index on ReplyToCommentId for fetching comment replies
        builder.HasIndex(x => x.ReplyToCommentId);

        builder.HasMany(x => x.Likes)
            .WithOne(x => x.Comment)
            .HasForeignKey(x => x.CommentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Replies)
            .WithOne(x => x.ReplyToComment)
            .HasForeignKey(x => x.ReplyToCommentId)
            .OnDelete(DeleteBehavior.NoAction);
    }

    private static void ConfigureLikesTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<PostLike>();
        builder.HasKey(x => new { x.PostId, x.UserId });

        // Index on UserId to check "has user liked this post"
        // PostId is already indexed as part of composite key
        builder.HasIndex(x => x.UserId);
    }

    private static void ConfigureFollowsTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<Follow>();
        builder.HasKey(x => new { x.FollowerUserId, x.FollowedUserId });

        // Index on FollowedUserId for "get user's followers" queries
        // FollowerUserId is already indexed as part of composite key
        builder.HasIndex(x => x.FollowedUserId);

        // Index on CreatedAtUtc for ordering follows
        builder.HasIndex(x => x.CreatedAtUtc);
    }

    private static void ConfigureCommentLikesTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<CommentLike>();
        builder.HasKey(x => new { x.CommentId, x.UserId });

        // Index on UserId to check "has user liked this comment"
        // CommentId is already indexed as part of composite key
        builder.HasIndex(x => x.UserId);
    }

    private static void ConfigureRefreshTokensTable(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<RefreshToken>();

        builder.HasIndex(x => x.Token)
            .IsUnique();

        builder.HasIndex(x => x.UserId);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}