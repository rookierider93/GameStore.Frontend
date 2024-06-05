using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummery> games =
        [
            new(){
            Id=1,
            Name="Mario",
            Genre="Running",
            Price=19.99M,
            ReleaseDate=new DateOnly(1992,7,15)
            },
            new(){
            Id=2,
            Name="Street Fighter II",
            Genre="Fighting",
            Price=59.99M,
            ReleaseDate=new DateOnly(1990,3,10)
            },
            new(){
            Id=3,
            Name="Fifa",
            Genre="Sports",
            Price=69.99M,
            ReleaseDate=new DateOnly(2022,9,27)
            },
        ];

    private readonly Genre[] genres = new GenresClient().GetGenres();
    public GameSummery[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);
        var gameSummery = new GameSummery
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummery);
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var gerne = GetGenreById(updatedGame.GenreId);
        GameSummery existingGame = GetGameSummeryById(updatedGame.Id);
        existingGame.Name = updatedGame.Name;
        existingGame.Genre = gerne.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public GameDetails GetGame(int id)
    {
        GameSummery? game = GetGameSummeryById(id);

        var genre = genres.Single(genre => string.Equals(
            genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummeryById(id);
        games.Remove(game);
    }

    private GameSummery GetGameSummeryById(int id)
    {
        GameSummery? game = games.Find(x => x.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return genres.Single(genre => genre.Id == int.Parse(id));
    }

}
