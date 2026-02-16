# Testing Guide

This guide explains how to set up and run the Chirper API for local testing.

## Quick Start (SQLite - Recommended for Testing)

SQLite is configured for the Development environment, allowing you to test the API without installing SQL Server.

### First Time Setup

```bash
# Navigate to project directory
cd src

# Run the application (automatically creates SQLite database)
dotnet run
```

The application will:
- Create a `chirper.db` file in the `src` directory
- Apply all migrations automatically
- Start listening on http://localhost:5000

### Testing Endpoints

```bash
# 1. Check health
curl http://localhost:5000/health

# 2. Create a test user (signup)
curl -X POST http://localhost:5000/auth/signup \
  -H "Content-Type: application/json" \
  -d "{\"username\":\"testuser\",\"password\":\"Test123!\"}"

# 3. Login (returns access + refresh tokens)
curl -X POST http://localhost:5000/auth/login \
  -H "Content-Type: application/json" \
  -d "{\"username\":\"testuser\",\"password\":\"Test123!\"}"

# 4. Create a post (requires authentication)
curl -X POST http://localhost:5000/posts \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer YOUR_ACCESS_TOKEN" \
  -d "{\"title\":\"My First Post\",\"content\":\"Hello World!\"}"

# 5. Get all posts
curl http://localhost:5000/posts

# 6. Test correlation IDs (check X-Correlation-ID header)
curl -v http://localhost:5000/health
```

### Resetting the Database

To start fresh with a clean database:

**Windows (PowerShell/CMD)**
```bash
# Stop the application (Ctrl+C)
cd src
del chirper.db
dotnet run
```

**macOS/Linux**
```bash
# Stop the application (Ctrl+C)
cd src
rm chirper.db
dotnet run
```

The database file will be recreated automatically when you restart the application.

## Environment-Based Configuration

The application uses different databases based on the environment:

| Environment | Database | Config File |
|------------|----------|-------------|
| Development | SQLite | `appsettings.Development.json` |
| Production | SQL Server | `appsettings.json` |

### How Environment Detection Works

```bash
# Development (default)
dotnet run                                    # Uses SQLite

# Staging/Production
$env:ASPNETCORE_ENVIRONMENT="Production"      # Windows PowerShell
export ASPNETCORE_ENVIRONMENT=Production      # macOS/Linux
dotnet run                                    # Uses SQL Server
```

## SQL Server Setup (Production/Staging)

If you need to test with SQL Server instead of SQLite:

### Prerequisites

- SQL Server installed and running
- SQL Server authentication configured

### Apply Migrations

```bash
cd src

# Set environment to Production
$env:ASPNETCORE_ENVIRONMENT="Production"      # Windows PowerShell
export ASPNETCORE_ENVIRONMENT=Production      # macOS/Linux

# Apply migrations
dotnet ef database update

# Run the application
dotnet run
```

### Connection String

The SQL Server connection string is configured in `src/appsettings.json`:

```json
"ConnectionStrings": {
  "Default": "Server=.;Database=Chirper;Trusted_Connection=True;Encrypt=False;"
}
```

Modify this if your SQL Server instance uses different settings:
- `Server=.` - Local SQL Server (change to `localhost` or remote server name)
- `Trusted_Connection=True` - Windows authentication (change to SQL auth if needed)
- `Encrypt=False` - Disable encryption for local development

### SQL Server Authentication Example

If using SQL authentication instead of Windows authentication:

```json
"ConnectionStrings": {
  "Default": "Server=localhost;Database=Chirper;User Id=sa;Password=YourPassword;Encrypt=False;"
}
```

## Testing Workflow Examples

### Scenario 1: Testing Authentication Flow

```bash
# 1. Start fresh
del chirper.db
dotnet run

# 2. Create user
curl -X POST http://localhost:5000/auth/signup \
  -H "Content-Type: application/json" \
  -d "{\"username\":\"alice\",\"password\":\"SecurePass123!\"}"

# Response: { "accessToken": "...", "refreshToken": "..." }

# 3. Login
curl -X POST http://localhost:5000/auth/login \
  -H "Content-Type: application/json" \
  -d "{\"username\":\"alice\",\"password\":\"SecurePass123!\"}"

# 4. Refresh token (after 15 minutes when access token expires)
curl -X POST http://localhost:5000/auth/refresh \
  -H "Content-Type: application/json" \
  -d "{\"refreshToken\":\"YOUR_REFRESH_TOKEN\"}"
```

### Scenario 2: Testing Rate Limiting

```bash
# Trigger rate limit (auth endpoints limited to 5 requests per minute)
for i in {1..10}; do
  curl -X POST http://localhost:5000/auth/login \
    -H "Content-Type: application/json" \
    -d "{\"username\":\"test\",\"password\":\"wrong\"}"
  echo ""
done

# After 5 attempts, you should see:
# HTTP 429 Too Many Requests
```

### Scenario 3: Testing Optimistic Concurrency

```bash
# 1. Create a post
POST_ID=$(curl -X POST http://localhost:5000/posts \
  -H "Authorization: Bearer TOKEN" \
  -H "Content-Type: application/json" \
  -d '{"title":"Test","content":"Content"}' | jq -r '.id')

# 2. Update the post twice simultaneously (simulates conflict)
# This demonstrates the 409 Conflict response with optimistic concurrency
```

### Scenario 4: Testing Health Checks

```bash
# Liveness probe (Kubernetes)
curl http://localhost:5000/health

# Readiness probe (includes database check)
curl http://localhost:5000/health/ready

# Detailed diagnostics
curl http://localhost:5000/health/details
```

## Database Migrations

### View Applied Migrations

```bash
cd src
dotnet ef migrations list
```

### Current Migrations

1. **Init** - Base schema (Users, Posts, Comments, Likes, Follows)
2. **SecurityFixes** - Password hashing + refresh tokens
3. **AddDatabaseIndexes** - Performance indexes (11 total)
4. **AddOptimisticConcurrency** - Concurrency control (RowVersion)

### Create New Migration

```bash
cd src
dotnet ef migrations add YourMigrationName
dotnet ef database update
```

### Rollback Migration

```bash
# Rollback to previous migration
cd src
dotnet ef database update PreviousMigrationName

# Remove last migration file
dotnet ef migrations remove
```

## Troubleshooting

### Issue: "Could not open a connection to SQL Server"

**Cause**: Running in Production environment without SQL Server configured.

**Solution**: Switch to Development environment for SQLite testing:
```bash
$env:ASPNETCORE_ENVIRONMENT="Development"     # Windows PowerShell
export ASPNETCORE_ENVIRONMENT=Development     # macOS/Linux
dotnet run
```

### Issue: SQLite error "database is locked"

**Cause**: Another process has the database file open.

**Solution**:
1. Stop the application (Ctrl+C)
2. Close any database tools (DB Browser for SQLite, etc.)
3. Restart the application

### Issue: Migrations not applying automatically

**Cause**: Database file exists but is outdated.

**Solution**:
```bash
# Option 1: Delete and recreate
del chirper.db
dotnet run

# Option 2: Manual migration
dotnet ef database update
```

### Issue: "The entity type 'RefreshToken' requires a primary key"

**Cause**: Old migration files incompatible with current model.

**Solution**: This shouldn't happen, but if it does:
```bash
# Delete database and let it recreate
del chirper.db
dotnet run
```

## Features Tested by SQLite

All application features work with SQLite:

✅ **Security Features**
- Password hashing (ASP.NET Identity)
- JWT token generation (15-minute expiry)
- Refresh token rotation (7-day expiry)
- Rate limiting (100 req/10sec global, 5 req/min auth)

✅ **Performance Features**
- Database indexes (all 11 indexes work in SQLite)
- Optimistic concurrency control (RowVersion)
- Query splitting

✅ **Observability Features**
- Health checks (/health, /health/ready, /health/details)
- Correlation IDs (X-Correlation-ID header)
- Structured logging (Serilog)

✅ **API Endpoints**
- Authentication (signup, login, refresh)
- Posts (create, read, update, delete)
- Comments (create, read, reply)
- Likes (posts and comments)
- Follows (users)

## SQLite vs SQL Server Differences

### What Works the Same

- All CRUD operations
- Transactions
- Foreign keys
- Indexes
- Migrations
- Query performance (for testing data volumes)

### Minor Differences (Not Issues for Testing)

- **Date/Time Storage**: SQLite stores as text/int, SQL Server as datetime2
  - No impact on API behavior
- **Case Sensitivity**: SQLite is case-insensitive by default
  - SQL Server depends on collation
- **Performance**: SQL Server is faster with large datasets
  - SQLite is sufficient for testing with <10,000 records

### When to Use SQL Server

Use SQL Server for:
- **Load testing** with large datasets (>100,000 records)
- **Production** deployments
- **Performance benchmarking** of indexed queries
- **Final validation** before deployment

SQLite is perfect for:
- **Development** and rapid iteration
- **Feature testing** and debugging
- **CI/CD** pipelines (fast, no infrastructure)
- **Quick validation** of changes

## CI/CD Integration

SQLite is ideal for automated testing:

```yaml
# .github/workflows/test.yml example
- name: Run Integration Tests
  run: |
    cd src
    dotnet run &
    sleep 5
    curl http://localhost:5000/health
    # Run your test scripts
```

No database server required in CI environment.

## Performance Expectations

### SQLite (Development)

- Startup time: ~2 seconds
- Request latency: <10ms for simple queries
- Suitable for: <10,000 records

### SQL Server (Production)

- Startup time: ~3-5 seconds (includes connection pool)
- Request latency: <5ms with proper indexes
- Suitable for: Millions of records

## Next Steps

1. **Run the Application**: `dotnet run`
2. **Test Endpoints**: Use the curl examples above
3. **Explore API**: Navigate to http://localhost:5000/swagger
4. **Reset & Repeat**: Delete `chirper.db` and start fresh anytime

## Additional Resources

- [EF Core SQLite Provider](https://learn.microsoft.com/en-us/ef/core/providers/sqlite/)
- [ASP.NET Core Environments](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/environments)
- [API Documentation](README.md)
- [Security Improvements](SECURITY_FIXES_SUMMARY.md)
- [.NET 10 Upgrade Notes](UPGRADE_NOTES.md)
