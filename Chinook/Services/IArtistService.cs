

using Chinook.Models;


namespace Chinook.Services
{
    
    public interface IArtistService
    {
        Task<Artist> GetArtistById(long artistId);

        Task<Artist> SearchArtistByName(string artistName);

        Task<int> DisplayNumberOfAlbum();

        Task<List<Playlist>> GetPlayList(); 
        
        Task<Playlist> CreatePlayList(Playlist playList);



    }
}
