using Dapper;

namespace Movies.Application.Database;

public class DbInitializer
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public DbInitializer(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        await connection.ExecuteAsync(@"
        CREATE TABLE IF NOT EXISTS movies (
            id UUID PRIMARY KEY,
            slug TEXT NOT NULL,
            title TEXT NOT NULL,
            yearofrelease INTEGER NOT NULL
        )");

        await connection.ExecuteAsync(@"
        CREATE UNIQUE INDEX CONCURRENTLY IF NOT EXISTS movies_slug_idx
        ON movies
        USING btree(slug)");

        await connection.ExecuteAsync("""
            create table if not exists genres (
                movieId UUID references movies(id),
                name Text not null);
        """);

        await connection.ExecuteAsync("""
            create table if not exists ratings(
                userid uuid,
                movieid uuid references movies(id),
                rating integer not null,
                primary key (userid, movieid)
            ));
        """);
    }
}