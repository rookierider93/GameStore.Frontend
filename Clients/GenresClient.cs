using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient
{
    public readonly Genre[] genres = [
        new(){
            Id=1,
            Name="Fighting"
        },
        new(){
            Id=2,
            Name="Roleplaying"
        },
        new(){
            Id=3,
            Name="Running"
        },
        new(){
            Id=4,
            Name="Sports"
        }
        ,
        new(){
            Id=5,
            Name="Racing"
        },
        new(){
            Id=6,
            Name="Kids & Family"
        }
    ];

    public Genre[] GetGenres() => genres;
}
